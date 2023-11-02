using SharedLibrary.Models;

namespace SharedLibrary.Factories
{
    // Abstract factory sablonas
    public abstract class GameFactory
    {
        public abstract Game CreateGame(string creatorId, string serverName, string password);
        public abstract string GetLevelName();
    }
}
