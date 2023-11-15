using SharedLibrary.Factories;
using SharedLibrary.Factories.GameLevel;
using SharedLibrary.Models;
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
