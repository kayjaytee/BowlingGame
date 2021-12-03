using System;
using Xunit;

namespace BowlingGame
{
     //[assembly: PrivateVisibleTo("BowlingGameTest")] - Eventuell lösning på protected class problem?
    public class BowlingTest
    {
        
        private void MultipleRolls(int cap, int pins)
        {
            Game game = new Game();

            for (int i = 0; i < cap; i++)
            {
                game.Roll(pins);
            }
        } //Privat Testmetod, inte bunden till originalkoden

        [Fact(DisplayName = "Every Roll() will miss on each frame, will the score return the correct value?")]
        void HitZeroPinsEachFrame()
        {

            //Arrange - Given
            Game game = new Game();
            var result = game.Score();


            //Act - When
            MultipleRolls(20, 0);


            //Assert - Then
            Assert.Equal(0, result);
            
        }

        [Fact(DisplayName = "Hit 1 pin each round(2 rounds per Frame) with Roll(), will the score return the correct value?")]
        void HitOnePinEachFrame()
        {

            //Arrange - Given
            Game game = new Game();
            var result = game.Score();


            //Act - When
            MultipleRolls(20, 1);


            //Assert - Then
            Assert.Equal(20, result);

        }
    }
}
