
namespace SharedLibrary.Models.Builders
{
    public class RadarBuilder
    {
        private Radar radar;

        public RadarBuilder()
        {

        }

        public RadarBuilder AddCoordinate(int x, int y)
        {
            radar.Coordinates = new Coordinate(x, y);
            return this;
        }

        public RadarBuilder AddHealth()
        {
            radar.Health = 1;
            return this;
        }

        public RadarBuilder Build(string clientId)
        {
            radar = new Radar
            {
                RadarId = new Random().Next(1000, 9999),
                PlayerId = clientId,
            };
            return this;
        }

        public Radar GetRadar()
        {
            return radar;
        }
    }
}
