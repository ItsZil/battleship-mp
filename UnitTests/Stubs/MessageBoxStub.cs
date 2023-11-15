using ClientApp.Interfaces;
using System.Windows.Forms;

namespace UnitTests.Stubs
{
    public class MessageBoxStub : IMessageBox
    {
        public void Show(string text)
        {
            Console.WriteLine($"MessageBox: {text}");
        }

        public void Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            Console.WriteLine($"MessageBox: [{caption}]: {text}");
        }
    }
}
