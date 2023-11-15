namespace SharedLibrary.Models.Levels
{
    public class EnhancedGame : Game
    {
        #region Constructors
        public EnhancedGame() { }

        public EnhancedGame(string CreatorId, string Name, string Password, string LevelName, List<Player> Players)
            : base(CreatorId, Name, Password, LevelName, Players) { }
        #endregion
    }
}
