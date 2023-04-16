using RoomNumberTask.BusinessLogic;

namespace RoomNumberTask.Test
{
    public class RoomNumberTest
    {
     


        [Theory]
        [InlineData(122, 2)]
        [InlineData(9999, 2)]
        [InlineData(12635, 1)]
        [InlineData(888888, 6)]
        [InlineData(99, 1)]
        [InlineData(1, 1)]
        [InlineData(1000000, 6)]

        public void numberOfSets_ValidTest(int numberOfRoom, int expectedOutput)
        {
            IRoomNumber numb = new RoomNumber();
            
            int actual = numb.numberOfSets(numberOfRoom);

            Assert.Equal(expectedOutput, actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1000001)]
        [InlineData(-100)]

        public void numberOfSets_InputOutOfRangeTest(int numberOfRoom) 
        {
            IRoomNumber numb = new RoomNumber();

            Assert.Throws<ArgumentOutOfRangeException>(() => numb.numberOfSets(numberOfRoom));
        }
    }
}