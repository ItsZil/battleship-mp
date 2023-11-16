using ServerApp;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;

namespace UnitTests.Stubs
{
    public class ClientStub : IServerObserver
    {
        public string Id;
        public Game Game;

        private readonly GameHub _gameHub;

        public ClientStub(string id, GameHub gameHub)
        {
            Id = id;
            _gameHub = gameHub;
        }

        public void UpdateNewGameCreated(Game createdGame)
        {
            Game = createdGame;
        }

        public void UpdateAllPlayersReady(Game game)
        {
            Game = game;
        }
    }
}
