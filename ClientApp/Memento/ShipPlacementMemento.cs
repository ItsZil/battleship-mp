using SharedLibrary.Models;

namespace ClientApp.Memento
{
    public class ShipPlacementMemento
    {
        public List<Ship> Ships { get; private set; }

        public ShipPlacementMemento(List<Ship> ships)
        {
            Ships = new List<Ship>(ships.Select(s => (Ship)s.Clone()));
        }
    }
}
