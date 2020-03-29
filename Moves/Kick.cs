using System;
using System.Collections.Generic;

namespace Game
{
    class Kick : Attack
    {
        public Kick()
        {
            Name = "Kick";
            Power = 2;
            StaminaCost = 8;
            Constancy = 5;
        }
    }
}