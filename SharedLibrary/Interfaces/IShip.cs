﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Interfaces
{
    public interface IShip
    {

        int GetMaxHealth();
        int GetCannonSize();
        bool GetStealth();
        
    }
}
