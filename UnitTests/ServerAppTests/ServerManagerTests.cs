using Moq;
using ServerApp.Managers;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;
using SharedLibrary.Models.Levels;

namespace UnitTests.ServerAppTests
{
    public class ServerManagerTests
    {
        private ServerManager _serverManager;

        [SetUp]
        public void Setup()
        {
            _serverManager = ServerManager.Instance;
        }

        [Test]
        public void GetAvailableGames_ReturnsGameList()
        {
            _serverManager.AddGameToServerList(new BasicGame());
            _serverManager.AddGameToServerList(new BasicGame());

            List<Game> gameList = _serverManager.GetAvailableGames();

            Assert.That(gameList.Count == 2);
        }

        [Test]
        public async Task GetGameById_WhenIdExists_ReturnsGame()
        {
            Game newGame = new BasicGame();
            _serverManager.AddGameToServerList(newGame);

            Game game = await _serverManager.GetGameById(newGame.GameId);

            Assert.That(newGame == game);
        }

        [Test]
        public void IsServerNameTaken_WhenNameAvailable_ReturnsFalse()
        {
            Game newGame = new BasicGame("1", "123", "123", "Basic Level", new List<Player>());
            _serverManager.AddGameToServerList(newGame);

            bool isTaken = _serverManager.IsServerNameTaken("321");

            Assert.That(isTaken == false);
        }

        [Test]
        public void IsServerNameTaken_WhenNameUnavailable_ReturnsTrue()
        {
            Game newGame = new BasicGame("1", "123", "123", "Basic Level", new List<Player>());
            _serverManager.AddGameToServerList(newGame);

            bool isTaken = _serverManager.IsServerNameTaken("123");

            Assert.That(isTaken);
        }
    }
}