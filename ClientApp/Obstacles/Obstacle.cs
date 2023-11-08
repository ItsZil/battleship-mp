namespace SharedLibrary.Models.Obstacles
{
    public abstract class Obstacle
    {
        public ObstacleColor color;
        public abstract string name { get; set; }

        public abstract Coordinate coordinate { get; set; }

        public Obstacle(ObstacleColor color)
        {
            this.color = color;
        }

        public abstract void ApplyStyle(Button button);
    }
}
