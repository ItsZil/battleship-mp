using SharedLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
