using ServerApp.Managers;
using SharedLibrary.Exceptions;
using SharedLibrary.Models.Request_Models;
using SharedLibrary.Models;
using SharedLibrary.Models.Levels;
using Microsoft.AspNet.SignalR;

namespace UnitTests.ServerAppTests
{
    [TestFixture]
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

        [Test]
        public async Task CreateGameServer_WhenValidDetails_ReturnsGameId()
        {
            string creatorId = "creatorId",
                name = "TestGame1",
                levelName = "Basic Level",
                password = "password";


            var createGameDetails = new CreateGameDetails(creatorId, name, password, levelName);

            var gameId = await _serverManager.CreateGameServer(createGameDetails);

            Assert.IsTrue(gameId > 0);
            Assert.IsTrue(_serverManager.GetAvailableGames().Any(g => g.GameId == gameId));
        }

        [Test]
        public void CreateGameServer_WhenServerNameTaken_ThrowsHubException()
        {
            string creatorId = "creatorId",
                name = "TestGame2",
                levelName = "Basic Level",
                password = "password";

            var players = new List<Player>()
            {
                new Player("player1", "gamer1"),
                new Player("player2", "gamer2")
            };

            var existingGame = new BasicGame(creatorId, name, levelName, password, players);
            _serverManager.AddGameToServerList(existingGame);

            var createGameDetails = new CreateGameDetails(creatorId, name, password, levelName);

            Assert.ThrowsAsync<HubException>(() => _serverManager.CreateGameServer(createGameDetails));
        }

        [Test]
        public async Task JoinGameServer_WhenValidDetails_JoinsGame()
        {
            string creatorId = "creatorId",
                name = "TestGame3",
                levelName = "Basic Level",
                password = "password";

            var createGameDetails = new CreateGameDetails(creatorId, name, password, levelName);

            var gameId = await _serverManager.CreateGameServer(createGameDetails);

            var joinGameDetails = new JoinGameDetails("testId", name, password);

            var joinedDetails = await _serverManager.JoinGameServer(joinGameDetails);

            Assert.AreEqual(gameId, joinedDetails.GameId);
            Assert.AreEqual(2, joinedDetails.PlayerCount);
        }

        [Test]
        public void JoinGameServer_WhenGameFull_ThrowsGameFullException()
        {
            string creatorId = "creatorId",
                name = "TestGame4",
                levelName = "Basic Level",
                password = "password";

            var createGameDetails = new CreateGameDetails(creatorId, name, password, levelName);

            _serverManager.CreateGameServer(createGameDetails);

            var joinGameDetails = new JoinGameDetails("player1", name, password);

            _serverManager.JoinGameServer(joinGameDetails); // Player 1 joins

            var joinGameDetailsPlayer2 = new JoinGameDetails("testId", name, password);

            Assert.ThrowsAsync<GameFullException>(() => _serverManager.JoinGameServer(joinGameDetailsPlayer2));
        }

        [Test]
        public void JoinGameServer_WhenInvalidPassword_ThrowsInvalidPasswordException()
        {
            string creatorId = "creatorId",
                name = "TestGame4",
                levelName = "Basic Level",
                password1 = "password",
                password2 = "123";

            var createGameDetails = new CreateGameDetails(creatorId, name, password1, levelName);

            _serverManager.CreateGameServer(createGameDetails);

            var joinGameDetails = new JoinGameDetails("player1", name, password2);

            Assert.ThrowsAsync<InvalidPasswordException>(() => _serverManager.JoinGameServer(joinGameDetails));
        }
    }
}