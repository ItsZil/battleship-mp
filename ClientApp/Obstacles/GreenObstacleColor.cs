namespace SharedLibrary.Models.Obstacles
{
    public class GreenObstacleColor : ObstacleColor
    {
        public override void ColorObstacle(Button button)
        {
            button.BackColor = Color.Green;
        }
    }
}
