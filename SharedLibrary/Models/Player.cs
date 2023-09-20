﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }

        public Player(int playerId, string name)
        {
            PlayerId = playerId;
            Name = name;
        }
    }
}
