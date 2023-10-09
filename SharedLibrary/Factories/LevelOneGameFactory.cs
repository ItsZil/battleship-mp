﻿using SharedLibrary.Interfaces;
using SharedLibrary.Models;

namespace SharedLibrary.Factories
{
    public class LevelOneGameFactory : IGameFactory
    {
        private string _levelName = "Basic Level";
        
        public Game CreateGame(string creatorId, string serverName, string password, int level)
        {
            var players = new List<Player>
            {
                new Player(creatorId, "Player 1")
            };

            var game = new Game(creatorId, serverName, password, level, players);
            game.SupportsIslands = false;
            
            return game;
        }

        public string GetLevelName()
        {
            return _levelName;
        }
    }
}
