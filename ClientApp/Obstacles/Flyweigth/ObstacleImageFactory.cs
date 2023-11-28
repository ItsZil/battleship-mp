namespace ClientApp.Obstacles.Flyweigth
{
    public class ObstacleImageFactory
    {
        private readonly Dictionary<string, IObstacleImage> imageCache = new();

        public IObstacleImage GetObstacleImage(string imagePath)
        {
            if (!imageCache.TryGetValue(imagePath, out IObstacleImage? obstacleImage))
            {
                obstacleImage = new ObstacleImage(imagePath);
                imageCache[imagePath] = obstacleImage;
            }

            return obstacleImage;
        }
    }
}
