using SharedLibrary.Models;

namespace SharedLibrary.Structs
{
    public struct HitDetails
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Ship HitShip { get; set; }
        public bool Hit { get; set; } = false;
        public bool Sunk { get; set; } = false;
        public bool ShotHappened { get; set; } = true;
        public int Damage { get; set; } = 1;

        public HitDetails(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
