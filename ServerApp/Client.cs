using SharedLibrary.Interfaces;
using SharedLibrary.Models;

namespace ServerApp
{
    public class Client : IServerObserver
    {
        public string Id { get; }

        private readonly GameHub _gameHub;

        public Client(string id, GameHub gameHub)
        {
            Id = id;
            _gameHub = gameHub;
        }

        public async void UpdateNewGameCreated(Game createdGame)
        {
            await _gameHub.SendNewCreatedGame(Id, createdGame);
        }

        public async void UpdateAllPlayersReady(Game game)
        {
            await _gameHub.SendPlayerReady(Id, game);
        }
    }
}
