using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.SignalR;
using Moq;
using ServerApp.Managers;
using ServerApp;
using SharedLibrary.Models.Strategies;
using SharedLibrary.Models.Request_Models;
using SharedLibrary.Models;

namespace UnitTests.ServerAppTests
{
    [TestFixture]
    internal class StressTest
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
        public async Task SimulateStressTest()
        {
            const int clientCount = 1000;
            const int gameServerCount = 500;

            // Connect 1000 clients to the server
            var clientProxies = new Dictionary<string, Mock<ISingleClientProxy>>();
            for (int i = 0; i < clientCount; i++)
            {
                var clientId = $"Client_{i}";
                _mockHubCallerContext.Setup(x => x.ConnectionId).Returns(clientId);

                var mockClientProxy = new Mock<ISingleClientProxy>();
                clientProxies.Add(clientId, mockClientProxy);

                _mockClients.Setup(m => m.Client(clientId)).Returns(mockClientProxy.Object);
                _gameHub.Clients = _mockClients.Object;

                await _gameHub.OnConnectedAsync();
            }
            _mockClients.Setup(m => m.All).Returns(_mockClientProxy.Object);

            // Run for at least 5 minutes
            var startTime = DateTime.UtcNow;
            int gameNameIndexOffset = 0;
            var responseTimes = new List<TimeSpan>();
            int successfulRequests = 0;
            do
            {
                // Create game servers and measure response time
                for (int i = 0; i < gameServerCount; i++)
                {
                    var createGameDetails = new CreateGameDetails($"Client_{i}", $"Game{gameNameIndexOffset + i}", "password", "Basic Level");
                    var requestStartTime = DateTime.UtcNow;
                    await _gameHub.CreateGameServer(createGameDetails);
                    var requestEndTime = DateTime.UtcNow;
                    responseTimes.Add(requestEndTime - requestStartTime);
                    successfulRequests++;
                }

                // Join game servers
                for (int i = 0; i < gameServerCount; i++)
                {
                    var joinGameDetails = new JoinGameDetails($"Client_{i}", $"Game{gameNameIndexOffset + i}", "password");
                    await _gameHub.JoinGameServer(joinGameDetails);
                }

                // Ready up
                for (int i = 0; i < gameServerCount; i++)
                {
                    var playerReadyDetails1 = new PlayerReadyDetails($"Client_{i * 2}", i, new List<Ship>());
                    var playerReadyDetails2 = new PlayerReadyDetails($"Client_{(i * 2) + 1}", i, new List<Ship>());
                    await _gameHub.SetPlayerAsReady(playerReadyDetails1);
                    await _gameHub.SetPlayerAsReady(playerReadyDetails2);
                }

                gameNameIndexOffset += gameServerCount;
            } while ((DateTime.UtcNow - startTime).TotalMinutes < 5);

            var averageResponseTime = responseTimes.Average(timeSpan => timeSpan.TotalMilliseconds);
            var duration = (DateTime.UtcNow - startTime).TotalSeconds;
            var throughput = successfulRequests / duration;

            Console.WriteLine($"Average response time: {averageResponseTime} ms");
            Console.WriteLine($"Throughput: {throughput} requests/sec");
        }
    }
}
