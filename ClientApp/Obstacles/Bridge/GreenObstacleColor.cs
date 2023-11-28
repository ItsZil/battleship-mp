namespace ClientApp.Obstacles.Bridge
{
    public class GreenObstacleColor : ObstacleColor
    {
        public override void ColorObstacle(Button button)
        {
            button.BackColor = Color.Green;
        }
    }
}
