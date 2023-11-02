using SharedLibrary.Interfaces;

namespace SharedLibrary.Models.Levels
{
    public class AdvancedGame : Game
    {
        #region Constructors
        public AdvancedGame() : base() { }

        public AdvancedGame(string CreatorId, string Name, string Password, string LevelName, List<Player> Players)
            : base(CreatorId, Name, Password, LevelName, Players) { }
        #endregion

        #region Prototype pattern
        public override IGamePrototype Clone()
        {
            return new BasicGame
            {
                GameId = base.GameId,
                CreatorId = base.CreatorId,
                Name = base.Name,
                Password = base.Password,
                LevelName = base.LevelName,
                ReadyCount = base.ReadyCount,
                Players = base.Players.Select(player => player.Clone() as Player).ToList(),
                Ships = base.Ships.Select(ship => ship.Clone() as Ship).ToList(),
                SupportsAllShips = base.SupportsAllShips,
                SupportsRadars = base.SupportsRadars,
                SupportsMovingShips = base.SupportsMovingShips
            };
        }
        #endregion
    }
}
