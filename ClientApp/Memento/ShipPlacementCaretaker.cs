namespace ClientApp.Memento
{
    public class ShipPlacementCaretaker
    {
        private List<ShipPlacementMemento> mementoList = new List<ShipPlacementMemento>();

        public void AddState(ShipPlacementMemento state)
        {
            mementoList.Add(state);
        }

        public ShipPlacementMemento GetState(int index)
        {
            var memento = mementoList[index];
            return memento;
        }

        public int GetMementoCount()
        {
            return mementoList.Count;
        }
    }
}
