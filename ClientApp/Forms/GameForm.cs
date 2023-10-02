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

            Ship newShip = new Ship();
            switch (ship)
            {
                case "One piece":
                    usedCoords.Clear();
                    usedCoords.Add(new Coordinate(x, y));
                    
                    if(x<6 && y<6 && x>0 && y>0)
                    {
                        if(!DoesContains(coordinates, usedCoords))
                        {
                            newShip = new Ship(_client.Id, 1);
                            Button cellButton = new Button();
                            cellButton.Text = "";
                            cellButton.BackColor = Color.Transparent;
                            cellButton.Tag = y + "_" + x;
                            gameBoard1.Controls.Add(cellButton, y - 1, x - 1);
                            comboBox1.Items.Remove("One piece");
                            newShip.AddCoordinate(x - 1, y - 1);
                            coordinates.Add(new Coordinate(x, y));

                            if (comboBox1.Items.Count > 0)
                                comboBox1.SelectedIndex = 0;
                            else
                                comboBox1.Enabled = false;
                            break;
                        }
                    }
                    MessageBox.Show("Invalid Location.");
                    break;
                    
                case "Two piece (horizontal)":
                    usedCoords.Clear();
                    usedCoords.Add(new Coordinate(x, y));
                    usedCoords.Add(new Coordinate(x, y + 1));
                    if (x < 6 && y < 5 && x > 0 && y > 0)
                    {
                        if (!DoesContains(coordinates, usedCoords))
                        {
                            newShip = new Ship(_client.Id, 2);

                            for (int i = 0; i < 2; i++)
                            {
                                Button cellButton1 = new Button();
                                cellButton1.Text = "";
                                cellButton1.BackColor = Color.Transparent;
                                cellButton1.Tag = x + "_" + (y + i);
                                gameBoard1.Controls.Add(cellButton1, y - 1 + i, x - 1);
                                newShip.AddCoordinate(x - 1, y - 1);
                                coordinates.Add(new Coordinate(x, y+i));
                            }
                            comboBox1.Items.Remove("Two piece (horizontal)");
                            break;
                        }
                    }
                    MessageBox.Show("Invalid Location.");
                    break;

                case "Two piece (vertical)":
                    usedCoords.Clear();
                    usedCoords.Add(new Coordinate(x, y));
                    usedCoords.Add(new Coordinate(x + 1, y));
                    if (x < 5 && y < 6 && x > 0 && y > 0)
                    {
                        if (!DoesContains(coordinates, usedCoords))
                        {
                            newShip = new Ship(_client.Id, 2);

                            for (int i = 0; i < 2; i++)
                            {
                                Button cellButton2 = new Button();
                                cellButton2.Text = "";
                                cellButton2.BackColor = Color.Transparent;
                                cellButton2.Tag = x + "_" + (y - i);
                                gameBoard1.Controls.Add(cellButton2, y - 1, x - 1 + i);
                                newShip.AddCoordinate(x - 1 + i, y - 1);
                                coordinates.Add(new Coordinate(x+i, y));

                            }
                            comboBox1.Items.Remove("Two piece (vertical)");
                            break;
                        }
                    }
                    MessageBox.Show("Invalid Location.");
                    break;
                    
                case "Three piece (vertical)":
                    usedCoords.Clear();
                    usedCoords.Add(new Coordinate(x, y));
                    usedCoords.Add(new Coordinate(x + 1, y));
                    usedCoords.Add(new Coordinate(x + 2, y));

                    if (x < 4 && y < 6 && x > 0 && y > 0)
                    {
                        if (!DoesContains(coordinates, usedCoords))
                        {
                            newShip = new Ship(_client.Id, 3);

                            for (int i = 0; i < 3; i++)
                            {
                                Button cellButton3 = new Button();
                                cellButton3.Text = "";
                                cellButton3.BackColor = Color.Transparent;
                                cellButton3.Tag = x + "_" + (y - i);
                                gameBoard1.Controls.Add(cellButton3, y - 1, x - 1 + i);
                                newShip.AddCoordinate(x - 1 + i, y - 1);
                                coordinates.Add(new Coordinate(x+i, y));

                            }
                            comboBox1.Items.Remove("Three piece (vertical)");
                            break;
                        }
                    }
                    MessageBox.Show("Invalid Location.");
                    break;
                    
                   
            }

            _ships.Add(newShip);

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.Enabled = false;
                placeShipButton.Enabled = false;
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

        private bool DoesContains(List<Coordinate> usedCoords, List<Coordinate> coords)
        {
            foreach (Coordinate coord in coords)
            {
                foreach (Coordinate used in usedCoords)
                {
                    if (coord.X == used.X && coord.Y == used.Y)
                        return true;
                }
            }
            return false;
        }

    }
}
