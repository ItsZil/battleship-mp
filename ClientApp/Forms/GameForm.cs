﻿using Newtonsoft.Json;
using SharedLibrary.Models;
using SharedLibrary.Models.Request_Models;
using SharedLibrary.Structs;
using SharedLibrary.Models.Builders;
using SharedLibrary.Models.Levels;
using SharedLibrary.Interfaces;
using ClientApp.Obstacles.Bridge;
using ClientApp.Obstacles.Flyweigth;
using ClientApp.State;
using ClientApp.State.States;
using ClientApp.Memento;
using SharedLibrary.Interpreter;

namespace ClientApp.Forms
{
    public partial class GameForm : Form
    {
        private static Client _client;
        private static Game _game;
        private readonly UIManager uiManager = new();

        private Radar _radar;
        private List<Ship> _ships = new List<Ship>();
        private List<Obstacle> _obstacles = new List<Obstacle>();
        private List<Coordinate> _coordinatesLeft = new List<Coordinate>(); // Left side game board, current player
        private List<Coordinate> _coordinatesRight = new List<Coordinate>(); // Right side game board, other player

        private Dictionary<Button, Ship> _playerShipbuttons = new Dictionary<Button, Ship>();
        private List<ShipGroup> shipGroups = new List<ShipGroup>();

        private ILogger _logger;

        private bool isMyTurn = false;
        private bool isPlayingPhase = false;

        private ShipPlacementOriginator _shipPlacementOriginator = new ShipPlacementOriginator();
        private ShipPlacementCaretaker _shipPlacementCaretaker = new ShipPlacementCaretaker();

        public GameForm(Client client, int gameId, string gameLevel)
        {
            InitializeComponent();

            _client = client;
            _logger = new ServerLoggerAdapter(client);

            this.HandleCreated += GameForm_HandleCreated;

            object gameObj = _client.SendMessage("GetGameById", gameId);

            switch (gameLevel)
            {
                case "Basic Level":
                    _game = _game = JsonConvert.DeserializeObject<BasicGame>(gameObj.ToString());
                    break;
                case "Enhanced Level":
                    _game = _game = JsonConvert.DeserializeObject<EnhancedGame>(gameObj.ToString());
                    break;
                case "Advanced Level":
                    _game = JsonConvert.DeserializeObject<AdvancedGame>(gameObj.ToString());
                    break;
                case "Expert Level":
                    _game = _game = JsonConvert.DeserializeObject<ExpertGame>(gameObj.ToString());
                    break;
                default:
                    throw new Exception("Invalid game level!");
            }

            Text = $"Game: {_game.Name} Game ID: {_game.GameId} Player ID: {client.Id}";
            shipGroupComboBox.SelectedIndex = 0;
            _client.RegisterGameFormEvents(this);

            RemoveUnallowedShipSizes();
        }

        private void RemoveUnallowedShipSizes()
        {
            shipPlacementTypeComboBox.SelectedIndex = 0;

            if (!_game.SupportsAllShips)
            {
                // Only allow the first (one piece) ship type
                for (int i = shipPlacementTypeComboBox.Items.Count - 1; i > 0; i--)
                {
                    shipPlacementTypeComboBox.Items.RemoveAt(i);
                }
            }
        }

        public Ship GetShipByCoordinates(int x, int y)
        {
            List<Ship> ships = _game.GetAllShips();
            foreach (Ship ship in ships)
            {
                foreach (Coordinate coord in ship.Coordinates)
                {
                    if (coord.X == x && coord.Y == y)
                        return ship;
                }
            }
            return null;

        }

        public void LeftCell_Click(object sender, EventArgs e)
        {
            if (!isMyTurn)
                return;

            Control clickedCell = (Control)sender;
            string[] tagParts = clickedCell.Tag.ToString().Split('_'); // x_y

            int x = int.Parse(tagParts[0]);
            int y = int.Parse(tagParts[1]);


            Ship ship = GetShipByCoordinates(x, y);

            new DecorationsForm(ship).Show();

        }

