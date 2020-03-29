using System;

namespace Game
{
    class Poison : Effect
    {
        public Poison()
        {
            Name = "Poison";
            Duration = 5; 
            Duration_Max = 6;
            Duration_Increment = 4;          
        }

        public override void BattleEffect(Monster poisonedMonster)
        {
            decimal poisonDamage = Convert.ToDecimal(poisonedMonster.Hp * 0.1);

            poisonedMonster.Hp_Current -= Convert.ToInt32(Math.Ceiling(poisonDamage));
            this.Duration--;

            System.Console.WriteLine("{0} suffered {1} of poison damage!", poisonedMonster.Name, Math.Ceiling(poisonDamage));
        }
    }
}