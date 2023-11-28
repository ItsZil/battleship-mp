namespace ClientApp.Obstacles.Flyweigth
{
    public class ObstacleImage : IObstacleImage
    {
        private readonly List<Image> images = new();

        public ObstacleImage(params string[] imagePaths)
        {
            foreach (var imagePath in imagePaths)
            {
                images.Add(Image.FromFile(imagePath)); // Load images
            }
        }

        public Image GetImage()
        {
            Random random = new();
            return images[random.Next(images.Count)];
        }
    }
}
