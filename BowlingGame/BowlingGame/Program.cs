using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BowlingGameTest")]
namespace BowlingGame
{
    internal class Game
    {

        private readonly int[] rolls = new int[21];
        private int currentRoll = 0;

        internal void Roll(int pins)
        {
            rolls[currentRoll++] = pins; // Sätter värderna
        }

        internal int Score()
        {
            int score = 0;
            int frameindex = 0;
            for (int frame = 0; frame < 10; frame++) 
            {
                if (IsStrike(frameindex)) // Bool, return true
                {
                    score += GetStrikeScore(frameindex); 
                    frameindex++;
                }
                else if (IsSpare(frameindex))
                {
                    score += GetSpareScore(frameindex);
                    frameindex += 2;
                }
                else
                {
                    score += GetStandardScore(frameindex);
                    frameindex += 2;
                }
            }
            return score;
        }

        #region Score Calculation Methods
        private int GetStandardScore(int frameindex)
        {
            return rolls[frameindex] + rolls[frameindex + 1];
        }

        private int GetSpareScore(int frameindex)
        {
            return rolls[frameindex] + rolls[frameindex + 1] + rolls[frameindex + 2];
        }

        private int GetStrikeScore(int frameindex)
        {
            return rolls[frameindex] + rolls[frameindex + 1] + rolls[frameindex + 2];
        }

        private bool IsSpare(int frameindex)
        {
            return rolls[frameindex] + rolls[frameindex + 1] == 10;
        }

        private bool IsStrike(int frameindex)
        {
            return rolls[frameindex] == 10;
        }
        #endregion


        internal void Run()
        {
            //Här kan man börja jobba med Konsoll-Appen
            //Med hjälp av färdiga tester och metoder, kan man börja bygga programmet med färdiga matematiska ekvationer!
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
}
