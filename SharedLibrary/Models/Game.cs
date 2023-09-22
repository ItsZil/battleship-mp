namespace SharedLibrary.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string CreatorId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Level { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();

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

        public Game(string CreatorId, string Name, string Password, int Level)
        {
            var random = new Random();
            
            GameId = random.Next(1000, 9999);
            this.CreatorId = CreatorId;
            this.Name = Name;
            this.Password = Password;
            this.Level = Level;
        }

        public Game(string CreatorId, string Name, string Password, int Level, List<Player> Players)
        {
            var random = new Random();

            GameId = random.Next(1000, 9999);
            this.CreatorId = CreatorId;
            this.Name = Name;
            this.Password = Password;
            this.Level = Level;
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
    }
}
