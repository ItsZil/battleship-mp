namespace SharedLibrary.Models.Levels
{
    public class AdvancedGame : Game
    {
        #region Constructors
        public AdvancedGame() : base() { }

        public AdvancedGame(string CreatorId, string Name, string Password, string LevelName, List<Player> Players)
            : base(CreatorId, Name, Password, LevelName, Players) { }
        #endregion
    }
}
