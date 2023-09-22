using ClientApp.Utilities;
using Microsoft.AspNetCore.SignalR.Client;
using SharedLibrary.Models;

namespace ClientApp
{
    // Singleton to allow ClientApp to interact with the game hub (server)
    // TODO: thread safety (lazy?)
    public class Client
    {
        private static readonly Lazy<Client> _instance = new Lazy<Client>(() => new Client());
        private readonly HubConnection _gameHub;

        public string Id { get; set; } = "N/A";

        public Client()
        {
            _gameHub = new HubConnectionBuilder()
                .WithUrl("https://localhost:7272/gameHub")
                .Build();

            Initialize();
            ReceiveClientId();
        }

        public static Client Instance => _instance.Value;

        private async void Initialize()
        {
            _gameHub.On<List<Game>>("SendAvailableGameList", (gameList) =>
            {
                MessageBox.Show($"There are currently {gameList.Count()} open servers.");
            });
            
            _gameHub.On<Game>("SendNewCreatedGame", (game) =>
            {
                MessageBox.Show($"A new game server ({game.Name}) was just opened!");
            });

            await StartAsync();
        }

        private async void ReceiveClientId()
        {
            Id = await _gameHub.InvokeAsync<string>("GetClientId");
        }

        public async Task StartAsync()
        {
            try
            {                
                await _gameHub.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task SendMessageAsync(string message)
        {
            if (_gameHub.State == HubConnectionState.Connected)
            {
                await _gameHub.SendAsync("SendTestMessageClient", message);
            }
            else
            {
                MessageBox.Show("Connection is not established.");
            }
        }
    }
}