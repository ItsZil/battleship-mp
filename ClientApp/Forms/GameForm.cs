using ClientApp.Utilities;
using Newtonsoft.Json;
using SharedLibrary.Models;
using SharedLibrary.Models.Request_Models;
using SharedLibrary.Structs;

namespace ClientApp.Forms
{
    public partial class GameForm : Form
    {
        private static HttpUtility _httpUtility = new HttpUtility();
        private static Client _client;
        private static Game _game;

        private List<Ship> _ships = new List<Ship>();
        private List<Coordinate> _coordinatesLeft = new List<Coordinate>(); // Left side game board, current player
        private List<Coordinate> _coordinatesRight = new List<Coordinate>(); // Right side game board, other player

        public GameForm(Client client, Game game)
        {
            InitializeComponent();
            _client = client;
            _game = game;

            Text = $"Game: {game.Name} Game ID: {game.GameId} Player ID: {client.Id}";
            _client.RegisterGameFormEvents(this);
        }

        private async void Cell_Click(object sender, EventArgs e)
        {
            Control clickedCell = (Control)sender;
            string[] tagParts = clickedCell.Tag.ToString().Split('_'); // x_y
            
            int x = int.Parse(tagParts[0]);
            int y = int.Parse(tagParts[1]);

            object hitDetailsObj = await _client.SendMessageAsync("SendShot", new Shot(_game.GameId, _client.Id, x, y, 1));
            var hitDetails = JsonConvert.DeserializeObject<HitDetails>(hitDetailsObj.ToString());
            UpdateBoard(hitDetails);
        }

        private void readyButton_Click(object sender, EventArgs e)
        {
            bool isServerReady = _httpUtility.Post("api/server/SetPlayerAsReady", new PlayerReadyDetails(_client.Id, _game.GameId, _ships)).IsServerReady;
            if (!isServerReady)
            {
                MessageBox.Show("Waiting for other player to ready up...");

                placeShipButton.Enabled = false;
                readyButton.Enabled = false;
            }
        }

        private void placeShipButton_Click(object sender, EventArgs e)
        {
            string ship = comboBox1.SelectedItem.ToString();
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);

            Ship newShip = null;

            switch (ship)
            {
                case "One piece":
                    newShip = TryPlaceShip(gameBoardLeft, 1, x, y);
                    break;
                case "Two piece (horizontal)":
                    newShip = TryPlaceShip(gameBoardLeft, 2, x, y);
                    break;
                case "Two piece (vertical)":
                    newShip = TryPlaceShip(gameBoardLeft, 2, x, y, isVertical: true);
                    break;
                case "Three piece (vertical)":
                    newShip = TryPlaceShip(gameBoardLeft, 3, x, y, isVertical: true);
                    break;
                default:
                    MessageBox.Show("Invalid ship selection.");
                    break;
            }

            if (newShip != null)
            {
                _ships.Add(newShip);
                RemoveSelectedShipFromComboBox();
            }
        }

