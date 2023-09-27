using ClientApp.Forms;
using ClientApp.Utilities;
using SharedLibrary.Models;
using SharedLibrary.Models.Request_Models;

namespace ClientApp
{
    public partial class StartForm : Form
    {
        private static HttpUtility _httpUtility = new HttpUtility();
        private static Client _client;

        public StartForm(Client client)
        {
            InitializeComponent();
            _client = client;
        }

        private async void CreateGameButton_Click(object sender, EventArgs e)
        {
            string serverName = CreateGameNameTextbox.Text;
            string serverPassword = CreateGamePasswordTextbox.Text;

            Game game = new Game(_client.Id, serverName, serverPassword, 1);
            game = await _httpUtility.PostAsync("api/server/CreateNewGameServer", game);

            MessageBox.Show($"Succesfully created game {game.Name}, game Id :{game.GameId}");

            this.Hide();
            new GameForm(_client, game).ShowDialog();
            this.Show();
        }

        private async void JoinGameButton_Click(object sender, EventArgs e)
        {
            string serverName = JoinGameNameTextbox.Text;
            string serverPassword = JoinGamePasswordTextbox.Text;

            JoinGameDetails joinGameDetails = new JoinGameDetails(_client.Id, serverName, serverPassword);

            var joinedGame = await _httpUtility.PostAsync("api/server/JoinGameServer", joinGameDetails);

            var game = new Game
            {
                GameId = joinedGame.GameId,
                CreatorId = joinedGame.ClientId,
                Name = joinedGame.Name,
                Password = joinedGame.Password
            };

            MessageBox.Show($"Succesfully joined game {joinedGame.Name}, player count: {joinedGame.PlayerCount}, game Id :{joinedGame.GameId}");
            this.Hide();
            new GameForm(_client, game).ShowDialog();
            this.Show();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }
    }
}