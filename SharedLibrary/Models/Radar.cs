namespace SharedLibrary.Models
{
    public class Radar
    {
        public string PlayerId { get; set; }
        public int RadarId { get; set; }
        public int Health { get; set; }

        public Coordinate Coordinates { get; set; }

        public Radar()
        {

        }
    }
}
