using SharedLibrary.Interfaces;
using SharedLibrary.Models;
using SharedLibrary.Models.Levels;

namespace SharedLibrary.Factories.GameLevel
{
    public class AdvancedLevelGameFactory : IGameFactory
    {
        private string _levelName = "Advanced Level";

        public Game CreateGame(string creatorId, string serverName, string password)
        {
            var players = new List<Player>
            {
                new Player(creatorId, "Player 1")
            };

            var game = new AdvancedGameLevel(creatorId, serverName, password, _levelName, players);

            // Set additional game rules
            game.SupportsAllShips = true;
            game.SupportsMovingShips = true;

            return game;
        }

        public string GetLevelName()
        {
            return _levelName;
        }
    }
}
