namespace SharedLibrary.Models
{
    public class Game
    {
        public int GameId { get; }
        public string Name { get; }
        public string Password { get; }
        public int Level { get; }

        public List<Player> Players { get; } = new List<Player>();
        
        public Game(string serverName, string password, int level)
        {
            var random = new Random();
            
            GameId = random.Next(1000, 9999);
            Name = serverName;
            Password = password;
            Level = level;
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
