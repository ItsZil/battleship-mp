using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary.Interfaces;

namespace SharedLibrary.Models.Decorators
{
    public abstract class ShipDecorator : IShip
    {
        private IShip decoratedShip;

        public ShipDecorator(IShip decoratedShip)
        {
            this.decoratedShip = decoratedShip;
        }

        public int GetMaxHealth()
        {
            return decoratedShip.GetMaxHealth();
        }

        public int GetCannonSize()
        {
            return decoratedShip.GetCannonSize();
        }

        public bool GetStealth()
        {
            return decoratedShip.GetStealth();
        }

    }
}
