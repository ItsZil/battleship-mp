using ClientApp.Utilities;
using SharedLibrary.Models;
using SharedLibrary.Models.Request_Models;

namespace ClientApp.Forms
{
    public partial class GameForm : Form
    {
        private static HttpUtility _httpUtility = new HttpUtility();
        private static Client _client;
        private static Game _game;

        private List<Ship> _ships = new List<Ship>();

        private List<Coordinate> coordinates = new List<Coordinate>();
        private List<Coordinate> usedCoords = new List<Coordinate>();
        public GameForm(Client client, Game game)
        {
            InitializeComponent();
            _client = client;
            _game = game;

            this.Text = $"Game: {game.Name} Game id: {game.GameId}";
            _client.RegisterGameFormEvents(this);
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            Control clickedCell = (Control)sender;

            string[] tagParts = clickedCell.Tag.ToString().Split('_'); // Tag are wrote like this tag = rowX_colY

            if (tagParts.Length == 2)
            {
                int row = int.Parse(tagParts[0]);
                int col = int.Parse(tagParts[1]);
            }

            label1.Text = tagParts[0] + " " + tagParts[1]; //for testing purposes, delete later.
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
                    newShip = TryPlaceShip(1, x, y);
                    break;
                case "Two piece (horizontal)":
                    newShip = TryPlaceShip(2, x, y);
                    break;
                case "Two piece (vertical)":
                    newShip = TryPlaceShip(2, x, y, isVertical: true);
                    break;
                case "Three piece (vertical)":
                    newShip = TryPlaceShip(3, x, y, isVertical: true);
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

        private Ship TryPlaceShip(int size, int x, int y, bool isVertical = false)
        {
            if (CanPlaceShip(size, x, y, isVertical))
            {
                Ship newShip = new Ship(_client.Id, size);

                for (int i = 0; i < size; i++)
                {
                    Button cellButton = new Button();
                    cellButton.Text = "";
                    cellButton.BackColor = Color.Transparent;

                    if (!isVertical)
                        cellButton.Tag = y + i + "_" + x;
                    else
                        cellButton.Tag = y + "_" + (x - i);

                    gameBoard1.Controls.Add(cellButton, isVertical ? y - 1 : x - 1 + i, isVertical ? x - 1 + i : y - 1);
                    newShip.AddCoordinate(isVertical ? x - 1 + i : x - 1, isVertical ? y - 1 : y - 1 + i);
                    coordinates.Add(new Coordinate(isVertical ? x + i : x, isVertical ? y : y + i));
                }
                return newShip;
            }

            MessageBox.Show("Invalid ship location!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        private bool CanPlaceShip(int size, int x, int y, bool isVertical = false)
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

        public void InitializeBoard()
        {
            // Because this method is called from another thread (inside Client), we need to use Invoke to access UI elements.
            placeShipButton.Invoke(new MethodInvoker(delegate { placeShipButton.Enabled = false; }));
            readyButton.Invoke(new MethodInvoker(delegate { readyButton.Visible = false; }));

            MessageBox.Show("Starting game!");

            for (int i = 1; i < 7; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    Button cellButton = new Button();
                    cellButton.Text = "";
                    cellButton.BackColor = Color.Transparent;
                    cellButton.Tag = j + "_" + i;

                    // Use Invoke to add the cellButton to the gameBoard2 (UI operation)
                    gameBoard2.Invoke(new Action(() =>
                    {
                        gameBoard2.Controls.Add(cellButton, i - 1, j - 1);
                    }));
                }
            }

            foreach (Control cell in gameBoard1.Controls)
            {
                cell.Click += new EventHandler(Cell_Click);
            }
        }
    }
}
