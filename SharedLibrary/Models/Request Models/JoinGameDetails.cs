using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models.Request_Models
{
    public class JoinGameDetails
    {
        public int GameId { get; set; }
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int PlayerCount { get; set; } = 0;
        public string LevelName { get; set; } = String.Empty;

        public JoinGameDetails(string ClientId, string Name, string Password)
        {
            this.ClientId = ClientId;
            this.Name = Name;
            this.Password = Password;
        }
    }
}
