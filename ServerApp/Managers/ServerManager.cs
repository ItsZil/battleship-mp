using SharedLibrary.Models;
using SharedLibrary.Events;
using SharedLibrary.Exceptions;
using SharedLibrary.Models.Request_Models;
using SharedLibrary.Factories;
using Microsoft.AspNet.SignalR;

namespace ServerApp.Managers
{
    // Observer, singleton sablonas?
    public class ServerManager
    {
        private static ServerManager _instance;
        private readonly List<Game> _gameServers = new List<Game>();

        private readonly BasicLevelGameFactory _basicLevelGameFactory = new BasicLevelGameFactory();
        private readonly EnhancedLevelGameFactory _enhancedLevelGameFactory = new EnhancedLevelGameFactory();
        private readonly AdvancedLevelGameFactory _advancedLevelGameFactory = new AdvancedLevelGameFactory();
        private readonly ExpertLevelGameFactory _expertLevelGameFactory = new ExpertLevelGameFactory();

        public event EventHandler<GameCreatedEventArgs> GameCreated;
        public event EventHandler<PlayerJoinedGameEventArgs> PlayerJoinedGame;
        public EventHandler<Game> AllPlayersReady;

        public static ServerManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServerManager();
                }
                return _instance;
            }
        }

        #region Observer event methods
        protected virtual void OnGameCreated(GameCreatedEventArgs e)
        {
            GameCreated?.Invoke(this, e);
        }

        protected virtual void OnPlayerJoinedGame(PlayerJoinedGameEventArgs e)
        {
            PlayerJoinedGame?.Invoke(this, e);
        }

        protected virtual void OnAllPlayersReady(Game game)
        {
            AllPlayersReady?.Invoke(this, game);
        }
        #endregion

        public async Task<int> CreateGameServer(CreateGameDetails createGameDetails)
        {
            if (IsServerNameTaken(createGameDetails.Name))
            {
                throw new HubException("Server name taken!", new ServerNameTakenException());
            }

            Game game = null;
            switch (createGameDetails.LevelName)
            {
                case "Basic Level":
                    game = _basicLevelGameFactory.CreateGame(createGameDetails.CreatorId, createGameDetails.Name, createGameDetails.Password);
                    break;
                case "Enhanced Level":
                    game = _enhancedLevelGameFactory.CreateGame(createGameDetails.CreatorId, createGameDetails.Name, createGameDetails.Password);
                    break;
                case "Advanced Level":
                    game = _advancedLevelGameFactory.CreateGame(createGameDetails.CreatorId, createGameDetails.Name, createGameDetails.Password);
                    break;
                case "Expert Level":
                    game = _expertLevelGameFactory.CreateGame(createGameDetails.CreatorId, createGameDetails.Name, createGameDetails.Password);
                    break;
                default:
                    throw new Exception("Invalid game level!");
            }
            _gameServers.Add(game);
            OnGameCreated(new GameCreatedEventArgs(game));

            return game.GameId;
        }

        public List<Game> GetAvailableGames()
        {
            return _gameServers;
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
                            OnPlayerJoinedGame(new PlayerJoinedGameEventArgs(joinGameDetails.ClientId, gameServer.Players));

                            // Prepare response object
                            joinGameDetails.GameId = gameServer.GameId;
                            joinGameDetails.PlayerCount = gameServer.Players.Count;
                            
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
