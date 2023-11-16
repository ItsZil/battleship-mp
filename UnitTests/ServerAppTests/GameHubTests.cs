using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Moq;
using ServerApp;
using ServerApp.Managers;
using SharedLibrary.Models;
using SharedLibrary.Models.Request_Models;
using SharedLibrary.Models.Strategies;
using HubCallerContext = Microsoft.AspNetCore.SignalR.HubCallerContext;

namespace UnitTests.ServerAppTests
{
    [TestFixture]
    public class GameHubTests
    {
        private GameHub _gameHub;
        private ServerManager _serverManager;
        private ShootStrategy _shootStrategy;

        private HubConnection _hubConnection;
        private Mock<HubCallerContext> _mockHubCallerContext;
        private Mock<ISingleClientProxy> _mockClientProxy;
        private Mock<IHubCallerClients> _mockClients;

        [SetUp]
        public void SetUp()
        {
            _serverManager = new ServerManager();
            _shootStrategy = new ShootStrategy();
            _mockHubCallerContext = new Mock<HubCallerContext>();
            _mockClientProxy = new Mock<ISingleClientProxy>();
            _mockClients = new Mock<IHubCallerClients>();

            _gameHub = new GameHub(_serverManager, _shootStrategy)
            {
                Context = _mockHubCallerContext.Object
            };
            _gameHub.Clients = _mockClients.Object;

            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7272/gameHub")
                .Build();
            _hubConnection.StartAsync();
        }

        [TearDown]
        public void TearDown()
        {
            _hubConnection.StopAsync();
        }

        [Test]
        public async Task GetClientId_ReturnsId()
        {
            _mockHubCallerContext.Setup(x => x.ConnectionId).Returns("testid");

            var id = await _gameHub.GetClientId();

            Assert.IsNotNull(id);
        }

        [Test]
        public async Task ClientConnected_Subscriber_ContainsOne()
        {
            _mockHubCallerContext.Setup(x => x.ConnectionId).Returns("testid");
            _mockClients.Setup(m => m.Client("testid")).Returns(_mockClientProxy.Object);
            _gameHub.Clients = _mockClients.Object;

            await _gameHub.OnConnectedAsync();

            Assert.That(_serverManager.Clients.Count == 1);
        }

        [Test]
        public async Task NoClients_Unsubscribe_ContainsZero()
        {
            _mockHubCallerContext.Setup(x => x.ConnectionId).Returns("testid");

            await _gameHub.OnDisconnectedAsync(null);

            Assert.That(_serverManager.Clients.Count == 0);
        }

        [Test]
        public async Task CreateBasicGameServer_CorrectDetails_ReturnsGameId()
        {
            CreateGameDetails createGameDetails = new CreateGameDetails("", "", "", "Basic Level");

            int gameId = await _gameHub.CreateGameServer(createGameDetails);

            Assert.NotNull(gameId);
        }

        [Test]
        public async Task CreateBasicGameServer_TakenName_Throws()
        {
            CreateGameDetails createGameDetails = new CreateGameDetails("", "", "", "Basic Level");

            await _gameHub.CreateGameServer(createGameDetails);

            Assert.ThrowsAsync<HubException>(async () =>
            {
                await _gameHub.CreateGameServer(createGameDetails);
            });
        }

        [Test]
        public async Task JoinGame_WhenNoServers_Throws()
        {
            JoinGameDetails joinGameDetails = new JoinGameDetails("", "", "");

            Assert.ThrowsAsync<HubException>(async () =>
            {
                await _gameHub.JoinGameServer(joinGameDetails);
            });
        }

        [Test]
        public async Task JoinGame_WhenPasswordIncorrect_Throws()
        {
            CreateGameDetails createGameDetails = new CreateGameDetails("", "", "123", "Basic Level");
            await _gameHub.CreateGameServer(createGameDetails);

            JoinGameDetails joinGameDetails = new JoinGameDetails("", "", "1234");

            Assert.ThrowsAsync<HubException>(async () =>
            {
                await _gameHub.JoinGameServer(joinGameDetails);
            });
        }

        [Test]
        public async Task JoinGame_WhenServerFull_Throws()
        {
            CreateGameDetails createGameDetails = new CreateGameDetails("", "", "", "Basic Level");
            await _gameHub.CreateGameServer(createGameDetails); // Creator is added by default

            JoinGameDetails joinGameDetails = new JoinGameDetails("", "", "");
            await _gameHub.JoinGameServer(joinGameDetails);

            Assert.ThrowsAsync<HubException>(async () =>
            {
                await _gameHub.JoinGameServer(joinGameDetails);
            });
        }

