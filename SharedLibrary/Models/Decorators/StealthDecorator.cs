using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;

namespace SharedLibrary.Models.Decorators
{
    public class StealthDecorator : ShipDecorator
    {

        public StealthDecorator(IShip decoratedShip) : base(decoratedShip) { }

        public int GetMaxHealth()
        {
            return base.GetMaxHealth();
        }

        public int GetCannonSize()
        {
            return base.GetCannonSize();
        }

        public bool GetStealth()
        {
            return true;
        }

    }
}
