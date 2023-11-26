using SharedLibrary.Models;
using SharedLibrary.Structs;

namespace ClientApp.Handlers
{
    public abstract class ShotHandler
    {
        protected ShotHandler _nextHandler;

        public void SetNextHandler(ShotHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public abstract HitDetails HandleShot(Shot shot, Client client);
    }
}
