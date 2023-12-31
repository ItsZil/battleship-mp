﻿using SharedLibrary.Models;
using SharedLibrary.Exceptions;
using SharedLibrary.Models.Request_Models;
using Microsoft.AspNet.SignalR;
using SharedLibrary.Factories.GameLevel;
using SharedLibrary.Interfaces;

namespace ServerApp.Managers
{
    // Singleton, observer
    public class ServerManager
    {
        private static readonly Lazy<ServerManager> _instance = new Lazy<ServerManager>(() => new ServerManager());
        private readonly List<Game> _gameServers = new List<Game>();

        private readonly BasicLevelGameCreator _basicLevelGameCreator = new BasicLevelGameCreator("Basic Level");
        private readonly EnhancedLevelGameCreator _enhancedLevelGameCreator = new EnhancedLevelGameCreator("Enhanced Level");
        private readonly AdvancedLevelGameCreator _advancedLevelGameCreator = new AdvancedLevelGameCreator("Advanced Level");
        private readonly ExpertLevelGameCreator _expertLevelGameCreator = new ExpertLevelGameCreator("Expert Level");

        private List<IServerObserver> Clients = new List<IServerObserver>();

        public static ServerManager Instance => _instance.Value;

        #region Observer methods
        public async Task Subscribe(IServerObserver client)
        {
            Clients.Add(client);
        }

        public async Task Unsubscribe(IServerObserver client)
        {
            Clients.Remove(client);
        }

        protected async virtual void OnGameCreated(Game createdGame)
        {
            foreach (IServerObserver client in Clients)
            {
                client.UpdateNewGameCreated(createdGame);
            }
        }

        protected virtual void OnPlayerJoinedGame(string joinedPlayerId, List<Player> connectedPlayers)
        {
            foreach (IServerObserver client in Clients)
            {
                client.UpdatePlayerJoinedGame(joinedPlayerId, connectedPlayers);
            }
        }

        protected virtual void OnAllPlayersReady(Game game)
        {
            foreach (IServerObserver client in Clients)
            {
                client.UpdateAllPlayersReady(game);
            }
        }
        #endregion

        public async Task<int> CreateGameServer(CreateGameDetails createGameDetails)
        {
            if (IsServerNameTaken(createGameDetails.Name))
            {
                throw new HubException("Server name taken!", new ServerNameTakenException());
            }

            Game game;
            switch (createGameDetails.LevelName)
            {
                case "Basic Level":
                    game = _basicLevelGameCreator.CreateGame(createGameDetails.CreatorId, createGameDetails.Name, createGameDetails.Password);
                    break;
                case "Enhanced Level":
                    game = _enhancedLevelGameCreator.CreateGame(createGameDetails.CreatorId, createGameDetails.Name, createGameDetails.Password);
                    break;
                case "Advanced Level":
                    game = _advancedLevelGameCreator.CreateGame(createGameDetails.CreatorId, createGameDetails.Name, createGameDetails.Password);
                    break;
                case "Expert Level":
                    game = _expertLevelGameCreator.CreateGame(createGameDetails.CreatorId, createGameDetails.Name, createGameDetails.Password);
                    break;
                default:
                    throw new Exception("Invalid game level!");
            }
            _gameServers.Add(game);
            OnGameCreated(game);

            return game.GameId;
        }

        public List<Game> GetAvailableGames()
        {
            return _gameServers;
        }

        public void AddGameToServerList(Game game)
        {
            _gameServers.Add(game);
        }

        public async Task<Game> GetGameById(int id)
        {
            return _gameServers.FirstOrDefault(g => g.GameId == id);
        }

        public bool IsServerNameTaken(string name)
        {
            foreach (Game gameServer in _gameServers)
            {
                if (gameServer.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<JoinGameDetails> JoinGameServer(JoinGameDetails joinGameDetails)
        {
            foreach (Game gameServer in _gameServers)
            {
                if (gameServer.Name == joinGameDetails.Name)
                {
                    if (gameServer.Password == joinGameDetails.Password)
                    {
                        if (gameServer.Players.Count < 2)
                        {
                            string playerName = "Player " + (gameServer.Players.Count + 1);
                            
                            gameServer.Players.Add(new Player(joinGameDetails.ClientId, playerName));
                            OnPlayerJoinedGame(joinGameDetails.ClientId, gameServer.Players);

                            // Prepare response object
                            joinGameDetails.GameId = gameServer.GameId;
                            joinGameDetails.PlayerCount = gameServer.Players.Count;
                            joinGameDetails.LevelName = gameServer.LevelName;
                            
                            return joinGameDetails;
                        }
                        else
                        {
                            throw new GameFullException();
                        }
                    }
                    else
                    {
                        throw new InvalidPasswordException();
                    }
                }
            }
            throw new GameNotFoundException();
        }

        public async Task<bool> SetPlayerAsReady(PlayerReadyDetails playerReadyDetails)
        {
            foreach (Game gameServer in _gameServers)
            {
                if (gameServer.GameId == playerReadyDetails.GameId)
                {
                    gameServer.ReadyCount++;
                    gameServer.Ships.AddRange(playerReadyDetails.Ships);
                    
                    // If this game is cloned from a prototype template, we can end up with duplicate ships (some already exist in the game server)
                    // So we need to remove the duplicates.
                    gameServer.Ships = gameServer.Ships.GroupBy(s => s.ShipId).Select(s => s.First()).ToList();
                    
                    if (gameServer.ReadyCount == 2)
                    {
                        OnAllPlayersReady(gameServer);
                        return true; // Game is ready to start
                    }
                    return false; // Game is not ready to start
                }
            }
            return false;
        }
    }
}
