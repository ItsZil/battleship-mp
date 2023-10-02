using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models.Request_Models
{
    public class PlayerReadyDetails
    {
        public string PlayerId { get; set; }
        public int GameId { get; set; }
        public List<Ship> Ships { get; set; } = new List<Ship>();
        public bool IsServerReady { get; set; } = false;

        public PlayerReadyDetails(string PlayerId, int GameId, List<Ship> Ships)
        {
            this.PlayerId = PlayerId;
            this.GameId = GameId;
            this.Ships = Ships;
        }
    }
}
