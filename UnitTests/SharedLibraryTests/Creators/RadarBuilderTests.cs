using SharedLibrary.Models.Builders;

namespace UnitTests.SharedLibraryTests.Creators
{
    [TestFixture]
    public class RadarBuilderTests
    {
        private RadarBuilder _radarBuilder;

        [SetUp]
        public void SetUp()
        {
            _radarBuilder = new RadarBuilder();
        }

        [Test]
        public void BuildRadar_WhenHealthAdded_BuildsRadar()
        {
            var clientId = "clientId";

            var radar = _radarBuilder.Build(clientId)
                .AddHealth()
                .Get();

            Assert.IsNotNull(radar);
        }

        [Test]
        public void BuildRadar_WhenCoordsSet_BuildsRadar()
        {
            var clientId = "clientId";
            var x = 1;
            var y = 1;

            var radar = _radarBuilder.Build(clientId)
                .AddCoordinate(x, y)
                .Get();

            Assert.IsNotNull(radar);
        }
    }
}
