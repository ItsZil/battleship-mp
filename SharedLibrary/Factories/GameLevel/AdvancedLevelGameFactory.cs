﻿using SharedLibrary.Models;
using SharedLibrary.Models.Levels;

namespace SharedLibrary.Factories.GameLevel
{
    public class AdvancedLevelGameFactory : GameFactory
    {
        private string levelName = "Advanced Level";

        public override Game CreateGame(string creatorId, string serverName, string password)
        {
            var players = new List<Player>
            {
                new Player(creatorId, "Player 1")
            };

            var game = new AdvancedGame(creatorId, serverName, password, levelName, players);

            // Set additional game rules
            game.SupportsAllShips = true;
            game.SupportsMovingShips = true;

            return game;
        }

        public override string GetLevelName()
        {
            return levelName;
        }
    }
}
