namespace ClientApp.State.States
{
    public interface IActionState
    {
        void EnableUIElements(List<Control> enableList);
        void DisableUIElements(List<Control> disableList);
    }
}
