using SharedLibrary.Models;

namespace UnitTests.SharedLibraryTests.Creators
{
    [TestFixture]
    public class ShipTests
    {
        [Test]
        public void AddCoordinate_WhenCalled_CoordinatesListIsNotEmpty()
        {
            var ship = new Ship();

            ship.AddCoordinate(1, 2);

            Assert.IsNotEmpty(ship.Coordinates);
            Assert.AreEqual(1, ship.Coordinates.Count);
            Assert.AreEqual(1, ship.Coordinates[0].X);
            Assert.AreEqual(2, ship.Coordinates[0].Y);
        }

        [TestCase(10)]
        [TestCase(20)]
        public void GetMaxHealth_WhenCalled_ReturnsMaxHealth(int maxHealth)
        {
            var ship = new Ship { MaxHealth = maxHealth };

            var result = ship.GetMaxHealth();

            Assert.AreEqual(maxHealth, result);
        }

        [TestCase(5)]
        [TestCase(8)]
        public void GetCannonSize_WhenCalled_ReturnsCannonSize(int cannonSize)
        {
            var ship = new Ship { CannonSize = cannonSize };

            var result = ship.GetCannonSize();

            Assert.AreEqual(cannonSize, result);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void GetStealth_WhenCalled_ReturnsIsStealthValue(bool isStealth)
        {
            var ship = new Ship { isStealth = isStealth };

            var result = ship.GetStealth();

            Assert.AreEqual(isStealth, result);
        }

        [Test]
        public void GetStealth_WhenDefault_ReturnsFalse()
        {
            var ship = new Ship();

            var result = ship.GetStealth();

            Assert.IsFalse(result);
        }
    }
}
