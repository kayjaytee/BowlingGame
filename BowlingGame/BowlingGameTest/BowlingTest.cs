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

        [Fact(DisplayName = "ONE STRIKE! Does it return the correct value?")] 
        void TestOneStrike()
        {
            game = (Game)SetUpGame();

            RollStrike(); //10 (3 + 4) = 17
            game.Roll(3); // (3 + 4)
            game.Roll(4); // = Total 24
            Assert.Equal(24, game.Score()); //Actual: 20
        }

        [Fact (DisplayName = "With perfect score, will the values applied be correct?")]
        void TestPerfectGame() 
        {
            game = (Game)SetUpGame();
            MultipleRolls(12, 10);
            Assert.Equal(300, game.Score());
        }

        [Fact(DisplayName = "Jonathan Test")]
        void JonathanTest()
        {                               // 1     2     2
            game = (Game)SetUpGame(); // (10) + (5) + (5) 
            MultipleRolls(1, 10); // Räknar 2 nästa kast, (10) + (5) + (5), Frame 1 = 20.
            MultipleRolls(3, 5); // Frame 2 = (5) + (5), + 5 nästa. Total = 35
                                // Frame 3 = (5) = Total 40
            Assert.Equal(40, game.Score());
        }
    }
}
