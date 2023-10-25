namespace SharedLibrary.Models.Builders
{
    public class ShipBuilder
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

        public ShipBuilder Build(string clientId, int size, bool isVertical = false)
        {
            ship = new Ship
            {
                ShipId = new Random().Next(1000, 9999),
                PlayerId = clientId,
                MaxHealth = size,
                Health = size,
                IsVertical = isVertical
            };
            return this;
        }

        public Ship GetShip()
        {
            return ship;
        }
    }
}
