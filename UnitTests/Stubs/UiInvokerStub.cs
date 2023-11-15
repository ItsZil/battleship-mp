using SharedLibrary.Interfaces;
using System.Windows.Forms;

namespace UnitTests.Mocks
{
    internal class UiInvokerStub : IUiInvoker
    {
        public void InvokeOnUIThread(Action action, TableLayoutPanel gameBoard)
        {
            // Do nothing
        }
    }
}
