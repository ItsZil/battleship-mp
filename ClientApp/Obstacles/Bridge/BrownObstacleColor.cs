namespace ClientApp.Obstacles.Bridge
{
    public class BrownObstacleColor : ObstacleColor
    {
        public override void ColorObstacle(Button button)
        {
            button.BackColor = Color.Brown;
        }
    }
}
