using SharedLibrary.Models;

namespace SharedLibrary.Interfaces
{
    // Abstract factory sablonas
    public interface IGameFactory
    {
        Game CreateGame(string creatorId, string serverName, string password);
        string GetLevelName();
    }
}
