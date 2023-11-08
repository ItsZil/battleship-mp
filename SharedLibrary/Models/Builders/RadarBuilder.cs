
namespace SharedLibrary.Models.Builders
{
    public class RadarBuilder : Builder<Radar, RadarBuilder>
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

        public override RadarBuilder Build(string clientId)
        {
            radar = new Radar
            {
                RadarId = new Random().Next(1000, 9999),
                PlayerId = clientId,
            };
            return this;
        }

        public override Radar Get()
        {
            return radar;
        }
    }
}
