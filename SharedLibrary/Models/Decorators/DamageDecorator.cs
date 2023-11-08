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
        public DamageDecorator(Ship decoratedShip) : base(decoratedShip) { }

        public override IGamePrototype Clone()
        {
            decoratedShip.CannonSize += 1;

            return base.Clone();
        }

    }
}
