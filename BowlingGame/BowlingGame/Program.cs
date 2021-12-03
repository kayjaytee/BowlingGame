using System;

namespace BowlingGame
{

    class Game
    {
        private void Roll(int pins)
        {
            Console.WriteLine("Hej");
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
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Run();
        }
    }
}
