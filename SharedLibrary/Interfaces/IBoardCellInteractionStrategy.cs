using SharedLibrary.Models;
using SharedLibrary.Structs;

namespace SharedLibrary.Interfaces
{
    public interface IBoardCellInteractionStrategy
    {
        public HitDetails Interact(Game game, Shot shot);
    }
}
