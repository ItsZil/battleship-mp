using SharedLibrary.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class Ship
    {
        public string PlayerId { get; set; }
        public int ShipId { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        
        public List<Coordinate> Coordinates { get; set; } = new List<Coordinate>();
        public bool IsVertical { get; set; }

        public Ship(string playerId, int maxHealth, bool isVertical = false)
        {
            ShipId = new Random().Next(1000, 9999);
            PlayerId = playerId;

            MaxHealth = maxHealth;
            Health = maxHealth;
            IsVertical = isVertical;
        }

        public Ship()
        {
            
        }

        public void AddCoordinate(int x, int y)
        {
            Coordinates.Add(new Coordinate(x,y));
        }
    }
}
