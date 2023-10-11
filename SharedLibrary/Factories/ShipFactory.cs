using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Factories
{
    public class ShipFactory
    {
        public Ship CreateShip(string clientId, int size, bool isVertical)
        {
            if (size >= 1 && size <= 3)
            {
                return new Ship(clientId, size, isVertical);
            }
            else
            {
                throw new ArgumentException("Invalid ship size!");
            }
        }
    }
}