        [Test]
        public async Task SendAvailableGameList_OneGame_ContainsOne()
        {
            _mockClients.Setup(m => m.Client("testid")).Returns(_mockClientProxy.Object);
            var capturedAvailableGames = new List<Game>();
            _mockClientProxy
                .Setup(x => x.SendCoreAsync("SendAvailableGameList", It.IsAny<object[]>(), default))
                .Callback<string, object[], CancellationToken>((eventName, arguments, cancellationToken) =>
                {
                    var games = arguments.OfType<List<Game>>().FirstOrDefault();
                    capturedAvailableGames = games;
                });

            CreateGameDetails createGameDetails = new CreateGameDetails("", "", "", "Basic Level");
            await _gameHub.CreateGameServer(createGameDetails);

            _gameHub.SendAvailableGameList("testid");

            Assert.That(capturedAvailableGames.Count == 1);
        }

        [Test]
        public async Task GetGameById_ReturnsGame()
        {
            CreateGameDetails createGameDetails = new CreateGameDetails("", "", "", "Basic Level");
            int gameId = await _gameHub.CreateGameServer(createGameDetails);

            var game = await _gameHub.GetGameById(gameId);

            Assert.NotNull(game);
        }

        [Test]
        public async Task PlayerReady_When1PlayerReady_ReturnsFalse()
        {
            CreateGameDetails createGameDetails = new CreateGameDetails("", "", "", "Basic Level");
            int gameId = await _gameHub.CreateGameServer(createGameDetails);
            await _gameHub.JoinGameServer(new JoinGameDetails("", "", ""));

            PlayerReadyDetails playerReadyDetails = new PlayerReadyDetails("", gameId, new List<Ship>());
            bool starting = await _gameHub.SetPlayerAsReady(playerReadyDetails);

            Assert.That(starting == false);
        }

        [Test]
        public async Task PlayerReady_When2PlayersReady_ReturnsTrue()
        {
            CreateGameDetails createGameDetails = new CreateGameDetails("1", "", "", "Basic Level");
            int gameId = await _gameHub.CreateGameServer(createGameDetails);
            await _gameHub.JoinGameServer(new JoinGameDetails("2", "", ""));

            PlayerReadyDetails playerReadyDetails = new PlayerReadyDetails("1", gameId, new List<Ship>());
            await _gameHub.SetPlayerAsReady(playerReadyDetails);

            playerReadyDetails = new PlayerReadyDetails("2", gameId, new List<Ship>());
            bool starting = await _gameHub.SetPlayerAsReady(playerReadyDetails);

            Assert.That(starting == true);
        }

        [Test]
        public async Task Interact_Shoot_Hit()
        {
            _mockClients.Setup(m => m.Client("1")).Returns(_mockClientProxy.Object);
            _mockClients.Setup(m => m.Client("2")).Returns(_mockClientProxy.Object);
            _gameHub.Clients = _mockClients.Object;

            CreateGameDetails createGameDetails = new CreateGameDetails("1", "", "", "Basic Level");
            int gameId = await _gameHub.CreateGameServer(createGameDetails);
            await _gameHub.JoinGameServer(new JoinGameDetails("2", "", ""));

            List<Ship> playerOneShips = new List<Ship>() { new Ship { PlayerId = "1", ShipId = 1,  Health = 1, MaxHealth = 1, CannonSize = 1, IsVertical = false,
                Coordinates = new List<Coordinate>() { new Coordinate(1, 1) } } };
            List<Ship> playerTwoShips = new List<Ship>() { new Ship { PlayerId = "2", ShipId = 2,  Health = 2, MaxHealth = 2, CannonSize = 1, IsVertical = false,
                Coordinates = new List<Coordinate>() { new Coordinate(2, 2) } } };
            await _gameHub.SetPlayerAsReady(new PlayerReadyDetails("1", gameId, playerOneShips));
            await _gameHub.SetPlayerAsReady(new PlayerReadyDetails("2", gameId, playerTwoShips));

            Shot shot = new Shot(gameId, "1", 2, 2, 1);
            var hitDetails = await _gameHub.SendShot(shot);

            Assert.That(hitDetails.Hit == true);
        }

