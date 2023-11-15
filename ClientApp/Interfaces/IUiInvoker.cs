namespace SharedLibrary.Interfaces
{
    public interface IUiInvoker
    {
        void InvokeOnUIThread(Action action, TableLayoutPanel gameBoard);
    }
}
