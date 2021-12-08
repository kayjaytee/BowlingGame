using Xunit;

namespace BowlingGame
{
    public class BowlingTest
    {
        private Game game;
        internal object SetUpGame() //Gammal Lösning: game = (Game)SetUpGame();
        {
            game = new Game();
            return game;
        }

        #region Privata Metoder; Specifikt för Tester
        private object Result()
        {
            return game.Score();
        }

        private void SingleRoll(int pins)
        {
            game.Roll(pins);
        }

        private void MultipleRolls(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                SingleRoll(pins);
            }
        }
        private void RollSpare()
        {
            SingleRoll(5);
            SingleRoll(5);
        }
        private void RollStrike()
        {
            game.Roll(10);
        }
        #endregion

        [Fact(DisplayName = "Every Roll() will miss on each frame, will the score return the correct value?")]
        [Trait("Category:", "Unit Testing")]
        private void HitZeroPinsEachFrame()
        {

            //Arrange - Given
            SetUpGame();

            //Act - When

            MultipleRolls(20, 0);

            //Assert - Then
            Assert.Equal(0, Result());

        }

        [Fact(DisplayName = "Hit 1 pin each round(2 rounds per Frame) with Roll(), will the score return the correct value?")]
        [Trait("Category:", "Unit Testing")]
        private void HitOnePinEachFrame()
        {

            //Arrange - Given
            SetUpGame();


            //Act - When
            MultipleRolls(20, 1);


            //Assert - Then
            Assert.Equal(20, Result());

        }

        [Fact(DisplayName = "Testing if 'Spare' hits are calculated correctly")]
        [Trait("Category:", "Unit Testing")]
        private void TestSpare()
        {
            //Arrange - Given
            SetUpGame();

            //Act - When
            RollSpare();
            SingleRoll(3);
            MultipleRolls(17, 0);

            //Assert - Then
            Assert.Equal(16, Result());
        }

        [Fact(DisplayName = "ONE STRIKE! Does it return the correct value?")]
        [Trait("Category:", "Unit Testing")]
        private void TestOneStrike()
        {
            //Arrange - Given
            SetUpGame();

            RollStrike(); //10 (3 + 4) = 17
            SingleRoll(3); // (3 + 4)
            SingleRoll(4); // = Total 24
            Assert.Equal(24, Result()); //Old: Actual result 20
        }

        [Fact(DisplayName = "With perfect score, will the values applied be correct?")]
        [Trait("Category:", "Unit Testing")]
        private void TestPerfectGame()
        {
        
            SetUpGame();
   
            MultipleRolls(12, 10);

            Assert.Equal(300, Result());
        }

        [Fact(DisplayName = "Test by K-J: F1 Spare > F2 5+0 > F3 STRIKE!!! > F4 5+3 = Return Result")]
        [Trait ("PersonalTests:", "Karl-Johan")]
        private void KayJayTest()
        {
            SetUpGame();

            RollSpare(); //Frame 1

            SingleRoll(5); //Frame 2
            SingleRoll(0);

            RollStrike(); //Frame 3

            SingleRoll(5); //Frame 4
            SingleRoll(3);


            Assert.Equal(46, Result());

        }

        [Fact(DisplayName = "Jonathan Test")]
        [Trait("PersonalTests:", "Jonathan")]
        private void JonathanTest()
        {                               // 1     2     2
            SetUpGame(); // (10) + (5) + (5) 
            MultipleRolls(1, 10); // Räknar 2 nästa kast, (10) + (5) + (5), Frame 1 = 20.
            MultipleRolls(3, 5); // Frame 2 = (5) + (5), + 5 nästa. Total = 35
                                 // Frame 3 = (5) = Total 40
            Assert.Equal(40, Result());
        }

        [Fact(DisplayName = "Mr oliver Test")]
        [Trait("PersonalTests:", "Mr Oliver Test")]
        void MrOliverTest()
            {
             game = (Game)SetUpGame();   //
             MultipleRolls(1, 5);
             MultipleRolls(2, 10);

             Assert.Equal(25, game.Score());
            }
    }

}
        

    
