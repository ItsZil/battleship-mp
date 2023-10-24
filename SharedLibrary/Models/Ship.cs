namespace SharedLibrary.Models
{
    public class Ship
    {
        public string PlayerId { get; set; }
        public int ShipId { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int CannonSize { get; set; }
        
        public List<Coordinate> Coordinates { get; set; } = new List<Coordinate>();
        public bool IsVertical { get; set; }

        public Ship()
        {
            
        }

        public void AddCoordinate(int x, int y)
        {
            Coordinates.Add(new Coordinate(x,y));
        }
    }
}
