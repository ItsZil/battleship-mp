using SharedLibrary.Models;
using SharedLibrary.Observers;
using SharedLibrary.Events;

namespace ServerApp.Managers
{
    // Singleton, Observer sablonas
    // TODO: thread safety
    public class ServerManager : IServerObserver
    {
        private static ServerManager _instance;
        private readonly List<IServerObserver> _observers = new List<IServerObserver>();
        private readonly List<Game> _gameServers = new List<Game>();

        public event EventHandler<GameCreatedEventArgs> GameCreated;
        

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

        public Game CreateGameServer(Game gameServer)
        {
            _gameServers.Add(gameServer);
            OnGameCreated(new GameCreatedEventArgs(gameServer));
            
            return gameServer;
        }

        public List<Game> GetAvailableGames()
        {
            return _gameServers;
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
    }
}
