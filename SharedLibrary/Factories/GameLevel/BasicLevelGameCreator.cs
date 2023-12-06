using SharedLibrary.Models;
using SharedLibrary.Models.Levels;
using SharedLibrary.Templates;

namespace SharedLibrary.Factories.GameLevel
{
    public class BasicLevelGameCreator : GameCreationTemplate
    {
        public BasicLevelGameCreator(string levelName) : base(levelName) { }

        protected override Game InitializeGame(string creatorId, string serverName, string password, string levelName, List<Player> players)
        {
            return new AdvancedGame(creatorId, serverName, password, levelName, players);
        }

        protected override bool GetSupportsAllShips() => false;
        protected override bool GetSupportsMovingShips() => false;

        public string GetLevelName()
        {
            return levelName;
        }
    }

    

}
