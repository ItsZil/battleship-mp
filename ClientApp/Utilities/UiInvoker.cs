using SharedLibrary.Interfaces;

namespace ClientApp
{
    internal class UiInvoker : IUiInvoker
    {
        public void InvokeOnUIThread(Action action, TableLayoutPanel gameBoard)
        {
            if (gameBoard.InvokeRequired)
            {
                gameBoard.Invoke(action);
            }
            else
            {
                action.Invoke();
            }
        }
    }
}
