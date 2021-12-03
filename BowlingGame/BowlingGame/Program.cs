using System;
using System.Collections.Generic;

namespace BowlingGame
{

    class Game
    {
        //Ska vi lagra det i två lister och jämföra index? Eller
        //List<int> scoreList = new List<int>(); 
        //List<int> rollList = new List<int>();
        Random rnd = new Random();

        private int score = 0;
        private int[] rolls = new int[21];
        private int currentRoll = 0;
        
        
        private void Roll(int pins)
        {
            score += pins;
            rolls[currentRoll++] = pins;


            //Roll roll = new Roll(pins);
        }

        private int Score()
        {
            return -1;
        }

        internal void Run()
        {
            Console.WriteLine("Test av github ");

        }
    }

    class Frame
    {
        public int Pins;
        public int Roll;

        public Frame(int pins)
        {
            Pins = pins;
            Roll++;
            scoreEveryRound(pins);
        }
        private void scoreEveryRound(int pins)
        {
            if (pins < 10 || Roll < 2) //TenthFrame
            {

            }
        }
    }

    /* (Eventeullt bortag)
    class Roll
    {
        public int numberOfRolls;
        public Roll(int pins)
        {
            if (pins == 10)
            {
                //return omgång slut
            }
            else
            {

            }
        }
    }
    */
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Run();
        }
    }
}
