using Xunit;

namespace BowlingGame
{
    //[assembly: PrivateVisibleTo("BowlingGameTest")] - Eventuell l�sning p� protected class problem?
    public class BowlingTest
    {
        public static Game game;

        protected object SetUpGame()
        {
            Game game = new Game();
            return game;
        }

        [Theory (DisplayName = "Multiple Rolls: Method")]
        [InlineData(20, 0)] //Deklarering av v�rde
        [InlineData(20, 1)] //Deklarering av v�rde
        [InlineData(20, 2)] //Deklarering av v�rde
        public void MultipleRolls(int n, int pins)
        {
            
            for (int i = 0; i < n; i++)
            {
                game.Roll(pins);
            }
        } //Privat Testmetod, inte bunden till originalkoden

        [Fact(DisplayName = "Every Roll() will miss on each frame, will the score return the correct value?")]
        public void HitZeroPinsEachFrame()
        {

            //Arrange - Given
            game = (Game)SetUpGame();
            var result = game.Score();


            //Act - When
            MultipleRolls(20, 0);


            //Assert - Then
            Assert.Equal(0, result);

        }

        [Fact(DisplayName = "Hit 1 pin each round(2 rounds per Frame) with Roll(), will the score return the correct value?")]
        public void HitOnePinEachFrame()
        {

            //Arrange - Given
            game = (Game)SetUpGame();
            var result = game.Score();


            //Act - When
            MultipleRolls(20, 1);


            //Assert - Then
            Assert.Equal(20, result);

        }

        [Fact(DisplayName = "Testing if 'Spare' hits are calculated correctly")]
        void TestSpare()
        {
            game = (Game)SetUpGame();
            var result = game.Score();

            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            MultipleRolls(17, 0);
            Assert.Equal(16, result);
        }
    }
}
