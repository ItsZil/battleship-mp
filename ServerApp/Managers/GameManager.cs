namespace ServerApp.Managers
{
    // Singleton sablonas
    // TODO: thread safety
    public class GameManager
    {
        private static GameManager _instance;
        
        private GameManager()
        {
            
        }

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            }
        }
    }
}
