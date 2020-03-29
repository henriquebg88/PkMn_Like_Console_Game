using System.Collections.Generic;

namespace Game
{
    class Torturion : Monster
    {
        public Torturion() 
        {
            Name = "Torturion";
            Hp = 44;
            Hp_Current = Hp;
            Atk = 2;
            Def = 5;
            Speed = 3;
            Moves = new List<Attack>{new Punch(), new Water_Pump()}; 
        }
    }
}