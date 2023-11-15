using SharedLibrary.Interfaces;

namespace ClientApp
{
    public class ServerLoggerAdapter : SharedLibrary.Interfaces.ILogger
    {
        private readonly ServerLogger serverLogger;
        private readonly Client _client;

        public ServerLoggerAdapter(Client client)
        {
            serverLogger = new ServerLogger(client);
            _client = client;
        }

        public void LogInfo(string message)
        {
            serverLogger.LogInfo(message);
        }

        public void LogWarning(string message)
        {
            serverLogger.LogWarning(message);
        }

        public void LogError(string message)
        {
            serverLogger.LogError(message);
        }

    }
}
