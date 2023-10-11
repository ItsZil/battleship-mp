﻿using Newtonsoft.Json;
using SharedLibrary.Events;
using SharedLibrary.Models;
using SharedLibrary.Models.Request_Models;
using SharedLibrary.Structs;
using SharedLibrary.Factories;

namespace ClientApp.Forms
{
    public partial class GameForm : Form
    {
        private static Client _client;
        private static Game _game;

        private List<Ship> _ships = new List<Ship>();
        private List<Coordinate> _coordinatesLeft = new List<Coordinate>(); // Left side game board, current player
        private List<Coordinate> _coordinatesRight = new List<Coordinate>(); // Right side game board, other player

        private ShipFactory shipFactory = new ShipFactory();

        private bool isMyTurn = false;

        public GameForm(Client client, int gameId)
        {
            InitializeComponent();
            _client = client;
            
            object gameObj = _client.SendMessage("GetGameById", gameId);
            _game = JsonConvert.DeserializeObject<Game>(gameObj.ToString());

            Text = $"Game: {_game.Name} Game ID: {_game.GameId} Player ID: {client.Id}";
            _client.RegisterGameFormEvents(this);
        }

        private async void Cell_Click(object sender, EventArgs e)
        {
            if (!isMyTurn)
                return;
            
            Control clickedCell = (Control)sender;
            string[] tagParts = clickedCell.Tag.ToString().Split('_'); // x_y

            int x = int.Parse(tagParts[0]);
            int y = int.Parse(tagParts[1]);

            object hitDetailsObj = await _client.SendMessageAsync("SendShot", new Shot(_game.GameId, _client.Id, x, y, 1));
            var hitDetails = JsonConvert.DeserializeObject<HitDetails>(hitDetailsObj.ToString());
            UpdateBoard(hitDetails, isShooter: true);
        }

        private void readyButton_Click(object sender, EventArgs e)
        {
            PlayerReadyDetails playerReadyDetails = new PlayerReadyDetails(_client.Id, _game.GameId, _ships);
            object isServerReadyObj = _client.SendMessage("SetPlayerAsReady", playerReadyDetails);
            bool isServerReady = JsonConvert.DeserializeObject<bool>(isServerReadyObj.ToString().ToLower());
            
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
                Ship newShip = shipFactory.CreateShip(_client.Id, size, isVertical); ;
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
                cellButton.BackColor = ButtonColors.Ship; // TODO: Change to ButtonColors.Empty when not testing (unless gameBoard is left)
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

        public void InitializeBoard(List<Ship> otherPlayerShips, string firstTurnPlayerId)
        {   
            if (otherPlayerShips.Count == 0)
            {
                MessageBox.Show("Failed to retrieve enemy ships!", "Error initializing board", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Because this method is called from another thread (inside Client), we need to use Invoke to access UI elements.
            placeShipButton.Invoke(new MethodInvoker(delegate { placeShipButton.Enabled = false; }));
            readyButton.Invoke(new MethodInvoker(delegate { readyButton.Visible = false; }));
            SetNextTurn(firstTurnPlayerId);

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
                        cellButton.BackColor = ButtonColors.Empty;
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

        private Control GetCellByCoords(TableLayoutPanel gameBoard, int x, int y)
        {
            foreach (Control cell in gameBoard.Controls)
            {
                if (cell.Tag.ToString() == x + "_" + y)
                    return cell;
            }
            return null;
        }

        public void UpdateBoard(HitDetails hitDetails, bool isShooter = false)
        {
            var shotGameBoard = isShooter ? gameBoardRight : gameBoardLeft;
            var cell = GetCellByCoords(shotGameBoard, hitDetails.X, hitDetails.Y);

            string message = isShooter ? "You missed!" : "The enemy missed!";
            string caption = "Miss!";
            MessageBoxIcon icon = MessageBoxIcon.Information;

            if (hitDetails.Hit)
            {
                if (!isShooter)
                {
                    message = "You were hit!";
                    caption = "Hit!";
                    icon = MessageBoxIcon.Exclamation;
                }
                else
                {
                    message = "You hit the enemy!";
                    caption = "Hit!";
                }
                cell.BackColor = ButtonColors.Hit;
            }
            else if (hitDetails.Sunk)
            {
                if (!isShooter)
                {
                    message = "Your ship was sunk!";
                    caption = "Sunk!";
                    icon = MessageBoxIcon.Exclamation;
                }
                else
                {
                    message = "You sunk an enemy ship!";
                    caption = "Sunk!";
                }
                cell.BackColor = ButtonColors.Sunk;
            }
            else
            {
                cell.BackColor = ButtonColors.Miss;
            }
            MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
            cell.Enabled = false;
        }

        /// <summary>
        /// Called by GameHub.SendShot to update whose turn is next.
        /// </summary>
        /// <param name="nextTurnPlayerId">The player's whose turn is next ID</param>
        public void SetNextTurn(string nextTurnPlayerId)
        {
            // isMyTurn determines whether button clicks are handled.
            // Use invoke because this might not always be triggered by the UI thread.
            isMyTurn = nextTurnPlayerId == _client.Id;
            
            if (isMyTurn)
            {
                turnIndicatorLabel.Invoke(new MethodInvoker(delegate { turnIndicatorLabel.Text = "Your Turn"; }));
            }
            else
            {
                turnIndicatorLabel.Invoke(new MethodInvoker(delegate { turnIndicatorLabel.Text = "Enemy's Turn"; }));
            }
        }
    }
}