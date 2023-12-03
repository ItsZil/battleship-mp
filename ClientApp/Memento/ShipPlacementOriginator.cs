using SharedLibrary.Models;

namespace ClientApp.Memento
{
    public class ShipPlacementOriginator
    {
        private List<Ship> state = new List<Ship>();

        public void SetState(List<Ship> state)
        {
            this.state = state.Select(ship => (Ship)ship.Clone()).ToList();
        }

        public void RestoreFromMemento(ShipPlacementMemento previousState)
        {
            state = previousState.GetState();
        }

        public ShipPlacementMemento CreateMemento()
        {
            return new ShipPlacementMemento(state);
        }
    }
}
