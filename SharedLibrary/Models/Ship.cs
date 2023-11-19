using SharedLibrary.Interfaces;

namespace SharedLibrary.Models
{
    public class Ship : IGamePrototype, IShip
    {
        public string PlayerId { get; set; }
        public int ShipId { get; set; }
        public int Group { get; set; } = 1;
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int CannonSize { get; set; }
        
        public List<Coordinate> Coordinates { get; set; } = new List<Coordinate>();
        public bool IsVertical { get; set; }

        public bool isStealth { get; set; } = false;

        public Ship()
        {
            
        }

        public void AddCoordinate(int x, int y)
        {
            Coordinates.Add(new Coordinate(x,y));
        }

        public int GetMaxHealth()
        {
            return this.MaxHealth;
        }

        public int GetCannonSize()
        {
            return this.CannonSize;
        }

        public bool GetStealth()
        {
            return this.isStealth;
        }

        #region Prototype pattern
        public IGamePrototype Clone()
        {
            return new Ship
            {
                PlayerId = PlayerId,
                ShipId = ShipId,
                Health = Health,
                MaxHealth = MaxHealth,
                CannonSize = CannonSize,
                Coordinates = Coordinates,
                IsVertical = IsVertical
            };
        }
        #endregion
    }
}
