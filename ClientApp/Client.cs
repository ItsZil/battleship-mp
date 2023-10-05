using ClientApp.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using SharedLibrary.Models;
using SharedLibrary.Structs;

namespace ClientApp
{
    // Singleton to allow ClientApp to interact with the game hub (server)
    // TODO: thread safety (lazy?)
    public class Client
    {
        private static readonly Lazy<Client> _instance = new Lazy<Client>(() => new Client());
        private readonly HubConnection _gameHub;
        private GameForm _gameForm;

        public string Id { get; set; } = "N/A";

        public Client(GameForm gameForm = null)
        {
            _gameForm = gameForm;
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
                //MessageBox.Show($"There are currently {gameList.Count()} open servers.");
            });
            
            _gameHub.On<Game>("SendNewCreatedGame", (game) =>
            {
                MessageBox.Show($"A new game server ({game.Name}) was just opened!");
            });

            _gameHub.On("SendPlayerJoinedGame", () =>
            {
                //MessageBox.Show("A player has joined your game, starting now!");
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
        
        public async void RegisterGameFormEvents(GameForm gameForm)
        {
            _gameForm = gameForm;

            // All messages from the server that happen in the GameForm should live here.
            _gameHub.On("SendAllPlayersReady", (List<Ship> ships, string firstTurnPlayerId) =>
            {
                List<Ship> otherPlayerShips = ships.Where(s => s.PlayerId != Id).ToList();
                _gameForm.InitializeBoard(otherPlayerShips, firstTurnPlayerId);
            });

            _gameHub.On("SendHitResult", (HitDetails hitDetails) =>
            {
                _gameForm.UpdateBoard(hitDetails);
            });

            _gameHub.On("SetNextTurn", (string nextTurnPlayerId) =>
            {
                _gameForm.SetNextTurn(nextTurnPlayerId);
            });
        }

        public async Task<object> SendMessageAsync(string methodName, object obj)
        {
            if (_gameHub.State == HubConnectionState.Connected)
            {
                return await _gameHub.InvokeAsync<object>(methodName, obj);
            }
            else
            {
                MessageBox.Show("Connection is not established.");
                return null;
            }
        }
    }
}