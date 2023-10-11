using SharedLibrary.Interfaces;
using SharedLibrary.Structs;

namespace SharedLibrary.Models.Strategies
{
    internal class MoveShipStrategy : IBoardCellInteractionStrategy
    {
        public HitDetails Interact(Game game, Shot shot)
        {
            var hitDetails = new HitDetails(shot.X, shot.Y);

            return hitDetails;
        }
    }
}
