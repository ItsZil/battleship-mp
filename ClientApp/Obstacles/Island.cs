namespace SharedLibrary.Models.Obstacles
{
    public class Island : Obstacle
    {
        public override string name { get; set; } = "Island";
        public override Coordinate coordinate { get; set; }

        public Island(ObstacleColor color) : base(color)
        {
        }

        public override void ApplyStyle(Button button)
        {
            button.Text = name;
            color.ColorObstacle(button);
        }
    }
}
