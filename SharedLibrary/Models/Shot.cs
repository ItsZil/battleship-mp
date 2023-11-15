namespace SharedLibrary.Models
{
    public class Shot
    {
        public int GameId { get; set; }
        public string PlayerId { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }

        public Shot(int GameId, string PlayerId, int X, int Y, int Radius)
        {
            this.GameId = GameId;
            this.PlayerId = PlayerId;
            this.X = X;
            this.Y = Y;
            this.Radius = Radius;
        }
    }
}
