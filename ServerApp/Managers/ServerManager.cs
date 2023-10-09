using SharedLibrary.Models;
using SharedLibrary.Observers;
using SharedLibrary.Events;
using SharedLibrary.Exceptions;
using SharedLibrary.Models.Request_Models;
using SharedLibrary.Factories;
using Microsoft.AspNet.SignalR;

namespace ServerApp.Managers
{
    // Observer, singleton sablonas?
    public class ServerManager : IServerObserver
    {
        private static ServerManager _instance;
        private readonly List<IServerObserver> _observers = new List<IServerObserver>();
        private readonly List<Game> _gameServers = new List<Game>();

        private readonly LevelOneGameFactory _levelOneGameFactory = new LevelOneGameFactory();
        private readonly LevelTwoGameFactory _levelTwoGameFactory = new LevelTwoGameFactory();

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

        #region Observer methods
        public void Subscribe(IServerObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IServerObserver observer)
        {
            _observers.Remove(observer);
        }
        
        public void Update(Game game)
        {
            foreach (var observer in _observers)
            {
                observer.Update(game);
            }
        }
        #endregion

        public async Task<int> CreateGameServer(Game game)
        {
            if (IsServerNameTaken(game.Name))
            {
                throw new HubException("Server name taken!", new ServerNameTakenException());
            }
            
            switch (game.Level)
            {
                case 1:
                    game = _levelOneGameFactory.CreateGame(game.CreatorId, game.Name, game.Password, game.Level);
                    break;
                case 2:
                    game = _levelTwoGameFactory.CreateGame(game.CreatorId, game.Name, game.Password, game.Level);
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
                            joinGameDetails.Level = gameServer.Level;
                            
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
