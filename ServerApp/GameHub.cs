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
            
            // Register event handlers
            _serverManager.GameCreated += OnNewCreatedGame;
            _serverManager.PlayerJoinedGame += OnPlayerJoinedGame;
            _serverManager.AllPlayersReady += OnAllPlayersReady;
        }
        
        public override async Task OnConnectedAsync()
        {
            await SendAvailableGameList(Context.ConnectionId);
            
            await base.OnConnectedAsync();
        }

        public async Task<string> GetClientId()
        {
            // Used in Client.cs initialization to retrieve the client's connection id
            return Context.ConnectionId;
        }

        public async Task SendAvailableGameList(string clientConnectionId)
        {
            var availableGames = _serverManager.GetAvailableGames();
            await Clients.Client(clientConnectionId).SendAsync("SendAvailableGameList", availableGames);
        }

        #region Event receiver methods
        private void OnNewCreatedGame(object sender, GameCreatedEventArgs e)
        {
            SendNewCreatedGame(e.CreatedGame);
        }

        private void OnPlayerJoinedGame(object sender, PlayerJoinedGameEventArgs e)
        {
            SendPlayerJoinedGame(e.JoinedPlayerId, e.ConnectedPlayers);
        }

        private void OnAllPlayersReady(object sender, Game game)
        {
            SendPlayerReady(game);
        }
        #endregion

        #region Event handler methods
        public async Task SendNewCreatedGame(Game newGame)
        {
            string creatorId = newGame.CreatorId;
            await Clients.AllExcept(creatorId).SendAsync("SendNewCreatedGame", newGame);
        }

        public async Task SendPlayerJoinedGame(string joinedPlayerId, List<Player> connectedPlayers)
        {
            List<string> connectedPlayerIds = connectedPlayers.Select(x => x.PlayerId).ToList();
            connectedPlayerIds.Remove(joinedPlayerId);
            
            await Clients.Clients(connectedPlayerIds).SendAsync("SendPlayerJoinedGame");
        }

        public async Task SendPlayerReady(Game game)
        {
            if (game.ReadyCount == 2)
            {
                List<string> connectedPlayerIds = game.Players.Select(x => x.PlayerId).ToList();                
                await Clients.Clients(connectedPlayerIds).SendAsync("SendAllPlayersReady", game.Ships);
            }
        }
        #endregion
    }
}
