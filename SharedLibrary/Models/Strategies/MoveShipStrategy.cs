using SharedLibrary.Interfaces;
using SharedLibrary.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models.Strategies
{
    internal class MoveShipStrategy : IBoardCellInteractionStrategy
    {
        public HitDetails Interact(Game game, Shot shot)
        {
            var hitDetails = new HitDetails(shot.X, shot.Y);

            return hitDetails;
        }
    {
    }
}
