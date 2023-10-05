﻿using Microsoft.AspNetCore.SignalR;
using ServerApp.Managers;
using SharedLibrary.Events;
using SharedLibrary.Models;
using SharedLibrary.Structs;

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

        public async Task<HitDetails> SendShot(Shot shot)
        {
            var game = _serverManager.GetGameById(shot.GameId);
            var hitResult = game.HandleShot(shot);

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
                string firstTurnPlayerId = connectedPlayerIds.First();
                
                await Clients.Clients(connectedPlayerIds).SendAsync("SendAllPlayersReady", game.Ships, firstTurnPlayerId);
            }
        }
        #endregion
    }
}
