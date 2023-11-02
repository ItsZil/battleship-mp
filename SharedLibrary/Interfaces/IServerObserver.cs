using SharedLibrary.Models;

namespace SharedLibrary.Interfaces
{
    // Observer pattern interface
    public interface IServerObserver
    {
        void UpdateNewGameCreated(Game createdGame);
        void UpdatePlayerJoinedGame(string joinedPlayerId, List<Player> connectedPlayers);
        void UpdateAllPlayersReady(Game game);
    }
}
