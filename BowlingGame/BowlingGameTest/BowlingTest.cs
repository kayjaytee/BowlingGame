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

        [Theory (DisplayName = "Multiple Rolls: Method")]
        [InlineData(20, 0)]
        [InlineData(17, 0)]
        [InlineData(16, 0)]
        void MultipleRolls(int n, int pins)
        {

            for (int i = 0; i < n; i++)
            {
                game.Roll(pins);
            }
        } //Privat Testmetod, inte bunden till originalkoden

        void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }

        [Fact(DisplayName = "Every Roll() will miss on each frame, will the score return the correct value?")]
        public void HitZeroPinsEachFrame()
        {

            //Arrange - Given
            game = (Game)SetUpGame();
            //Act - When
            MultipleRolls(20, 0);
            var result = game.Score();

            //Assert - Then
            Assert.Equal(0, result);

        }

        [Fact(DisplayName = "Hit 1 pin each round(2 rounds per Frame) with Roll(), will the score return the correct value?")]
        public void HitOnePinEachFrame()
        {

            //Arrange - Given
            game = (Game)SetUpGame();



            //Act - When
            MultipleRolls(20, 1);

            var result = game.Score();

            //Assert - Then
            Assert.Equal(20, result);

        }

        [Fact(DisplayName = "Testing if 'Spare' hits are calculated correctly")]
        void TestSpare()
        {
            game = (Game)SetUpGame();

            RollSpare();
            game.Roll(3);
            MultipleRolls(17, 0);
            var result = game.Score();
            Assert.Equal(16, result);
        }

        [Fact(DisplayName = "FIRST STRIKE! Does it return the correct value?")] // == Utan parametrar
        void TestOneStrike()
        {
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);
            MultipleRolls(16, 0);
            var result = game.Score();
            Assert.Equal(24, result);
        }
    }
}
