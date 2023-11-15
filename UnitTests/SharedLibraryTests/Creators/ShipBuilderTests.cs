using ClientApp;
using ClientApp.Forms;
using Moq;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;
using SharedLibrary.Models.Builders;
using System.Windows.Forms;
using UnitTests.Mocks;
using UnitTests.Stubs;

namespace UnitTests.SharedLibraryTests.Creators
{
    [TestFixture]
    public class ShipBuilderTests
    {
        private ShipBuilder _shipBuilder;
        private GameForm _gameForm;

        private Mock<Client> _mockClient;
        private UiInvokerStub _uiInvokerStub;
        private MessageBoxStub _messageBoxStub;
        private Mock<TableLayoutPanel> _mockGameBoardLeft;
        private Mock<TableLayoutPanel> _mockGameBoardRight;

        [SetUp]
        public void SetUp()
        {
            _shipBuilder = new ShipBuilder();
            _mockClient = new Mock<Client>(null);
            _uiInvokerStub = new UiInvokerStub();
            _messageBoxStub = new MessageBoxStub();
            _gameForm = new GameForm(_mockClient.Object, _uiInvokerStub, _messageBoxStub);
            _mockGameBoardLeft = new Mock<TableLayoutPanel>();
            _mockGameBoardRight = new Mock<TableLayoutPanel>();

            _gameForm.SetGameBoards(_mockGameBoardLeft.Object, _mockGameBoardRight.Object);
        }

        [Test]
        public void CreateShip_ValidLocation_ShipNotNull()
        {
            TableLayoutPanel leftBoard = _mockGameBoardLeft.Object;
            int size = 1;
            int x = 1;
            int y = 1;
            bool isVertical = false;

            Ship ship = _gameForm.TryPlaceShip(leftBoard, size, x, y, isVertical);

            Assert.IsNotNull(ship);
        }

        [Test]
        public void CreateShip_InvalidLocation_ShipNull()
        {
            TableLayoutPanel leftBoard = _mockGameBoardLeft.Object;
            int size = 1;
            int x = -3;
            int y = -44;
            bool isVertical = false;

            Ship ship = _gameForm.TryPlaceShip(leftBoard, size, x, y, isVertical);

            Assert.IsNull(ship);
        }

        [Test]
        public void CreateSecondShip_ValidLocation_ShipNotNull()
        {
            TableLayoutPanel leftBoard = _mockGameBoardLeft.Object;
            _gameForm.TryPlaceShip(leftBoard, 1, 1, 1);
            int size = 1;
            int x = 3;
            int y = 3;
            bool isVertical = false;

            Ship secondShip = _gameForm.TryPlaceShip(leftBoard, size, x, y, isVertical);

            Assert.IsNotNull(secondShip);
        }

        [Test]
        public void CreateSecondShip_Overlaps_ShipNull()
        {
            TableLayoutPanel leftBoard = _mockGameBoardLeft.Object;
            _gameForm.TryPlaceShip(leftBoard, 1, 1, 1);
            int size = 1;
            int x = 1;
            int y = 1;
            bool isVertical = false;

            Ship secondShip = _gameForm.TryPlaceShip(leftBoard, size, x, y, isVertical);

            Assert.IsNull(secondShip);
        }

        [Test]
        public void BuildShip_WhenSize1_BuildsShip()
        {
            var clientId = "clientId";
            var isVertical = false;
            var size = 1;

            var ship = _shipBuilder.Build(clientId)
                .AddHealth(size, isVertical)
                .Get();

            Assert.IsNotNull(ship);
        }

        [Test]
        public void BuildShip_WhenAllParamsSet_BuildsShip()
        {
            var clientId = "clientId";
            var isVertical = false;
            var size = 1;
            var x = 1;
            var y = 1;

            var ship = _shipBuilder.Build(clientId)
                .AddHealth(size, isVertical)
                .AddCannons(size)
                .AddCoordinate(x, y)
                .Get();

            Assert.IsNotNull(ship);
        }

        [Test]
        public void BuildShip_WhenAllParamsSetAndSize2_BuildsShip()
        {
            var clientId = "clientId";
            var isVertical = false;
            var size = 2;
            var coordinates = new List<Coordinate>{
                new Coordinate(1,1),
                new Coordinate(2,2) 
            };

            var ship = _shipBuilder.Build(clientId)
                .AddHealth(size, isVertical)
                .AddCannons(size)
                .AddCoordinates(coordinates)
                .Get();

            Assert.IsNotNull(ship);
        }

        [Test]
        public void BuildShip_WhenSizeNegative_Throws()
        {
            var clientId = "clientId";
            var isVertical = false;
            var size = -1;
            var coordinates = new List<Coordinate>{
                new Coordinate(1,1),
                new Coordinate(2,2)
            };

            Assert.Throws<ArgumentException>(() =>
            {
                var ship = _shipBuilder.Build(clientId)
                    .AddHealth(size, isVertical)
                    .AddCannons(size)
                    .AddCoordinates(coordinates)
                    .Get();
            });
        }
    }
}
