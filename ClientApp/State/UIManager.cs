using ClientApp.State.States;
using System.ComponentModel;

namespace ClientApp.State
{
    public class UIManager
    {
        private IActionState selectedAction;

        public UIManager()
        {
            selectedAction = new MoveActionState();
        }

        public void SetState (IActionState action)
        {
            selectedAction = action;
        }

        public void Disable(List<Control> disableList)
        {
            selectedAction.DisableUIElements(disableList);
        }

        public void Enable(List<Control> enableList)
        {
            selectedAction.EnableUIElements(enableList);
        }
    }
}
