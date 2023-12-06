using SharedLibrary.Models;
using SharedLibrary.Models.Levels;
using SharedLibrary.Templates;

namespace SharedLibrary.Factories.GameLevel
{
    public class EnhancedLevelGameCreator : GameCreationTemplate
    {

        public EnhancedLevelGameCreator(string levelName) : base(levelName) { }

        protected override Game InitializeGame(string creatorId, string serverName, string password, string levelName, List<Player> players)
        {
            return new AdvancedGame(creatorId, serverName, password, levelName, players);
        }

        protected override bool GetSupportsAllShips() => true;
        protected override bool GetSupportsMovingShips() => false;
        protected override bool GetSupportRadars() => false;

        public string GetLevelName()
        {
            return levelName;
        }
    }
}

    

