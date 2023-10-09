using ClientApp.Forms;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using SharedLibrary.Models;
using SharedLibrary.Models.Request_Models;

namespace ClientApp
{
    public partial class StartForm : Form
    {
        private static Client _client;

        public StartForm(Client client)
        {
            _client = client;

            InitializeComponent();
        }

        private async void CreateGameButton_Click(object sender, EventArgs e)
        {
            string serverName = CreateGameNameTextbox.Text;
            string serverPassword = CreateGamePasswordTextbox.Text;
            string levelName = createGameLevelComboBox.Text;

            if (serverName == string.Empty || serverPassword == string.Empty || levelName == string.Empty)
            {
                MessageBox.Show("Please fill in all fields!", "Error creating game", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CreateGameDetails createGameDetails = new CreateGameDetails(_client.Id, serverName, serverPassword, levelName);
            int gameId = int.MinValue;
            try
            {
                object gameIdObj = await _client.SendMessageAsync("CreateGameServer", createGameDetails);
                gameId = JsonConvert.DeserializeObject<int>(gameIdObj.ToString());
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.Message;
                string errorMessage = exceptionMessage.Substring(exceptionMessage.IndexOf("HubException:") + 14);
                if (errorMessage != String.Empty)
                {
                    exceptionMessage = errorMessage;
                }

                MessageBox.Show(exceptionMessage, "Error creating server!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Succesfully created game {createGameDetails.Name}, {createGameDetails.LevelName}, ID: {gameId}");
            Hide();
            new GameForm(_client, gameId).ShowDialog();
            Show();
        }

        private async void JoinGameButton_Click(object sender, EventArgs e)
        {
            string serverName = JoinGameNameTextbox.Text;
            string serverPassword = JoinGamePasswordTextbox.Text;

            if (serverName == string.Empty || serverPassword == string.Empty)
            {
                MessageBox.Show("Please fill in all fields!", "Error joining game", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            JoinGameDetails joinGameDetails = new JoinGameDetails(_client.Id, serverName, serverPassword);
            try
            {
                object joinGameDetailsObj = await _client.SendMessageAsync("JoinGameServer", joinGameDetails);
                joinGameDetails = JsonConvert.DeserializeObject<JoinGameDetails>(joinGameDetailsObj.ToString());
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.Message;
                string errorMessage = exceptionMessage.Substring(exceptionMessage.IndexOf("HubException:") + 14);
                if (errorMessage != String.Empty)
                {
                    exceptionMessage = errorMessage;
                }

                MessageBox.Show(exceptionMessage, "Error joining server!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show($"Succesfully joined game {joinGameDetails.Name}, player count: {joinGameDetails.PlayerCount}, game Id :{joinGameDetails.GameId}");

            Hide();
            new GameForm(_client, joinGameDetails.GameId).ShowDialog();
            Show();
        }
    }
}