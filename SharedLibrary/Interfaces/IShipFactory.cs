﻿using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Interfaces
{
    public interface IShipFactory
    {
        Ship CreateShip(string clientId, int size, bool isVertical);
    }
}
