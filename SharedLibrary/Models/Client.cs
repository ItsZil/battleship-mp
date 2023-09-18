using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    // Singleton to allow ClientApp to subscribe to observer events (ServerObserver)
    // TODO: thread safety
    public class Client
    {
        private static Client _instance;

        public static Client Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Client();
                }
                return _instance;
            }
        }
    }
}
