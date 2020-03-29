using System;

namespace Game
{
    abstract class Effect
    {
        public string Name { get; protected set; }    
        public int Duration { get; set; }
        public int Duration_Max { get; protected set; }
        public int Duration_Increment { get; protected set; }

        abstract public void BattleEffect(Monster affectedMonster);
        public void CheckEffect(Monster affectedMonster)
        {
            if(this.Duration == 0)
            {
                affectedMonster.Effects.Remove(this);
                System.Console.WriteLine("{0} no longer has {1}", affectedMonster.Name, this.Name);
            }else
            {
                System.Console.WriteLine("{0} has {1} for {2} more turns...", affectedMonster.Name, this.Name, (this.Duration -1));
                BattleEffect(affectedMonster);
            }
        }
    }
}