using SharedLibrary.Models;

namespace SharedLibrary.Events
{
    public class GameCreatedEventArgs : EventArgs
    {
        public Game CreatedGame { get; set; }

        public GameCreatedEventArgs(Game createdGame)
        {
            CreatedGame = createdGame;
        }
    }
}
