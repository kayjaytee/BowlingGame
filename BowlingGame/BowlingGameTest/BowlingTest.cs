using System.Collections.Generic;
using Xunit;

namespace BowlingGame
{
    //[assembly: PrivateVisibleTo("BowlingGameTest")] - Eventuell lösning på protected class problem?
    public class BowlingTest
    {
        public static Game game;
        protected object SetUpGame()
        {
            Game game = new Game();
            return game;
        }

        #region Privata Metoder; Specifikt för Tester
        void MultipleRolls(int n, int pins)
        {

            for (int i = 0; i < n; i++)
            {
                game.Roll(pins);
            }
        }
        void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }
        void RollStrike()
        {
            game.Roll(10);
        }
        #endregion

        [Fact(DisplayName = "Every Roll() will miss on each frame, will the score return the correct value?")]
        public void HitZeroPinsEachFrame()
        {

            //Arrange - Given
            game = (Game)SetUpGame();
            //Act - When
            MultipleRolls(20, 0);

            //Assert - Then
            Assert.Equal(0, game.Score());

        }

        [Fact(DisplayName = "Hit 1 pin each round(2 rounds per Frame) with Roll(), will the score return the correct value?")]
        public void HitOnePinEachFrame()
        {

            //Arrange - Given
            game = (Game)SetUpGame();



            //Act - When
            MultipleRolls(20, 1);


            //Assert - Then
            Assert.Equal(20, game.Score());

        }

        [Fact(DisplayName = "Testing if 'Spare' hits are calculated correctly")]
        void TestSpare()
        {
            game = (Game)SetUpGame();

            RollSpare();
            game.Roll(3);
            MultipleRolls(17, 0);
            Assert.Equal(16, game.Score());
        }

        [Fact(DisplayName = "ONE STRIKE! Does it return the correct value?")] // == Utan parametrar
        void TestOneStrike()
        {
            game = (Game)SetUpGame();

            RollStrike();
            game.Roll(3);
            game.Roll(4);
            Assert.Equal(24, game.Score()); //Actual: 20
        }

        [Fact (DisplayName = "With perfect score, will the values applied be correct?")]
        void TestPerfectGame() //Need clarification for correct returned value.
        {
            game = (Game)SetUpGame();
            MultipleRolls(12, 10);
            Assert.Equal(300, game.Score());
            System.Console.WriteLine("TEst");

        }
    }
}
