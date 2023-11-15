namespace SharedLibrary.Models.Levels
{
    public class BasicGame : Game
    {
        #region Constructors
        public BasicGame() { }

        public BasicGame(string CreatorId, string Name, string Password, string LevelName, List<Player> Players)
            : base(CreatorId, Name, Password, LevelName, Players) { }
        #endregion
    }
}