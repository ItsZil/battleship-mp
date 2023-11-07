namespace SharedLibrary.Models.Builders
{
    public class ShipBuilder : Builder<Ship, ShipBuilder>
    {
        private Ship ship;

        public ShipBuilder()
        {
            
        }

        public ShipBuilder AddCoordinate(int x, int y)
        {
            ship.Coordinates.Add(new Coordinate(x, y));
            return this;
        }

        public ShipBuilder AddCoordinates(List<Coordinate> coordinates)
        {
            ship.Coordinates.AddRange(coordinates);
            return this;
        }

        public ShipBuilder AddCannons(int cannonSize)
        {
            ship.CannonSize = cannonSize;
            return this;
        }

        public ShipBuilder AddHealth(int size, bool isVertical = false)
        {
            ship.Health = size;
            ship.MaxHealth = size;
            ship.IsVertical = isVertical;
            return this;
        }

        public override ShipBuilder Build(string clientId)
        {
            ship = new Ship
            {
                ShipId = new Random().Next(1000, 9999),
                PlayerId = clientId,
            };
            return this;
        }

        public override Ship Get()
        {
            return ship;
        }
    }
}
