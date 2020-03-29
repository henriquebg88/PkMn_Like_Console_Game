using System;
using System.Collections.Generic;
using System.Threading;

namespace Game
{
    abstract class Monster
    {
        public string Name { get; protected set; }
        public int Hp { get; protected set; }
        public int Hp_Current { get; set; }
        public int Atk { get; protected set; }
        public int Def { get; protected set; }
        public int Speed { get; protected set; }
        public int Stamina = 100;
        public int AttackTurn = 0;
        public List<Attack> Moves = new List<Attack>();
        public List<Effect> Effects = new List<Effect>();

        public Monster()
        {
            Hp_Current = Hp;
        }

        public void _Attack(Monster Defensor, Attack Move)
        {
            
            if(Stamina >= Move.StaminaCost)
            //Checks if there is enought stamina
            {
                //If damage is =< 0, deals 1.
                var damage = Atk + Move.Power - Defensor.Def;
                if(damage <= 0)
                    damage = 1;
                //Deals the damage
                Defensor.Hp_Current -= damage;

                //Reduces Stamina
                Stamina -= Move.StaminaCost;
                Stamina++;

                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.Write(Name);
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.Write(" used ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                System.Console.Write(Move.Name);
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.Write(", and dealt ");
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.Write(damage);
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.Write(" of damage to ");
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.Write(Defensor.Name);
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.Write("!");
                System.Console.WriteLine("");

                System.Console.WriteLine("");  

                //Checks if the move causes any effect
                if(Move.Effect != null)
                {
                    //Checks if the Defensor already has this effect
                    if(!Defensor.Effects.Contains(Move.Effect))
                    {
                        Defensor.Effects.Add(Move.Effect);

                        System.Console.WriteLine("{0} now has {1} for {2} turns!!", Defensor.Name, Move.Effect.Name, Move.Effect.Duration);
                    }
                    else
                    {
                        //Increases the effect duration
                        var existingEffect = Defensor.Effects.Find(x => x.Name == Move.Effect.Name);
                        existingEffect.Duration += existingEffect.Duration_Increment;
                        if(existingEffect.Duration > existingEffect.Duration_Max)
                        {
                            existingEffect.Duration = existingEffect.Duration_Max;
                        }

                        System.Console.WriteLine("The effect of {0} on {1} increased to {2} turns!!", Move.Effect.Name, Defensor.Name, Move.Effect.Duration);
                    }
                }              
            }else
            {
                System.Console.WriteLine("{0} is too tired!", Name);
                Stamina += 3;
            }

            // Console.ReadLine();
            Thread.Sleep(2000);
        }
    }
}