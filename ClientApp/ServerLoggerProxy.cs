using SharedLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    public class ServerLoggerProxy : ILoggerProxy
    {
        private readonly ServerLoggerAdapter _serverLogger;
        private readonly Dictionary<string, int> _logCounts;

        public ServerLoggerProxy(Client client)
        {
            _serverLogger = new ServerLoggerAdapter(client);
            _logCounts = new Dictionary<string, int>
            {
                {"Info",0 },
                {"Warning",0 },
                {"Error",0 }
            };
        }

        public void LogInfo(string message)
        {
            _logCounts["Info"]++;
            _serverLogger.LogInfo(message);

        }

        public void LogWarning(string message)
        {
            _logCounts["Warning"]++;
            _serverLogger.LogWarning(message);
        }

        public void LogError(string message)
        {
            _logCounts["Error"]++;
            _serverLogger.LogError(message);
        }

        public Dictionary<string,int> GetLogCounts()
        {
            return new Dictionary<string, int>(_logCounts);
        }


    }
}