        [Test]
        public async Task Interact_Shoot_Sunk()
        {
            _mockClients.Setup(m => m.Client("1")).Returns(_mockClientProxy.Object);
            _mockClients.Setup(m => m.Client("2")).Returns(_mockClientProxy.Object);
            _gameHub.Clients = _mockClients.Object;

            CreateGameDetails createGameDetails = new CreateGameDetails("1", "", "", "Basic Level");
            int gameId = await _gameHub.CreateGameServer(createGameDetails);
            await _gameHub.JoinGameServer(new JoinGameDetails("2", "", ""));

            List<Ship> playerOneShips = new List<Ship>() { new Ship { PlayerId = "1", ShipId = 1,  Health = 1, MaxHealth = 1, CannonSize = 1, IsVertical = false,
                Coordinates = new List<Coordinate>() { new Coordinate(1, 1) } } };
            List<Ship> playerTwoShips = new List<Ship>() { new Ship { PlayerId = "2", ShipId = 2,  Health = 1, MaxHealth = 1, CannonSize = 1, IsVertical = false,
                Coordinates = new List<Coordinate>() { new Coordinate(2, 2) } } };
            await _gameHub.SetPlayerAsReady(new PlayerReadyDetails("1", gameId, playerOneShips));
            await _gameHub.SetPlayerAsReady(new PlayerReadyDetails("2", gameId, playerTwoShips));

            Shot shot = new Shot(gameId, "1", 2, 2, 1);
            var hitDetails = await _gameHub.SendShot(shot);

            Assert.That(hitDetails.Sunk == true);
        }

        [Test]
        public async Task Interact_Shoot_Miss()
        {
            _mockClients.Setup(m => m.Client("1")).Returns(_mockClientProxy.Object);
            _mockClients.Setup(m => m.Client("2")).Returns(_mockClientProxy.Object);
            _gameHub.Clients = _mockClients.Object;

            CreateGameDetails createGameDetails = new CreateGameDetails("1", "", "", "Basic Level");
            int gameId = await _gameHub.CreateGameServer(createGameDetails);
            await _gameHub.JoinGameServer(new JoinGameDetails("2", "", ""));

            List<Ship> playerOneShips = new List<Ship>() { new Ship { PlayerId = "1", ShipId = 1,  Health = 1, MaxHealth = 1, CannonSize = 1, IsVertical = false,
                Coordinates = new List<Coordinate>() { new Coordinate(1, 1) } } };
            List<Ship> playerTwoShips = new List<Ship>() { new Ship { PlayerId = "2", ShipId = 2,  Health = 1, MaxHealth = 1, CannonSize = 1, IsVertical = false,
                Coordinates = new List<Coordinate>() { new Coordinate(2, 2) } } };
            await _gameHub.SetPlayerAsReady(new PlayerReadyDetails("1", gameId, playerOneShips));
            await _gameHub.SetPlayerAsReady(new PlayerReadyDetails("2", gameId, playerTwoShips));

            Shot shot = new Shot(gameId, "1", 3, 3, 1);
            var hitDetails = await _gameHub.SendShot(shot);

            Assert.That(hitDetails.Hit == false);
        }

        [Test]
        public async Task GetAllGameShips_NoShips_CountIsZero()
        {
            CreateGameDetails createGameDetails = new CreateGameDetails("1", "", "", "Basic Level");
            int gameId = await _gameHub.CreateGameServer(createGameDetails);
            PlayerReadyDetails playerReadyDetails = new PlayerReadyDetails("1", gameId, new List<Ship>());
            await _gameHub.SetPlayerAsReady(playerReadyDetails);

            var ships = await _gameHub.GetAllGameShips(gameId);

            Assert.That(ships.Count == 0);
        }

        [Test]
        public async Task GetAllGameShips_OneShip_CountIsOne()
        {
            CreateGameDetails createGameDetails = new CreateGameDetails("1", "", "", "Basic Level");
            int gameId = await _gameHub.CreateGameServer(createGameDetails);
            PlayerReadyDetails playerReadyDetails = new PlayerReadyDetails("1", gameId, new List<Ship>() { new Ship() });
            await _gameHub.SetPlayerAsReady(playerReadyDetails);

            var ships = await _gameHub.GetAllGameShips(gameId);

            Assert.That(ships.Count == 1);
        }
    }
}
