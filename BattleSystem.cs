using System.Collections.Generic;
using System;

namespace Game
{
    static class BattleSystem
    {

        static private List<Monster> AttackStack  = new List<Monster>() ;
        static private Monster Attacker;
        static private Monster Defensor;
        static public void Battle(Monster m1, Monster m2)
        //Bagins the battle
        {
            do
            {
                

                if(AttackStack.Count < 5)
                    CreateStack(m1, m2);

                //Defines whitch one is the Attacker and Defensor
                if(AttackStack[0] == m1)
                {
                    Attacker = m1;
                    Defensor = m2;
                }else
                {
                    Attacker = m2;
                    Defensor = m1;
                }

                //Cycles through all the effects on the Defensor
                foreach (var effect in Defensor.Effects)
                {
                    effect.CheckEffect(Defensor);
                    CheckDeath(Defensor);
                }

                //Attacker uses it's move on the Defensor
                Attacker._Attack(Defensor, ChooseMove(Attacker));
                //Removes current attacker from the top of the attack stack
                AttackStack.RemoveAt(0);

                ShowMonstersStatus(m1,m2);

                if(CheckDeath(Defensor))
                {
                    EndOfBattle(Attacker, Defensor);
                    break;
                }

            } while (true); 
        }
        static void CreateStack(Monster m1, Monster m2)
        //Creates the attack order, based on monster speed
        {
            do
            {
                CheckAttackTurn(m1);
                CheckAttackTurn(m2);
            } while (AttackStack.Count < 5);
        }
        static void CheckAttackTurn(Monster checkedMonster)
        //Helps creating the attack order by checking whitch monster has completed its wait
        {
            if(checkedMonster.AttackTurn >= 100)
            {
                checkedMonster.AttackTurn = 0;
                AttackStack.Add(checkedMonster);    
            }
            else
            {
                checkedMonster.AttackTurn += checkedMonster.Speed;
                }
        }
         public static Attack ChooseMove(Monster Attacker)
        //Chooses whitch move to use on the attack
        {
            int ConstancySum = 0;
            var Roulette = new List<Attack>();
            var roll = new Random();
            int rollResult;

            //Determinates the max number to roll
            foreach (var item in Attacker.Moves)
            {
                ConstancySum += item.Constancy;
                //Creates the Roulette
                for (int i = 0; i < item.Constancy; i++)
                {
                    //Adds the move into the Roullete
                    Roulette.Add(item);
                }
            }
            //Generates a random number
            rollResult = roll.Next(0, (ConstancySum) );

            return Roulette[rollResult];
        }
        static bool CheckDeath(Monster defensor)
        //Checks it monster is dead
        {
            if(defensor.Hp_Current <= 0)
                return true;
            return false;
        }
        static void EndOfBattle(Monster winner, Monster looser)
        //Ends the battle
        {
            System.Console.WriteLine("{0} just died!", looser.Name);
            System.Console.WriteLine("{0} has won the battle!", winner.Name);
        }
        static void ShowMonstersStatus(Monster m1, Monster m2)
        {
            Console.Clear();

            Console.WriteLine("=================================================");

                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(m1.Name);                         Console.Write("\t\t");    Console.WriteLine(m2.Name);
                Console.ForegroundColor = ConsoleColor.White;

            Array.ForEach(ShowLifeBar(m1),Console.Write);   Console.Write("\t\t");    Array.ForEach(ShowLifeBar(m2),Console.Write);  
            System.Console.WriteLine("");System.Console.WriteLine("");

            Console.Write("HP : {0}", m1.Hp_Current);       Console.Write("\t\t\t");  Console.WriteLine("HP : {0}", m2.Hp_Current);
            Console.Write("Stamina : {0}", m1.Stamina);     Console.Write("\t\t");    Console.WriteLine("Stamina : {0}", m2.Stamina);
            
            Console.WriteLine("=================================================");
            System.Console.WriteLine("");
        }
        static string[] ShowLifeBar(Monster monster)
        //Draws a lifebar
        {
            //Determines the amount of HP to draw
            double HpBar = Convert.ToInt32( Math.Floor( (double)monster.Hp_Current / (double)monster.Hp * 10F ) );

            var empty = new string[0];

            if(HpBar >= 0)
            {
                var result = new string[(int)HpBar];

                for (int i = 0; i < HpBar; i++)
                {
                    result[i] = "#";
                }

                return result;
            }
            return empty;
        }
    }
}