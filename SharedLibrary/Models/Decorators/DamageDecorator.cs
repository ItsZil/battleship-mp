using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;

namespace SharedLibrary.Models.Decorators
{
    public class DamageDecorator : ShipDecorator
    {
        public DamageDecorator(IShip decoratedShip) : base(decoratedShip) { }

        public int GetMaxHealth()
        {
            return base.GetMaxHealth();
        }

        public int GetCannonSize()
        {
            return base.GetCannonSize() + 1;
        }

        public bool GetStealth()
        {
            return base.GetStealth();
        }

    }
}
