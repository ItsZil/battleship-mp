namespace ClientApp.Interfaces
{
    public interface IMessageBox
    {
        public void Show(string text);
        public void Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);
    }

    public interface IUiInvoker
    {
        void InvokeOnUIThread(Action action, TableLayoutPanel gameBoard);
    }
}
