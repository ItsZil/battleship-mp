namespace SharedLibrary.Models.Levels
{
    public class ExpertGame : Game
    {
        #region Constructors
        public ExpertGame() { }

        public ExpertGame(string CreatorId, string Name, string Password, string LevelName, List<Player> Players)
            : base(CreatorId, Name, Password, LevelName, Players) { }
        #endregion
    }
}
