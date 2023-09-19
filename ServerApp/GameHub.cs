using Microsoft.AspNetCore.SignalR;
using ServerApp.Managers;
using SharedLibrary.Events;
using SharedLibrary.Models;

namespace ServerApp
{
    public class GameHub : Hub
    {
        private readonly ServerManager _serverManager;
        
        public GameHub(ServerManager serverManager)
        {
            _serverManager = serverManager;
            _serverManager.GameCreated += OnNewCreatedGame;
        }
        
        public override async Task OnConnectedAsync()
        {
            await SendAvailableGameList(Context.ConnectionId);
            
            await base.OnConnectedAsync();
        }

        public async Task SendAvailableGameList(string clientConnectionId)
        {
            var availableGames = _serverManager.GetAvailableGames();
            await Clients.Client(clientConnectionId).SendAsync("SendAvailableGameList", availableGames);
        }

        private void OnNewCreatedGame(object sender, GameCreatedEventArgs e)
        {
            SendNewCreatedGame(e.CreatedGame);
        }

        public async Task SendNewCreatedGame(Game newGame)
        {
            // TODO: do not send to client who created the game
            if (Clients != null)
            {
                await Clients.All.SendAsync("SendNewCreatedGame", newGame);
            }
        }
        
    }
}
