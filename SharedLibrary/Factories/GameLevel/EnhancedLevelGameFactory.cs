using SharedLibrary.Interfaces;
using SharedLibrary.Models;

namespace SharedLibrary.Factories.GameLevel
{
    public class EnhancedLevelGameFactory : IGameFactory
    {
        private string _levelName = "Enhanced Level";

        public Game CreateGame(string creatorId, string serverName, string password)
        {
            var players = new List<Player>
            {
                new Player(creatorId, "Player 1")
            };

            var game = new Game(creatorId, serverName, password, _levelName, players);

            // Set additional game rules
            game.SupportsAllShips = true;

            return game;
        }

        public string GetLevelName()
        {
            return _levelName;
        }
    }
}
