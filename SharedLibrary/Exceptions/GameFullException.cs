﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Exceptions
{
    public class GameFullException : Exception
    {
        new public string Message = "Game is full!";
    }
}
