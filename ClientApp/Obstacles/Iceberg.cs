namespace SharedLibrary.Models.Obstacles
{
    public class IceBerg : Obstacle
    {
        public override string name { get; set; } = "Iceberg";
        public override Coordinate coordinate { get; set; }

        public IceBerg(ObstacleColor color) : base(color)
        {
        }

        public override void ApplyStyle(Button button)
        {
            button.Text = name;
            color.ColorObstacle(button);
        }
    }
}
