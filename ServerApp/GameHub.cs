using Microsoft.AspNetCore.SignalR;
using ServerApp.Managers;
using SharedLibrary.Models;
using SharedLibrary.Models.Request_Models;
using SharedLibrary.Models.Strategies;
using SharedLibrary.Structs;

namespace ServerApp
{
    public class GameHub : Hub
    {
        private readonly ServerManager _serverManager;
        private readonly ShootStrategy _shootStrategy;

        public GameHub(ServerManager serverManager, ShootStrategy shootStrategy)
        {
            _serverManager = serverManager;
            _shootStrategy = shootStrategy;
        }

        public override async Task OnConnectedAsync()
        {
            await SendAvailableGameList(Context.ConnectionId);
            await _serverManager.Subscribe(new Client(Context.ConnectionId, this));

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? ex)
        {
            await _serverManager.Unsubscribe(new Client(Context.ConnectionId, this));

            await base.OnDisconnectedAsync(ex);
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

        #region Observer event handler methods
        public async Task SendNewCreatedGame(string clientId, Game newGame)
        {
            string creatorId = newGame.CreatorId;
            if (clientId != creatorId)
                await Clients.Client(clientId).SendAsync("SendNewCreatedGame", newGame);
        }

        public async Task SendPlayerJoinedGame(string clientId, string joinedPlayerId, List<Player> connectedPlayers)
        {
            List<string> connectedPlayerIds = connectedPlayers.Select(x => x.PlayerId).ToList();
            connectedPlayerIds.Remove(joinedPlayerId);

            if (connectedPlayerIds.Contains(clientId))
                await Clients.Client(clientId).SendAsync("SendPlayerJoinedGame", joinedPlayerId, connectedPlayers);
        }

        public async Task SendPlayerReady(string clientId, Game game)
        {
            if (game.ReadyCount == 2)
            {
                List<string> connectedPlayerIds = game.Players.Select(x => x.PlayerId).ToList();
                string firstTurnPlayerId = connectedPlayerIds.First();

                if (connectedPlayerIds.Contains(clientId))
                    await Clients.Client(clientId).SendAsync("SendAllPlayersReady", game.Ships, firstTurnPlayerId);
            }
        }
        #endregion

        public async Task<List<Ship>> GetAllGameShips(int gameId)
        {
            var game = await _serverManager.GetGameById(gameId);
            var ships = game.Ships;

            return ships;
        }

        public async Task<bool> SendRadarPlacement(Radar radar)
        {
            return true;
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"Info: {message}");
        }

        public void LogWarning(string message)
        {
            Console.WriteLine($"Warning: {message}");
        }

        public void LogError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }
}
