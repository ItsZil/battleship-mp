using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Exceptions
{
    public class GameNotFoundException : Exception
    {
        new public string Message = "Game not found!";
    }
}
