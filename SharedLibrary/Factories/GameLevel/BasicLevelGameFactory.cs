using SharedLibrary.Interfaces;
using SharedLibrary.Models;
using SharedLibrary.Models.Levels;

namespace SharedLibrary.Factories.GameLevel
{
    public class BasicLevelGameFactory : IGameFactory
    {
        private string levelName = "Basic Level";

        public Game CreateGame(string creatorId, string serverName, string password)
        {
            var players = new List<Player>
            {
                new Player(creatorId, "Player 1")
            };

            var game = new BasicGame(creatorId, serverName, password, levelName, players);
            // All game rules are false by default.

            return game;
        }

        public string GetLevelName()
        {
            return levelName;
        }
    }
}
