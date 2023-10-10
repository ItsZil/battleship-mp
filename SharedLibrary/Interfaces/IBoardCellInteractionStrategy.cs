using SharedLibrary.Models;
using SharedLibrary.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Interfaces
{
    public interface IBoardCellInteractionStrategy
    {
        public HitDetails Interact(Game game, Shot shot);
    }
}
