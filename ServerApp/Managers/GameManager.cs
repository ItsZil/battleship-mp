using SharedLibrary.Factories.GameLevel;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;
using SharedLibrary.Models.Builders;

namespace ServerApp.Managers
{
    // Singleton, prototype sablonai
    public class GameManager
    {
        private static readonly Lazy<GameManager> _instance = new Lazy<GameManager>(() => new GameManager());
        private Dictionary<string, IGamePrototype> _gameTemplates = new Dictionary<string, IGamePrototype>();
        private ExpertLevelGameFactory _expertLevelGameFactory = new ExpertLevelGameFactory();

        public GameManager()
        {
            CreateTemplates();
        }

        public static GameManager Instance => _instance.Value;

        #region Prototype pattern
        private void RegisterGameTemplate(string key, IGamePrototype gameTemplate)
        {
            _gameTemplates[key] = gameTemplate;
        }

        public async Task<Game> CreateNewGameFromTemplate(string templateKey)
        {
            if (_gameTemplates.TryGetValue(templateKey, out var gameTemplate))
            {
                return gameTemplate.Clone() as Game;
            }
            return null;
        }

        public void CreateTemplates()
        {
            // Empty template, expert level
            var emptyLevelPrototype = _expertLevelGameFactory.CreateGame("", "Empty Expert Prototype", "");
            emptyLevelPrototype.Players = new List<Player>(); // Reset players because we will add client on creation.
            RegisterGameTemplate("EmptyExpertTemplate", emptyLevelPrototype);

            // Ships placed template, expert level
            var shipsLevelPrototype = _expertLevelGameFactory.CreateGame("", "Ships Expert Prototype", "");
            ShipBuilder shipBuilder = new ShipBuilder();
            var ship1 = shipBuilder.Build("")
                .AddHealth(1)
                .AddCoordinate(1, 1)
                .AddCannons(1)
                .Get();
            var ship2 = shipBuilder.Build("")
                .AddHealth(1)
                .AddCoordinate(3, 4)
                .AddCannons(1)
                .Get();
            shipsLevelPrototype.Ships.Add(ship1);
            shipsLevelPrototype.Ships.Add(ship2);
            shipsLevelPrototype.Players = new List<Player>();
            RegisterGameTemplate("ShipsExpertTemplate", shipsLevelPrototype);
        }
        #endregion
    }
}
