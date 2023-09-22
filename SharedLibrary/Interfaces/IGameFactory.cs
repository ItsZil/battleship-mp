using SharedLibrary.Models;

namespace SharedLibrary.Interfaces
{
    // Abstract factory sablonas
    public interface IGameFactory
    {
        Game CreateGame(string CreatorId, string serverName, string password, int level);
        string GetLevelName();
    }
}
