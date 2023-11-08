using SharedLibrary.Interfaces;
using ILogger = SharedLibrary.Interfaces.ILogger;

namespace ServerApp
{
    public class ServerLogger : ILogger
    {
        public void LogInfo(string message)
        {
            Console.WriteLine($"Info: {message}");
        }

        public void LogWarning(string message)
        {
            Console.WriteLine($"Error: {message}");
        }

        public void LogError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }

    }
}
