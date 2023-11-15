using ClientApp;
using ClientApp.Forms;
using Moq;
using SharedLibrary.Factories;
using SharedLibrary.Factories.GameLevel;
using SharedLibrary.Models;
using SharedLibrary.Models.Builders;
using System.Windows.Forms;
using UnitTests.Mocks;
using UnitTests.Stubs;

namespace UnitTests.SharedLibraryTests.Creators
{
    [TestFixture]
    public class GameTests
    {

        private ShipBuilder _shipBuilder;
        private GameForm _gameForm;

        private Mock<Client> _mockClient;
        private UiInvokerStub _mockUiInvoker;
        private MessageBoxStub _messageBoxStub;
        private Mock<TableLayoutPanel> _mockGameBoardLeft;
        private Mock<TableLayoutPanel> _mockGameBoardRight;

        [SetUp]
        public void SetUp()
        {
            _shipBuilder = new ShipBuilder();

            _mockClient = new Mock<Client>(null);
            _mockUiInvoker = new UiInvokerStub();
            _messageBoxStub = new MessageBoxStub();
            _gameForm = new GameForm(_mockClient.Object, _mockUiInvoker, _messageBoxStub);
            _mockGameBoardLeft = new Mock<TableLayoutPanel>();
            _mockGameBoardRight = new Mock<TableLayoutPanel>();

            _gameForm.SetGameBoards(_mockGameBoardLeft.Object, _mockGameBoardRight.Object);
        }

        [Test]
        public void GetAllPlayerIds_ReturnsPlayerIds()
        {
            var player1Id = "123";
            var player2Id = "234";

            var player1Name = "testPlayer";
            var player2Name = "playertest";

            var creatorId = "234";
            var gameName = "game";
            var password = "123";

            Player p1 = new Player(player1Id, player1Name);
            Player p2 = new Player(player2Id, player2Name);

            GameFactory gameFactory = new BasicLevelGameFactory();

            var game = gameFactory.CreateGame(creatorId, gameName, password);
            game.Players.Add(p1);
            game.Players.Add(p2);

            var playerIds = game.GetAllPlayerIds();

            Assert.IsNotNull(playerIds);
        }


        [Test]
        public void GetAllShips_ReturnsShips()
        {
            var creatorId = "234";
            var gameName = "game";
            var password = "123";

            GameFactory gameFactory = new BasicLevelGameFactory();

            var game = gameFactory.CreateGame(creatorId, gameName, password);

            TableLayoutPanel leftBoard = _mockGameBoardLeft.Object;
            int size = 1;
            int x1 = 2, y1 = 5;
            int x2 = 2, y2 = 2;
            bool isVertical = false;

            Ship ship1 = _gameForm.TryPlaceShip(leftBoard, size, x1, y1, isVertical);
            Ship ship2 = _gameForm.TryPlaceShip(leftBoard, size, x2, y2, isVertical);

            game.Ships.Add(ship1);
            game.Ships.Add(ship2);

            var ships = game.GetAllShips();

            Assert.IsNotNull(ships);
        }

        [Test]
        public void GetPlayerById_WhenPlayerExists_ReturnPlayer()
        {
            var player1Id = "123";
            var player2Id = "234";

            var player1Name = "testPlayer";
            var player2Name = "playertest";

            var creatorId = "234";
            var gameName = "game";
            var password = "123";

            Player p1 = new Player(player1Id, player1Name);
            Player p2 = new Player(player2Id, player2Name);

            GameFactory gameFactory = new BasicLevelGameFactory();

            var game = gameFactory.CreateGame(creatorId, gameName, password);
            game.Players.Add(p1);
            game.Players.Add(p2);

            var player = game.GetPlayerById(player1Id);

            Assert.IsNotNull(player);
        }

        [Test]
        public void GetPlayerById_WhenPlayerDoesNotExists_Throws()
        {
            var player1Id = "123";
            var player2Id = "234";

            var player1Name = "testPlayer";
            var player2Name = "playertest";

            var creatorId = "234";
            var gameName = "game";
            var password = "123";

            var fakePlayerId = "5478";

            Player p1 = new Player(player1Id, player1Name);
            Player p2 = new Player(player2Id, player2Name);

            GameFactory gameFactory = new BasicLevelGameFactory();

            var game = gameFactory.CreateGame(creatorId, gameName, password);
            game.Players.Add(p1);
            game.Players.Add(p2);




            Assert.Throws<Exception>(() =>
            {
                var player = game.GetPlayerById(fakePlayerId);
            });

        }
    }
}
