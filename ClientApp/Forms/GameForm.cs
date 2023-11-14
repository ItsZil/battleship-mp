using Newtonsoft.Json;
using SharedLibrary.Models;
using SharedLibrary.Models.Request_Models;
using SharedLibrary.Structs;
using SharedLibrary.Models.Builders;
using SharedLibrary.Models.Levels;
using SharedLibrary.Interfaces;
using SharedLibrary.Models.Obstacles;

namespace ClientApp.Forms
{
    public partial class GameForm : Form
    {
        private static Client _client;
        private static Game _game;

        private Radar _radar;
        private List<Ship> _ships = new List<Ship>();
        private List<Obstacle> _obstacles = new List<Obstacle>();
        private List<Coordinate> _coordinatesLeft = new List<Coordinate>(); // Left side game board, current player
        private List<Coordinate> _coordinatesRight = new List<Coordinate>(); // Right side game board, other player

        private ILogger _logger;
        private IUiInvoker _uiInvoker;

        private bool isMyTurn = false;

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
            _client.RegisterGameFormEvents(this);
            _uiInvoker = new UiInvoker();

            RemoveUnallowedShipSizes();
        }

        public GameForm(Client client, IUiInvoker uiInvoker)
        {
            _client = client;
            _uiInvoker = uiInvoker;
        }

        public void SetGameBoards(TableLayoutPanel left, TableLayoutPanel right)
        {
            gameBoardLeft = left;
            gameBoardRight = right;
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
                foreach(Coordinate coord in ship.Coordinates)
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
                object hitDetailsObj = await _client.SendMessageAsync("SendShot", new Shot(_game.GameId, _client.Id, x, y, 1));
                var hitDetails = JsonConvert.DeserializeObject<HitDetails>(hitDetailsObj.ToString());
                UpdateBoard(hitDetails, isShooter: true);
            }
            else if (placeRadarModeButton.Checked)
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

                placeShipButton.Enabled = false;
                readyButton.Enabled = false;
            }
        }

        private void placeShipButton_Click(object sender, EventArgs e)
        {
            string ship = shipPlacementTypeComboBox.SelectedItem.ToString();
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
                RemoveSelectedShipFromComboBox(); // TODO: allow multiple ships of same type
            }
        }

        public Ship TryPlaceShip(TableLayoutPanel gameBoard, int size, int x, int y, bool isVertical = false)
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

                PlaceShip(gameBoard, shipCoordinates);

                coordinates.AddRange(shipCoordinates);
                return newShip;
            }
            MessageBox.Show("Invalid ship location!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        private void PlaceShip(TableLayoutPanel gameBoard, List<Coordinate> shipCoordinates)
        {
            foreach (var coordinate in shipCoordinates)
            {
                Button cellButton = new Button();
                cellButton.Text = "";
                cellButton.BackColor = ButtonColors.Ship; // TODO: Change to ButtonColors.Empty when not testing (unless gameBoard is left)
                cellButton.Tag = coordinate.X + "_" + coordinate.Y;
                
                Action action = () => gameBoard.Controls.Add(cellButton, coordinate.X, coordinate.Y);
                _uiInvoker.InvokeOnUIThread(action, gameBoard);
                //gameBoard.Invoke(new MethodInvoker(delegate { gameBoard.Controls.Add(cellButton, coordinate.X, coordinate.Y); }));
            }
        }

        private bool CanPlaceShip(List<Coordinate> coordinates, int size, int x, int y, bool isVertical = false)
        {
            for (int i = 0; i < size; i++)
            {
                int currentX = isVertical ? x - 1 : x + i - 1;
                int currentY = isVertical ? y + i - 1 : y - 1;

                if (currentX < 0 || currentX > 6 || currentY < 0 || currentY > 6)
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
                }));

                remainingItemTableLayoutPanel.Invoke(new MethodInvoker(delegate
                {
                    remainingItemTableLayoutPanel.Visible = true;
                }));
            }

            if (!_game.SupportsRadars)
            {
                // If radars are not allowed, remove the radar button as well as the count.
                placeRadarModeButton.Invoke(new MethodInvoker(delegate
                {
                    placeRadarModeButton.Enabled = false;
                    placeRadarModeButton.Visible = false;
                    interactionModeTableLayoutPanel.RowCount--;

                    remainingRadarTextLabel.Visible = false;
                    remainingRadarCountLabel.Visible = false;
                    remainingItemTableLayoutPanel.RowCount--;
                }));
            }
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
            SetNextTurn(firstTurnPlayerId);

            // Populate gameBoardRight (other player's board)
            foreach (var ship in otherPlayerShips)
            {
                PlaceShip(gameBoardRight, ship.Coordinates);
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

            foreach(Control cell in gameBoardLeft.Controls)
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
                    obstacle = new IceBerg(obstacleColor);
                }
                else
                {
                    obstacle = new Island(obstacleColor);
                }

                Button cellButton = new();
                cellButton.Enabled = false;
                obstacle.coordinate = new Coordinate(x+1, y+1);
                obstacle.ApplyStyle(cellButton);

                _obstacles.Add(obstacle);
                gameBoardLeft.Invoke(new MethodInvoker(delegate { gameBoardLeft.Controls.Add(cellButton, x, y); }));
            }
        }
    }
}