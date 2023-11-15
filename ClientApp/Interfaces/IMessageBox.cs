namespace ClientApp.Interfaces
{
    public interface IMessageBox
    {
        public void Show(string text);
        public void Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);
    }
}
