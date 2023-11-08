using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary.Interfaces;

namespace SharedLibrary.Models.Decorators
{
    public abstract class ShipDecorator : IGamePrototype
    {
        protected Ship decoratedShip;

        public ShipDecorator(Ship decoratedShip)
        {
            this.decoratedShip = decoratedShip;
        }

        public virtual IGamePrototype Clone()
        {
            return decoratedShip.Clone();
        }

    }
}
