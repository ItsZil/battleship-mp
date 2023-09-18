using SharedLibrary.Interfaces;
using SharedLibrary.Models;

namespace SharedLibrary.Factories
{
    public class LevelOneGameFactory : IGameFactory
    {
        private string _levelName = "Basic Level";
        
        public Game CreateGame(string serverName, string password, int level)
        {
            var game = new Game(serverName, password, level);
            // Add player?
            return game;
        }

        public string GetLevelName()
        {
            return _levelName;
        }
    }
}
