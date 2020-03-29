using System.Collections.Generic;

namespace Game
{
    class Coronner : Monster
    {
        public Coronner()
        {
            Name = "Coronner";
            Hp = 24;
            Hp_Current = Hp;
            Atk = 6;
            Def = 1;
            Speed = 4;
            Moves = new List<Attack> {new Kick(), new Toxin()};
        }
    }
}