        private async void Cell_Click(object sender, EventArgs e)
        {
            if (!isMyTurn)
                return;

            Control clickedCell = (Control)sender;
            string[] tagParts = clickedCell.Tag.ToString().Split('_'); // x_y

            int x = int.Parse(tagParts[0]);
            int y = int.Parse(tagParts[1]);

            if (shootModeRadioButton.Checked)
            {
                Shot shot = new Shot(_game.GameId, _client.Id, x, y, 1);
                if (shootAsGroupCheckBox.Checked)
                {
                    int group = int.Parse(shipGroupComboBox.SelectedItem.ToString());
                    ShipGroup shipGroup = shipGroups.First(shipGroup => shipGroup.Group == group);
                    HitDetails hitDetails = shipGroup.SendShot(shot);

                    if (!hitDetails.ShotHappened)
                    {
                        MessageBox.Show("Selected ship group has run out of shots!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show($"Remaining ship group ({shipGroup.Group}) shots: {shipGroup.RemainingShots}", $"Group update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateBoard(hitDetails, isShooter: true);
                }
                else
                {
                    object hitDetailsObj = await _client.SendMessageAsync("SendShot", shot);
                    HitDetails hitDetails = JsonConvert.DeserializeObject<HitDetails>(hitDetailsObj.ToString());
                    UpdateBoard(hitDetails, isShooter: true);
                }
            }
            else if (placeRadarModeRadioButton.Checked)
            {
                object allGameShipsObj = await _client.SendMessageAsync("GetAllGameShips", _game.GameId);
                var allGameShips = JsonConvert.DeserializeObject<List<Ship>>(allGameShipsObj.ToString());

                _coordinatesRight = allGameShips.Select(ship => ship)
                .Where(ship => ship.PlayerId != _client.Id)
                .SelectMany(ship => ship.Coordinates)
                .ToList();

                //TODO: send radar coordinates to enemy
                Radar radar = TryPlaceRadar(gameBoardRight, x, y);

                MessageBox.Show("Radar placed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _logger.LogInfo("Radar Placed!");



                if (radar != null)
                {
                    _radar = radar;
                }
            }
        }

        private void readyButton_Click(object sender, EventArgs e)
        {
            if (_ships.Count == 0)
            {
                MessageBox.Show("You must place at least one ship!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _logger.LogWarning("You must place at least one ship!");
                return;
            }

            shipPlacementTypeComboBox.Enabled = false;

            PlayerReadyDetails playerReadyDetails = new PlayerReadyDetails(_client.Id, _game.GameId, _ships);
            object isServerReadyObj = _client.SendMessage("SetPlayerAsReady", playerReadyDetails);
            bool isServerReady = JsonConvert.DeserializeObject<bool>(isServerReadyObj.ToString().ToLower());

            if (!isServerReady)
            {
                MessageBox.Show("Waiting for other player to ready up...");
            }
            placeShipButton.Enabled = false;
            readyButton.Enabled = false;
            placeShipButton.Visible = false;
            readyButton.Visible = false;
            AvailableShipsLabel.Visible = false;
            EnterStartingCoordsLabel.Visible = false;
            shipPlacementTypeComboBox.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            RemoveInvalidShipGroups();
        }

        private void placeShipButton_Click(object sender, EventArgs e)
        {
            string shipName = shipPlacementTypeComboBox.SelectedItem.ToString();
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);

            HandleShipPlacement(shipName, x, y);
        }

        public void HandleShipPlacement(string shipName, int x, int y)
        {
            Ship newShip = null;
            switch (shipName)
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
                _shipPlacementOriginator.SetState(_ships);
                _shipPlacementCaretaker.AddState(_shipPlacementOriginator.CreateMemento());
                _ships.Add(newShip);
                _shipPlacementOriginator.SetState(_ships);
                _shipPlacementCaretaker.AddState(_shipPlacementOriginator.CreateMemento());
                RemoveSelectedShipFromComboBox(); // TODO: allow multiple ships of same type
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
                var shipCoordinates = CreateShipCoordinates(size, x, y, isVertical);
                var shipBuilder = new ShipBuilder();
                var newShip = shipBuilder.Build(_client.Id)
                    .AddHealth(size, isVertical)
                    .AddCoordinates(shipCoordinates)
                    .AddCannons(size)
                    .Get();

                newShip.Group = int.Parse(shipGroupComboBox.SelectedItem.ToString());
                if (shipGroups.Any(shipGroup => shipGroup.Group == newShip.Group))
                {
                    shipGroups.First(shipGroup => shipGroup.Group == newShip.Group).Add(newShip);
                }
                else
                {
                    ShipGroup shipGroup = new ShipGroup(newShip.Group, _client);
                    shipGroup.Add(newShip);
                    shipGroups.Add(shipGroup);
                }

                PlaceShip(gameBoard, shipCoordinates, newShip);

                coordinates.AddRange(shipCoordinates);
                return newShip;
            }
            MessageBox.Show("Invalid ship location!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        private void PlaceShip(TableLayoutPanel gameBoard, List<Coordinate> shipCoordinates, Ship ship = null)
        {
            foreach (var coordinate in shipCoordinates)
            {
                Button cellButton = new Button();
                cellButton.Text = "";
                cellButton.BackColor = ButtonColors.Ship; // TODO: Change to ButtonColors.Empty when not testing (unless gameBoard is left)
                cellButton.Tag = coordinate.X + "_" + coordinate.Y;
                cellButton.Margin = new Padding(0);
                cellButton.Size = new Size(50, 50);

                gameBoard.Invoke(new MethodInvoker(delegate { gameBoard.Controls.Add(cellButton, coordinate.X, coordinate.Y); }));
                if (ship != null)
                {
                    _playerShipbuttons.Add(cellButton, ship);
                }
            }
        }

        private bool CanPlaceShip(List<Coordinate> coordinates, int size, int x, int y, bool isVertical = false)
        {
            for (int i = 0; i < size; i++)
            {
                int currentX = isVertical ? x : x + i;
                int currentY = isVertical ? y - i : y;

                if (currentX < 0 || currentX > 6 || currentY < 1 || currentY > 6)
                {
                    return false;
                }

                if (coordinates.Any(coord => coord.X == currentX && coord.Y == currentY))
                {
                    return false;
                }

                if (_obstacles.Any(obstacle => obstacle.coordinate.X == currentX && obstacle.coordinate.Y == currentY))
                {
                    return false;
                }
            }
            return true;
        }

        private void RemoveShip(TableLayoutPanel gameBoard, List<Coordinate> shipCoordinates)
        {
            foreach (var coordinate in shipCoordinates)
            {
                foreach (Control cell in gameBoard.Controls)
                {
                    if (cell.Tag != null && cell.Tag.ToString() == coordinate.X + "_" + coordinate.Y)
                    {
                        gameBoard.Controls.Remove(cell);
                        cell.Dispose();
                        break;
                    }
                }
            }
            if (_playerShipbuttons.Count > 0)
            {
                var shipButton = _playerShipbuttons.First(shipButton => shipButton.Value.Coordinates == shipCoordinates).Key;
                _playerShipbuttons.Remove(shipButton);
            }
        }

        private List<Coordinate> CreateShipCoordinates(int size, int x, int y, bool isVertical)
        {
            List<Coordinate> coordinates = new List<Coordinate>();
            for (int i = 0; i < size; i++)
            {
                var column = isVertical ? x - 1 : x + i - 1;
                var row = isVertical ? y + i - 1 : y - 1;
                var coordinate = new Coordinate(column, row);

                coordinates.Add(coordinate);
            }

            return coordinates;
        }

        private void RemoveSelectedShipFromComboBox()
        {
            if (shipPlacementTypeComboBox.Items.Count > 0)
            {
                shipPlacementTypeComboBox.Items.RemoveAt(shipPlacementTypeComboBox.SelectedIndex);
                if (shipPlacementTypeComboBox.Items.Count > 0)
                    shipPlacementTypeComboBox.SelectedIndex = 0;
                else
                {
                    shipPlacementTypeComboBox.Enabled = false;
                    placeShipButton.Enabled = false;
                }
            }
        }

        private Radar TryPlaceRadar(TableLayoutPanel gameBoard, int x, int y)
        {
            List<Coordinate> coordinates;
            if (gameBoard == gameBoardLeft)
                coordinates = _coordinatesLeft;
            else if (gameBoard == gameBoardRight)
                coordinates = _coordinatesRight;
            else
                throw new Exception("Invalid game board!");

            if (CanPlaceRadar(coordinates, x, y))
            {
                var radarBuilder = new RadarBuilder();
                var newRadar = radarBuilder.Build(_client.Id)
                    .AddCoordinate(x, y)
                    .AddHealth()
                    .Get();

                //PlaceRadar(gameBoard, new Coordinate(x, y));

                coordinates.Add(new Coordinate(x, y));
                return newRadar;
            }
            MessageBox.Show("Invalid radar location!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        private bool CanPlaceRadar(List<Coordinate> coordinates, int x, int y)
        {
            if (x < 1 || x > 6 || y < 1 || y > 6)
            {
                return false;
            }

            if (coordinates.Any(coord => coord.X == x && coord.Y == y))
            {
                return false;
            }

            if (_obstacles.Any(obstacle => obstacle.coordinate.X == x && obstacle.coordinate.Y == y))
            {
                return false;
            }

            return true;
        }

        private static void PlaceRadar(TableLayoutPanel gameBoard, Coordinate radarCoordinates)
        {
            Button cellButton = new()
            {
                Text = "radar",
                BackColor = ButtonColors.Radar,
                Tag = radarCoordinates.X + "_" + radarCoordinates.Y
            };

            gameBoard.Invoke(new MethodInvoker(delegate { gameBoard.Controls.Add(cellButton, radarCoordinates.X, radarCoordinates.Y); }));
        }

        private void InitializeInteractionElements()
        {
            // Enables or disables certain form elements that are not used in all game levels.
            if (_game.SupportsMovingShips || _game.SupportsRadars)
            {
                // If either of these are true, we can enable mode selector buttons, as well as the remaining special move counts.
                interactionModeTableLayoutPanel.Invoke(new MethodInvoker(delegate
                {
                    interactionModeTableLayoutPanel.Visible = true;
                    shootModeRadioButton.CheckedChanged += RadioButton_CheckedChanged;
                    moveShipModeRadioButton.CheckedChanged += RadioButton_CheckedChanged;
                    placeRadarModeRadioButton.CheckedChanged += RadioButton_CheckedChanged;
                }));

                remainingItemTableLayoutPanel.Invoke(new MethodInvoker(delegate
                {
                    remainingItemTableLayoutPanel.Visible = true;
                }));
            }

            if (!_game.SupportsRadars)
            {
                // If radars are not allowed, remove the radar button as well as the count.
                placeRadarModeRadioButton.Invoke(new MethodInvoker(delegate
                {
                    placeRadarModeRadioButton.Enabled = false;
                    placeRadarModeRadioButton.Visible = false;
                    interactionModeTableLayoutPanel.RowCount--;

                    remainingRadarTextLabel.Visible = false;
                    remainingRadarCountLabel.Visible = false;
                    remainingItemTableLayoutPanel.RowCount--;
                }));
            }

            shootAsGroupCheckBox.Invoke(new MethodInvoker(delegate
            {
                shootAsGroupCheckBox.Visible = true;
                shootAsGroupCheckBox.Enabled = true;
                shootAsGroupLabel.Visible = true;
                shootAsGroupLabel.Enabled = true;
            }));
        }

        public void InitializeBoard(List<Ship> otherPlayerShips, string firstTurnPlayerId)
        {
            InitializeInteractionElements();

            if (otherPlayerShips.Count == 0)
            {
                MessageBox.Show("Failed to retrieve enemy ships!", "Error initializing board", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Because this method is called from another thread (inside Client), we need to use Invoke to access UI elements.
            placeShipButton.Invoke(new MethodInvoker(delegate { placeShipButton.Enabled = false; }));
            readyButton.Invoke(new MethodInvoker(delegate { readyButton.Visible = false; }));
            shipPlacementMemento_Undo.Invoke(new MethodInvoker(delegate { shipPlacementMemento_Undo.Visible = false; }));
            shipPlacementMemento_Redo.Invoke(new MethodInvoker(delegate { shipPlacementMemento_Redo.Visible = false; }));
            SetNextTurn(firstTurnPlayerId);

            // Populate gameBoardRight (other player's board)
            foreach (var ship in otherPlayerShips)
            {
                PlaceShip(gameBoardRight, ship.Coordinates);
            }
            FillRemainingCells();
            isPlayingPhase = true;
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

            foreach (Control cell in gameBoardLeft.Controls)
            {
                cell.Click += new EventHandler(LeftCell_Click);
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
                    message = $"You were hit for {hitDetails.Damage} damage!";
                    caption = "Hit!";
                    icon = MessageBoxIcon.Exclamation;
                }
                else
                {
                    message = $"You hit the enemy for {hitDetails.Damage} damage!";
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
                ColorSunkShip(shotGameBoard, hitDetails.HitShip);
            }
            else
            {
                cell.BackColor = ButtonColors.Miss;
            }
            MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
            cell.Enabled = false;
        }

        private void ColorSunkShip(TableLayoutPanel gameBoard, Ship ship)
        {
            foreach (var coordinate in ship.Coordinates)
            {
                foreach (Control cell in gameBoard.Controls)
                {
                    if (cell?.Tag?.ToString() == coordinate.X + "_" + coordinate.Y)
                        cell.BackColor = ButtonColors.Sunk;
                }
            }
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

        #region Prototype pattern methods
        private void InitializeTemplateShips()
        {
            foreach (Ship ship in _game.Ships)
            {
                if (ship.PlayerId == _client.Id)
                {
                    TryPlaceShip(gameBoardLeft, ship.MaxHealth, ship.Coordinates[0].X, ship.Coordinates[0].Y, ship.IsVertical);
                    _ships.Add(ship);
                }
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            InitializeTemplateShips();
        }
        #endregion

        private void GameForm_HandleCreated(object sender, EventArgs e)
        {
            GenerateRandomObstacles();
        }

        private void GenerateRandomObstacles()
        {
            Random random = new();
            ObstacleImageFactory imageFactory = new();

            int totalObstacles = random.Next(1, 5);

            for (int i = 0; i < totalObstacles; i++)
            {
                int x = random.Next(5);
                int y = random.Next(5);

                Obstacle obstacle;
                ObstacleColor obstacleColor;

                if (random.Next(2) == 0)
                {
                    obstacleColor = new BrownObstacleColor();
                }
                else
                {
                    obstacleColor = new GreenObstacleColor();
                }

                if (random.Next(2) == 0)
                {
                    IObstacleImage icebergImage = imageFactory.GetObstacleImage("Images/iceberg.jpg");
                    obstacle = new IceBerg(obstacleColor, icebergImage);
                }
                else
                {
                    IObstacleImage islandImage = imageFactory.GetObstacleImage("Images/island.jpg");
                    obstacle = new Island(obstacleColor, islandImage);
                }

                Button cellButton = new()
                {
                    Enabled = false,
                    Size = new Size(50, 50),
                    Margin = new Padding(0)
                };
                obstacle.coordinate = new Coordinate(x + 1, y + 1);
                obstacle.ApplyStyle(cellButton);

                _obstacles.Add(obstacle);
                gameBoardLeft.Invoke(new MethodInvoker(delegate { gameBoardLeft.Controls.Add(cellButton, x, y); }));
            }
        }

        private void RemoveInvalidShipGroups()
        {
            List<int> groups = _ships.Select(ship => ship.Group).Distinct().ToList();
            for (int i = shipGroupComboBox.Items.Count - 1; i >= 0; i--)
            {
                if (!groups.Contains(int.Parse(shipGroupComboBox.Items[i].ToString())))
                {
                    shipGroupComboBox.Items.RemoveAt(i);
                }
            }
        }

        private void shipGroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isPlayingPhase)
            {
                int group = int.Parse(shipGroupComboBox.SelectedItem.ToString());
                SetGroupButtonBorders(group);
            }
        }

        private void shootAsGroupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (shootAsGroupCheckBox.Checked)
            {
                shipGroupComboBox.Enabled = true;
                int group = int.Parse(shipGroupComboBox.SelectedItem.ToString());
                SetGroupButtonBorders(group);
            }
            else
            {
                shipGroupComboBox.Enabled = false;
                SetGroupButtonBorders(0); // Turn off all borders
            }
        }

        private void SetGroupButtonBorders(int group)
        {
            foreach (var shipButton in _playerShipbuttons)
            {
                if (shipButton.Value.Group == group)
                {
                    shipButton.Key.FlatStyle = FlatStyle.Flat;
                    shipButton.Key.FlatAppearance.BorderColor = Color.SeaGreen;
                    shipButton.Key.FlatAppearance.BorderSize = 2;
                }
                else
                {
                    shipButton.Key.FlatStyle = FlatStyle.Standard;
                    shipButton.Key.FlatAppearance.BorderSize = 0;
                }
            }
        }

        public void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            List<Control> enableList = new();
            List<Control> disableList = new();

            if (sender is RadioButton radioButton && radioButton.Checked)
            {
                switch (radioButton.Name)
                {
                    case "moveShipModeRadioButton":
                        enableList = new List<Control>
                        {
                            remainingMoveShipsTextLabel,
                            remainingMoveShipsCountLabel
                        };
                        disableList = new List<Control>
                        {
                            remainingRadarTextLabel,
                            remainingRadarCountLabel,
                            shootAsGroupLabel,
                            groupLabel,
                            shipGroupComboBox,
                            shootAsGroupCheckBox
                        };
                        uiManager.SetState(new MoveActionState());
                        break;

                    case "shootModeRadioButton":
                        enableList = new List<Control>
                        {
                            shootAsGroupLabel,
                            groupLabel,
                            shipGroupComboBox,
                            shootAsGroupCheckBox
                        };
                        disableList = new List<Control>
                        {
                            remainingMoveShipsTextLabel,
                            remainingMoveShipsCountLabel,
                            remainingRadarTextLabel,
                            remainingRadarCountLabel
                        };
                        uiManager.SetState(new ShootActionState());
                        break;

                    case "placeRadarModeRadioButton":
                        enableList = new List<Control>
                        {
                            remainingRadarTextLabel,
                            remainingRadarCountLabel
                        };
                        disableList = new List<Control>
                        {
                            remainingMoveShipsTextLabel,
                            remainingMoveShipsCountLabel,
                            shootAsGroupLabel,
                            groupLabel,
                            shipGroupComboBox,
                            shootAsGroupCheckBox
                        };
                        uiManager.SetState(new PlaceRadarActionState());
                        break;
                }
                uiManager.Disable(disableList);
                uiManager.Enable(enableList);
            }
        }

        private void shipPlacementMemento_Undo_Click(object sender, EventArgs e)
        {
            int mementoCount = _shipPlacementCaretaker.GetMementoCount();
            if (mementoCount > 0)
            {
                ShipPlacementMemento undoState = _shipPlacementCaretaker.GetState(mementoCount - 2);
                _shipPlacementOriginator.RestoreFromMemento(undoState);

                if (_ships.Count > 0)
                {
                    var lastShip = _ships.Last();
                    _ships = undoState.GetState();

                    RemoveShip(gameBoardLeft, lastShip.Coordinates);
                }
            }
        }

        private void shipPlacementMemento_Redo_Click(object sender, EventArgs e)
        {
            int mementoCount = _shipPlacementCaretaker.GetMementoCount();
            if (mementoCount > 0)
            {
                ShipPlacementMemento redoState = _shipPlacementCaretaker.GetState(mementoCount - 1);
                _shipPlacementOriginator.RestoreFromMemento(redoState);

                var oldShips = _ships;
                _ships = redoState.GetState();
                if (_ships.Count > 0)
                {
                    var lastShip = _ships.Last();
                    if (!oldShips.Select(ship => ship.Coordinates).Contains(lastShip.Coordinates))
                        PlaceShip(gameBoardLeft, lastShip.Coordinates, lastShip);
                }
            }
        }

        private void ConsoleTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string command = ConsoleTextBox.Text;
                var parts = command.Split(" ").ToList();
                if (parts[0] == "place")
                {
                    parts.RemoveAt(0);
                    IExpression placeShipExpression = new PlaceShipExpression();

                    string shipName = shipPlacementTypeComboBox.SelectedItem.ToString();
                    parts.Add(shipName);
                    
                    var args = placeShipExpression.Interpret(parts);

                    HandleShipPlacement(args[2], int.Parse(args[0]), int.Parse(args[1]));
                }

                ConsoleTextBox.Clear();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}