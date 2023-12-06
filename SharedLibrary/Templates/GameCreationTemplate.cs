using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Templates
{
    public abstract class GameCreationTemplate
    {
        protected string levelName;

        public GameCreationTemplate(string levelName)
        {
            this.levelName = levelName;
        }

        public Game CreateGame(string creatorId, string serverName, string password)
        {
            var players = new List<Player>
            {
                new Player(creatorId, "Player 1")
            };

            var game = InitializeGame(creatorId, serverName, password, levelName, players);

            game.SupportsAllShips = GetSupportsAllShips();
            game.SupportsMovingShips = GetSupportsMovingShips();
            game.SupportsRadars = GetSupportRadars();

            return game;

        }

        protected abstract Game InitializeGame(string creatorId, string serverName, string password, string levelName, List<Player> players);

        protected virtual bool GetSupportsAllShips() => false;
        protected virtual bool GetSupportsMovingShips() => false;

        protected virtual bool GetSupportRadars() => false;

    }
}
