using NUnit.Framework;
using Moq;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SharedLibrary.Factories;
using SharedLibrary.Factories.GameLevel;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.SignalR;
using ServerApp.Managers;
using SharedLibrary.Models.Strategies;
using SharedLibrary.Models.Request_Models;
using ClientApp;
using SharedLibrary.Models.Levels;

namespace ServerApp.Tests
{
    [TestFixture]
    public class ObserverTests
    {
        private GameHub _gameHub;
        private ServerManager _serverManager;
        private ShootStrategy _shootStrategy;
        private ServerApp.Client _client;
        private Mock<ClientApp.Client> appClient;

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
            appClient = new Mock<ClientApp.Client>();

            _gameHub = new GameHub(_serverManager, _shootStrategy)
            {
                Context = _mockHubCallerContext.Object
            };
            _gameHub.Clients = _mockClients.Object;

            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7272/gameHub")
                .Build();
            _hubConnection.StartAsync();

            _client = new Client("0", _gameHub);

           
        }

        [TearDown]
        public void TearDown()
        {
            _hubConnection.StopAsync();
        }

        [Test]
        public async Task UpdateNewGameCreated_ShouldSendNewCreatedGameToISingleClientProxy()
        {
            _mockClients.Setup(m => m.Client("0")).Returns(_mockClientProxy.Object);
            Game createdGame= null;
            _mockClientProxy
                .Setup(x => x.SendCoreAsync("SendNewCreatedGame", It.IsAny<object[]>(), default))
                .Callback<string, object[], CancellationToken>((eventName, arguments, cancellationToken) =>
                {
                    var game = arguments.OfType<Game>().FirstOrDefault();
                    createdGame = game;
                });


            // Arrange
            GameFactory gameFactory = new BasicLevelGameFactory();
           Game createGame = gameFactory.CreateGame("1", "server", "pass");

            _client.UpdateNewGameCreated(createGame);

            Assert.That(createdGame == createGame);

            
        }

       

        [Test]
        public async Task UpdateAllPlayersReady_ShouldSendPlayerReadyToGameHub()
        {
            _mockClients.Setup(m => m.Client("0")).Returns(_mockClientProxy.Object);
            _mockClients.Setup(m => m.Client("1")).Returns(_mockClientProxy.Object);
            string firstTurnPlayer = null;
            _mockClientProxy
                .Setup(x => x.SendCoreAsync("SendAllPlayersReady", It.IsAny<object[]>(), default))
                .Callback<string, object[], CancellationToken>((eventName, arguments, cancellationToken) =>
                {
                    var game = arguments.OfType<string>().FirstOrDefault();
                    firstTurnPlayer = game;
                });

            // Arrange
            GameFactory gameFactory = new BasicLevelGameFactory();
            Game game = gameFactory.CreateGame("1", "server", "pass");
            Player p1 = new Player("0", "P1");
            Player p2 = new Player("1", "P2");
            game.Players.Add(p1);
            game.Players.Add(p2);

            game.ReadyCount = 2;


            // Act
            _client.UpdateAllPlayersReady(game);


            // Assert
            Assert.That(firstTurnPlayer == p1.PlayerId || firstTurnPlayer == p2.PlayerId);
        }
    }


}
