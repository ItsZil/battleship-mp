using SharedLibrary.Models;
using SharedLibrary.Models.Levels;
using SharedLibrary.Templates;

namespace SharedLibrary.Factories.GameLevel
{
    public class ExpertLevelGameCreator : GameCreationTemplate
    {
        public ExpertLevelGameCreator(string levelName) : base(levelName) { }

        protected override Game InitializeGame(string creatorId, string serverName, string password, string levelName, List<Player> players)
        {
            return new AdvancedGame(creatorId, serverName, password, levelName, players);
        }

        protected override bool GetSupportsAllShips() => true;
        protected override bool GetSupportsMovingShips() => true;
        protected override bool GetSupportRadars() => true;

        public string GetLevelName()
        {
            return levelName;
        }
    }
}
