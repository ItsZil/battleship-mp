using SharedLibrary.Interfaces;

namespace SharedLibrary.Models
{
    public abstract class Game : IGamePrototype
    {
        public int GameId { get; set; }
        public string CreatorId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string LevelName { get; set; }

        public int ReadyCount { get; set; } = 0;

        public List<Player> Players { get; set; } = new List<Player>();
        public List<Ship> Ships { get; set; } = new List<Ship>();

        // Game rules
        public bool SupportsAllShips { get; set; } = false; // Can the player place bigger than one piece ships?
        public bool SupportsRadars { get; set; } = false;
        public bool SupportsMovingShips { get; set; } = false;

        #region Constructors
        public Game()
        {
            
        }

        public Game(string CreatorId, string Name, string Password, string LevelName, List<Player> Players)
        {
            var random = new Random();

            GameId = random.Next(1000, 9999);
            this.CreatorId = CreatorId;
            this.Name = Name;
            this.Password = Password;
            this.LevelName = LevelName;
            this.Players = Players;
        }
        #endregion

        public List<string> GetAllPlayerIds()
        {
            return Players.Select(p => p.PlayerId).ToList();
        }

        public List<Ship> GetAllShips()
        {
            return Ships;
        }

        #region Game methods
        /*public HitDetails HandleShot(Shot shot)
        {
            // TODO: take into account shot.Radius
            var hitDetails = new HitDetails(shot.X, shot.Y);

            List<Ship> targetShips = Ships.Where(s => s.PlayerId != shot.PlayerId && s.Health > 0).ToList();
            foreach (Ship ship in targetShips)
            {
                foreach (Coordinate coordinate in ship.Coordinates)
                {
                    if (coordinate.X == shot.X && coordinate.Y == shot.Y)
                    {
                        ship.Health--;
                        if (ship.Health == 0)
                            hitDetails.Sunk = true;
                        else
                            hitDetails.Hit = true;
                        hitDetails.HitShip = ship;
                        return hitDetails;
                    }
                }
            }
            return hitDetails;
        }*/
        #endregion

        #region Prototype pattern
        public abstract IGamePrototype Clone();
        #endregion
    }
}
