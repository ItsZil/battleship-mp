namespace ServerApp.Managers
{
    // Singleton sablonas
    public class GameManager
    {
        private static readonly Lazy<GameManager> _instance = new Lazy<GameManager>(() => new GameManager());

        private GameManager()
        {
            
        }

        public static GameManager Instance => _instance.Value;
    }
}
