using SharedLibrary.Interfaces;

namespace SharedLibrary.Models.Levels
{
    public class BasicGameLevel : Game
    {
        #region Constructors
        public BasicGameLevel() { }

        public BasicGameLevel(string CreatorId, string Name, string Password, string LevelName, List<Player> Players)
            : base(CreatorId, Name, Password, LevelName, Players) { }
        #endregion

        #region Prototype pattern
        public override IGamePrototype Clone()
        {
            return new BasicGameLevel
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