        private Ship TryPlaceShip(TableLayoutPanel gameBoard, int size, int x, int y, bool isVertical = false)
        {
            List<Coordinate> coordinates;
            if (gameBoard == gameBoardLeft)
                coordinates = _coordinatesLeft;
            else if (gameBoard == gameBoardRight)
                coordinates = _coordinatesRight;
            else
                throw new Exception("Invalid game board!");

            if (CanPlaceShip(coordinates, size, x, y, isVertical))
            {
                Ship newShip = new Ship(_client.Id, size, isVertical);
                PlaceShip(gameBoard, x, y, size, isVertical);

                newShip.AddCoordinate(x, y);
                coordinates.Add(new Coordinate(x, y));
                return newShip;
            }
            MessageBox.Show("Invalid ship location!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        private void PlaceShip(TableLayoutPanel gameBoard, int x, int y, int size, bool isVertical)
        {
            for (int i = 0; i < size; i++)
            {
                Button cellButton = new Button();
                cellButton.Text = "";
                cellButton.BackColor = Color.Navy; // TODO: Change to Color.Transparent when not testing
                cellButton.Tag = x + "_" + y;

                gameBoard.Invoke(new MethodInvoker(delegate { gameBoard.Controls.Add(cellButton, isVertical ? y - 1 : x - 1 + i, isVertical ? x - 1 + i : y - 1); }));
            }
        }

        private bool CanPlaceShip(List<Coordinate> coordinates, int size, int x, int y, bool isVertical = false)
        {
            for (int i = 0; i < size; i++)
            {
                int currentX = isVertical ? x : x + i;
                int currentY = isVertical ? y - i : y;

                if (currentX < 1 || currentX > 6 || currentY < 1 || currentY > 6)
                {
                    return false;
                }

                if (coordinates.Any(coord => coord.X == currentX && coord.Y == currentY))
                {
                    return false;
                }
            }
            return true;
        }


        private void RemoveSelectedShipFromComboBox()
        {
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
                else
                {
                    comboBox1.Enabled = false;
                    placeShipButton.Enabled = false;
                }
            }
        }

        public void InitializeBoard(List<Ship> otherPlayerShips)
        {
            if (otherPlayerShips.Count == 0)
            {
                MessageBox.Show("Failed to retrieve enemy ships!", "Error initializing board", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Because this method is called from another thread (inside Client), we need to use Invoke to access UI elements.
            placeShipButton.Invoke(new MethodInvoker(delegate { placeShipButton.Enabled = false; }));
            readyButton.Invoke(new MethodInvoker(delegate { readyButton.Visible = false; }));

            MessageBox.Show("Starting game!");

            // Populate gameBoardRight (other player's board)
            foreach (var ship in otherPlayerShips)
            {
                foreach (var coord in ship.Coordinates)
                {
                    int x = coord.X;
                    int y = coord.Y;
                    PlaceShip(gameBoardRight, x, y, ship.MaxHealth, ship.IsVertical);
                }
            }
            FillRemainingCells();
        }

        private void FillRemainingCells()
        {
            // Fill remaining empty grids in enemy board
            for (int i = 0; i < gameBoardRight.RowCount; i++)
            {
                for (int j = 0; j < gameBoardRight.ColumnCount; j++)
                {
                    if (gameBoardRight.GetControlFromPosition(j, i) == null)
                    {
                        Button cellButton = new Button();
                        cellButton.Text = "";
                        cellButton.BackColor = Color.Transparent;
                        cellButton.Tag = j + "_" + i; // x_y
                        gameBoardRight.Invoke(new MethodInvoker(delegate { gameBoardRight.Controls.Add(cellButton, j, i); }));
                    }
                }
            }

            foreach (Control cell in gameBoardRight.Controls)
            {
                cell.Click += new EventHandler(Cell_Click);
            }
        }

        public void UpdateBoard(HitDetails hitDetails)
        {
            if (hitDetails.Hit)
            {
                var hitGameBoard = gameBoardLeft;
                if (hitDetails.HitShip.PlayerId == _client.Id)
                {
                    MessageBox.Show($"You were hit!", "Hit!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show($"You hit the enemy!", "Hit!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hitGameBoard = gameBoardRight;
                }

                // Set button to red where the hit was
                foreach (Control cell in hitGameBoard.Controls)
                {
                    if (cell.Tag.ToString() == hitDetails.X + "_" + hitDetails.Y)
                    {
                        cell.BackColor = Color.Red;
                        cell.Enabled = false;
                        break;
                    }
                }
            }
            else
            {
                // TODO: show a message that the player (or enemy) missed, set turn to next player
            }
        }

        public void SetNextTurn(bool isMyTurn)
        {
            // TODO: update labels, disable/enable gameBoardRight buttons
            if (isMyTurn)
            {
                MessageBox.Show("It's your turn!");
            }
            else
            {
                MessageBox.Show("It's the enemy's turn!");
            }
        }
    }
}