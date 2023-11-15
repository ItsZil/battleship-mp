using ClientApp;
using ClientApp.Forms;
using Moq;
using SharedLibrary.Factories.GameLevel;
using SharedLibrary.Factories;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;
using SharedLibrary.Models.Builders;
using System.Windows.Forms;
using UnitTests.Mocks;
using SharedLibrary.Models.Strategies;

namespace UnitTests.SharedLibraryTests.Creators
{
    [TestFixture]
    public class ShootStrategyTests
    {

        [Test]
        public void Interact_ReturnHitDetails()
        {
            var creatorId = "234";
            var gameName = "game";
            var password = "123";

            GameFactory gameFactory = new BasicLevelGameFactory();

            var game = gameFactory.CreateGame(creatorId, gameName, password);

            Shot shot = new Shot(game.GameId, creatorId, 2, 2, 1);

            ShootStrategy _shootStrategy = new ShootStrategy();
            var hitDetails = _shootStrategy.Interact(game, shot);

            Assert.IsNotNull(hitDetails);
        }
    }
}
