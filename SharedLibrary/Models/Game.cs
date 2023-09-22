namespace SharedLibrary.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string? CreatorId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Level { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();

        public Game()
        {
            
        }

        public Game(string CreatorId, string Name, string Password)
        {
            this.CreatorId = CreatorId;
            this.Name = Name;
            this.Password = Password;
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

        public void AddPlayer()
        {
            if (Players.Count >= 2)
            {
                throw new Exception("Too many players!");
            }
            Players.Add(new Player(Players.Count + 1, $"Player {Players.Count + 1}"));
        }

        public void RemovePlayer(int playerId)
        {
            var player = Players.FirstOrDefault(p => p.PlayerId == playerId);
            if (player != null)
            {
                Players.Remove(player);
            }
        }

        public Player GetPlayerById(int playerId)
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
