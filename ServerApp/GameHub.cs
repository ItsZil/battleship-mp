using Microsoft.AspNetCore.SignalR;
using ServerApp.Managers;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;
using SharedLibrary.Models.Request_Models;
using SharedLibrary.Models.Strategies;
using SharedLibrary.Structs;

namespace ServerApp
{
    public class GameHub : Hub, IGameObserver
    {
        private readonly ServerManager _serverManager;
        private readonly GameManager _gameManager;
        private readonly ShootStrategy _shootStrategy;

        public GameHub(ServerManager serverManager, GameManager gameManager, ShootStrategy shootStrategy)
        {
            _serverManager = serverManager;
            _gameManager = gameManager;
            _shootStrategy = shootStrategy;

            _serverManager.Subscribe(this);
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

        public async Task<int> CreateGameServer(CreateGameDetails createGameDetails)
        {
            try
            {
                return await _serverManager.CreateGameServer(createGameDetails);
            }
            catch (Exception ex)
            {
                // Re-throw to preserve the exception message.
                throw new HubException(ex.Message);
            }
        }

        public async Task<JoinGameDetails> JoinGameServer(JoinGameDetails joinGameDetails)
        {
            try
            {
                return await _serverManager.JoinGameServer(joinGameDetails);
            }
            catch (Exception ex)
            {
                // Re-throw to preserve the exception message.
                throw new HubException(ex.Message);
            }
        }

        public async Task SendAvailableGameList(string clientConnectionId)
        {
            var availableGames = _serverManager.GetAvailableGames();
            await Clients.Client(clientConnectionId).SendAsync("SendAvailableGameList", availableGames);
        }

        public async Task<Game> GetGameById(int gameId)
        {
            return await _serverManager.GetGameById(gameId);
        }

        public async Task<bool> SetPlayerAsReady(PlayerReadyDetails playerReadyDetails)
        {
            return await _serverManager.SetPlayerAsReady(playerReadyDetails);
        }

        public async Task<HitDetails> SendShot(Shot shot)
        {
            var game = await _serverManager.GetGameById(shot.GameId);
            //var hitResult = game.HandleShot(shot);
            var hitResult = _shootStrategy.Interact(game, shot);

            if (hitResult.HitShip != null)
            {
                // Only send to the player whose ship got hit. We can handle the shooter's hit client side only.
                string hitPlayerId = hitResult.HitShip.PlayerId;
                await Clients.Client(hitPlayerId).SendAsync("SendHitResult", hitResult);
            }
            var playerIds = game.GetAllPlayerIds();
            
            // Trigger the SetNextTurn method on all clients.
            var nextTurnPlayerId = playerIds.First(id => id != shot.PlayerId);
            await Clients.Clients(playerIds).SendAsync("SetNextTurn", nextTurnPlayerId);
            
            return hitResult;
        }

        #region Observer receiver methods
        public async void NotifyNewGameCreated(Game createdGame)
        {
            await SendNewCreatedGame(createdGame);
        }

        public async void NotifyPlayerJoinedGame(string joinedPlayerId, List<Player> connectedPlayers)
        {
            await SendPlayerJoinedGame(joinedPlayerId, connectedPlayers);
        }

        public async void NotifyAllPlayersReady(Game game)
        {
            await SendPlayerReady(game);
        }
        #endregion

        #region Observer event handler methods
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
                string firstTurnPlayerId = connectedPlayerIds.First();
                
                await Clients.Clients(connectedPlayerIds).SendAsync("SendAllPlayersReady", game.Ships, firstTurnPlayerId);
            }
        }
        #endregion
    }
}
