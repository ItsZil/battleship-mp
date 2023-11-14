namespace SharedLibrary.Models.Obstacles
{
    public class BrownObstacleColor : ObstacleColor
    {
        public override void ColorObstacle(Button button)
        {
            button.BackColor = Color.Brown;
        }
    }
}
