using SharedLibrary.Factories;
using SharedLibrary.Factories.GameLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.SharedLibraryTests.Factories
{
    [TestFixture]
    public class GameFactoryTests
    {
        [Test]
        public void CreateBasicGame_CorrectDetails_Created()
        {
            GameFactory gameFactory = new BasicLevelGameFactory();

            var game = gameFactory.CreateGame("123", "123", "123");

            Assert.IsNotNull(game);
        }

        [Test]
        public void GetLevelName_BasicLevel_ReturnsName()
        {
            GameFactory gameFactory = new BasicLevelGameFactory();

            string levelName = gameFactory.GetLevelName();

            Assert.That("Basic Level" == levelName);
        }

        [Test]
        public void CreateEnhancedGame_CorrectDetails_Created()
        {
            GameFactory gameFactory = new EnhancedLevelGameFactory();

            var game = gameFactory.CreateGame("123", "123", "123");

            Assert.IsNotNull(game);
        }

        [Test]
        public void GetLevelName_EnhancedLevel_ReturnsName()
        {
            GameFactory gameFactory = new EnhancedLevelGameFactory();

            string levelName = gameFactory.GetLevelName();

            Assert.That("Enhanced Level" == levelName);
        }

        [Test]
        public void CreateAdvancedGame_CorrectDetails_Created()
        {
            GameFactory gameFactory = new AdvancedLevelGameFactory();

            var game = gameFactory.CreateGame("123", "123", "123");

            Assert.IsNotNull(game);
        }

        [Test]
        public void GetLevelName_AdvancedLevel_ReturnsName()
        {
            GameFactory gameFactory = new AdvancedLevelGameFactory();

            string levelName = gameFactory.GetLevelName();

            Assert.That("Advanced Level" == levelName);
        }

        [Test]
        public void CreateExpertGame_CorrectDetails_Created()
        {
            GameFactory gameFactory = new ExpertLevelGameFactory();

            var game = gameFactory.CreateGame("123", "123", "123");

            Assert.IsNotNull(game);
        }

        [Test]
        public void GetLevelName_ExpertLevel_ReturnsName()
        {
            GameFactory gameFactory = new ExpertLevelGameFactory();

            string levelName = gameFactory.GetLevelName();

            Assert.That("Expert Level" == levelName);
        }
    }
}
