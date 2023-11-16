using SharedLibrary.Models;

namespace SharedLibrary.Interfaces
{
    // Observer pattern interface
    public interface IServerObserver
    {
        void UpdateNewGameCreated(Game createdGame);
        void UpdateAllPlayersReady(Game game);
    }
}
