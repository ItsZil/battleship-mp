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
        public ArmorDecorator(Ship decoratedShip) : base(decoratedShip) { }

        public override IGamePrototype Clone()
        {
            decoratedShip.MaxHealth += 10;
            decoratedShip.Health += 10;

            return base.Clone();
        }
    }
}
