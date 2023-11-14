using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;

namespace SharedLibrary.Models.Decorators
{
    public class ArmorDecorator : ShipDecorator
    {
        public ArmorDecorator(IShip decoratedShip) : base(decoratedShip) { }

        public int GetMaxHealth()
        {
            return base.GetMaxHealth() + 1;
        }

        public int GetCannonSize()
        {
            return base.GetCannonSize();
        }

        public bool GetStealth()
        {
            return base.GetStealth();
        }
    }
}
