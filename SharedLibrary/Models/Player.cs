using SharedLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class Player : IGamePrototype
    {
        public string PlayerId { get; set; }
        public string Name { get; set; }

        public Player(string playerId, string name)
        {
            PlayerId = playerId;
            Name = name;
        }

        #region Prototype pattern
        public IGamePrototype Clone()
        {
            return new Player(PlayerId, Name);
        }
        #endregion
    }
}
