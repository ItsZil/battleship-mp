using ClientApp.Utilities;
using SharedLibrary.Models;

namespace ClientApp
{
    public partial class StartForm : Form
    {
        private static HttpUtility _httpUtility = new HttpUtility();
        private static Client _client = Client.Instance;

        public StartForm(Client client)
        {
            InitializeComponent();
            _client = client;
        }

        private async void CreateGameButton_Click(object sender, EventArgs e)
        {
            string serverName = CreateGameNameTextbox.Text;
            string serverPassword = CreateGamePasswordTextbox.Text;

            Game game = new Game(_client.Id, serverName, serverPassword, 1, new List<Player>());
            await _httpUtility.PostAsync("api/server/CreateNewGameServer", game);
        }

        private async void JoinGameButton_Click(object sender, EventArgs e)
        {
            string serverName = JoinGameNameTextbox.Text;
            string serverPassword = JoinGamePasswordTextbox.Text;

            Game joinGameDetails = new Game(_client.Id, serverName, serverPassword);

            var joinedGame = await _httpUtility.PostAsync("api/server/JoinGameServer", joinGameDetails);
            MessageBox.Show($"Succesfully joined game {joinedGame.Name}, player count: {joinedGame.Players.Count()}");
        }
    }
}