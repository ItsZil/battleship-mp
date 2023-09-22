using SharedLibrary.Models;

namespace SharedLibrary.Events
{
    public class PlayerJoinedGameEventArgs : EventArgs
    {
        public string JoinedPlayerId { get; set; }
        public List<Player> ConnectedPlayers { get; set; }

        public PlayerJoinedGameEventArgs(string JoinedPlayerId, List<Player> ConnectedPlayers)
        {
            this.JoinedPlayerId = JoinedPlayerId;
            this.ConnectedPlayers = ConnectedPlayers;
        }
    }
}
