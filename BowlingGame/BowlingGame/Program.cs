using System;
using System.Collections.Generic;

namespace BowlingGame
{

    public class Game //Måste vara public för att kunnas nås av BowlingGameTest - kräver visst tekniskt lösning för att rundgå detta
                       //Vi får skapa metoder och klassen/klasser med hänvisning till Public tills vi hittar en smidigare lösning
    {

        
        public int[] rolls = new int[21];
        private int currentRoll = 0;

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
     
        }

        public int Score()
        {
            int score = 0;
            int i = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (rolls[i] + rolls[i + 1] == 10) //Spare
                {
                    score += 10 + rolls[i+2];
                    i += 2;
                }
                else
                {
                    score += rolls[i] + rolls[i + 1];
                    i += 2;
                }
            }
            return score;
        }

        internal void Run()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Run();
        }
    }

    #region Eventuella extra klasser för projektet; sidosatta för tillfället
    /*class Frame
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
    }*/

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
    #endregion
}
