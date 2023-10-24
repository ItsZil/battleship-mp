using SharedLibrary.Models;

namespace SharedLibrary.Interfaces
{
    public interface IGameObserver
    {
        void NotifyNewGameCreated(Game createdGame);
        void NotifyPlayerJoinedGame(string joinedPlayerId, List<Player> connectedPlayers);
        void NotifyAllPlayersReady(Game game);
    }
}
