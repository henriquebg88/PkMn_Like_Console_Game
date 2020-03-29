using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
           //Creating monsters
            var Monster_Coronner        = new Coronner();
            var Monster_Torturion       = new Torturion();
            
            //Battle
            BattleSystem.Battle(Monster_Coronner, Monster_Torturion);

        }
    }
}
