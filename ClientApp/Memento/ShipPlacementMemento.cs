using SharedLibrary.Models;

namespace ClientApp.Memento
{
    public class ShipPlacementMemento
    {
        private List<Ship> state = new List<Ship>();

        public ShipPlacementMemento(List<Ship> state)
        {
            this.state = state;
        }

        public List<Ship> GetState()
        {
            return state;
        }

        public void SetState(List<Ship> state)
        {
            this.state = state.Select(ship => (Ship)ship.Clone()).ToList();
        }
    }
}
