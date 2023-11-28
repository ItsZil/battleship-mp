using ClientApp.Obstacles.Flyweigth;
using SharedLibrary.Models;

namespace ClientApp.Obstacles.Bridge
{
    public class IceBerg : Obstacle
    {
        public override Coordinate coordinate { get; set; }
        public IceBerg(ObstacleColor color, IObstacleImage image) : base(color, image)
        {
        }

        public override void ApplyStyle(Button button)
        {
            button.BackgroundImage = image.GetImage();
            color.ColorObstacle(button);
        }
    }
}
