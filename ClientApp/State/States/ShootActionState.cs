namespace ClientApp.State.States
{
    public class ShootActionState : IActionState
    {
        public void DisableUIElements(List<Control> disableList)
        {
            foreach (var control in disableList)
            {
                control.Visible = false;
            }
        }
        public void EnableUIElements(List<Control> enableList)
        {
            foreach (var control in enableList)
            {
                control.Visible = true;
            }
        }
    }
}
