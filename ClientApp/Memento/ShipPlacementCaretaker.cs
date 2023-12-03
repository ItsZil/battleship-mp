using SharedLibrary.Interfaces;
using SharedLibrary.Models;

namespace ClientApp.Memento
{
    public class ShipPlacementCaretaker
    {
        private Stack<ShipPlacementMemento> undoStack = new Stack<ShipPlacementMemento>();
        private Stack<ShipPlacementMemento> redoStack = new Stack<ShipPlacementMemento>();

        public void SaveState(ShipPlacementMemento memento)
        {
            undoStack.Push(memento);
        }

        public ShipPlacementMemento Undo(List<Ship> ships)
        {
            if (undoStack.Count > 0)
            {
                ShipPlacementMemento currentState = new ShipPlacementMemento(ships);
                ShipPlacementMemento memento = undoStack.Pop();
                redoStack.Push(currentState);
                return memento;
            }
            return null;
        }

        public ShipPlacementMemento Redo(List<Ship> ships)
        {
            if (redoStack.Count > 0)
            {
                ShipPlacementMemento currentState = new ShipPlacementMemento(ships);
                ShipPlacementMemento memento = redoStack.Pop();
                undoStack.Push(currentState);
                return memento;
            }
            return null;
        }
    }
}
