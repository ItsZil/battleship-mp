using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Events
{
    public class GameEventArgs
    {
        public Game Game { get; set; }

        public GameEventArgs(Game Game)
        {
            this.Game = Game;
        }
    }
}
