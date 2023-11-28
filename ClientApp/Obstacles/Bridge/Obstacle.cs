using ClientApp.Obstacles.Flyweigth;
using SharedLibrary.Models;

namespace ClientApp.Obstacles.Bridge
{
    public abstract class Obstacle
    {
        public ObstacleColor color;
        public abstract Coordinate coordinate { get; set; }
        public IObstacleImage image;

        public Obstacle(ObstacleColor color, IObstacleImage image)
        {
            this.color = color;
            this.image = image;
        }

        public abstract void ApplyStyle(Button button);
    }
}
