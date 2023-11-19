using SharedLibrary.Models;
using SharedLibrary.Structs;

namespace SharedLibrary.Interfaces
{
    public interface IShipComponent
    {
        HitDetails SendShot(Shot shot);
    }
}
