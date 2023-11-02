using SharedLibrary.Models;
using SharedLibrary.Models.Levels;

namespace SharedLibrary.Factories.GameLevel
{
    public class ExpertLevelGameFactory : GameFactory
    {
        private string levelName = "Expert Level";

        public override Game CreateGame(string creatorId, string serverName, string password)
        {
            var players = new List<Player>
            {
                new Player(creatorId, "Player 1")
            };

            var game = new ExpertGame(creatorId, serverName, password, levelName, players);

            // Set additional game rules
            game.SupportsAllShips = true;
            game.SupportsMovingShips = true;
            game.SupportsRadars = true;

            return game;
        }

        public override string GetLevelName()
        {
            return levelName;
        }
    }
}
