using ClientApp.Interfaces;

namespace ClientApp.Utilities
{
    public class MessageBox : IMessageBox
    {
        public void Show(string text)
        {
               System.Windows.Forms.MessageBox.Show(text);
        }

        public void Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            System.Windows.Forms.MessageBox.Show(text, caption, buttons, icon);
        }
    }
}
