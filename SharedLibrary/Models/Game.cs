using SharedLibrary.Interfaces;
using SharedLibrary.Structs;

namespace SharedLibrary.Models
{
    public class Game : IGamePrototype
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

        public Game(string CreatorId, string Name, string Password)
        {
            this.CreatorId = CreatorId;
            this.Name = Name;
            this.Password = Password;
        }

        public Game(string CreatorId, string Name, string Password, string LevelName)
        {
            var random = new Random();
            
            GameId = random.Next(1000, 9999);
            this.CreatorId = CreatorId;
            this.Name = Name;
            this.Password = Password;
            this.LevelName = LevelName;
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

        public void RemovePlayer(string playerId)
        {
            var player = Players.FirstOrDefault(p => p.PlayerId == playerId);
            if (player != null)
            {
                Players.Remove(player);
            }
        }

        public Player GetPlayerById(string playerId)
        {
            var player = Players.FirstOrDefault(p => p.PlayerId == playerId);
            if (player != null)
                return player;
            
            throw new Exception("Player not found!");
        }

        public List<Player> GetAllPlayers()
        {
            return Players;
        }

        public List<string> GetAllPlayerIds()
        {
            return Players.Select(p => p.PlayerId).ToList();
        }

        #region Game methods
        public HitDetails HandleShot(Shot shot)
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
        }
        #endregion

        #region Prototype pattern
        public IGamePrototype Clone()
        {
            return new Game
            {
                GameId = this.GameId,
                CreatorId = this.CreatorId,
                Name = this.Name,
                Password = this.Password,
                LevelName = this.LevelName,
                ReadyCount = this.ReadyCount,
                Players = this.Players.Select(player => player.Clone() as Player).ToList(),
                Ships = this.Ships.Select(ship => ship.Clone() as Ship).ToList(),
                SupportsAllShips = this.SupportsAllShips,
                SupportsRadars = this.SupportsRadars,
                SupportsMovingShips = this.SupportsMovingShips
            };
        }
        #endregion
    }
}
