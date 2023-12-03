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
            redoStack.Clear(); // Clear redo stack on new action
        }

        public ShipPlacementMemento Undo()
        {
            if (undoStack.Count > 0)
            {
                ShipPlacementMemento memento = undoStack.Pop();
                redoStack.Push(memento);
                return memento;
            }
            return null;
        }

        public ShipPlacementMemento Redo()
        {
            if (redoStack.Count > 0)
            {
                ShipPlacementMemento memento = redoStack.Pop();
                undoStack.Push(memento);
                return memento;
            }
            return null;
        }
    }
}
