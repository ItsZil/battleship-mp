using SharedLibrary.Interfaces;
using ILogger = SharedLibrary.Interfaces.ILogger;

namespace ClientApp
{
    public class ServerLogger : ILogger
    {

        private readonly Client _client;

        public ServerLogger(Client client)
        {
            _client = client;
        }

        public void LogInfo(string message)
        {
            _client.SendMessage("LogInfo", message);
        }

        public void LogWarning(string message)
        {
            _client.SendMessage("LogWarning", message);
        }

        public void LogError(string message)
        {
            _client.SendMessage("LogError", message);
        }

    }
}
