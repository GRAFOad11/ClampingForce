namespace Moulding.Tests
{
    public class MouldingTests
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var forces = new Foce("Casing");
            forces.AddDimension(5, 2);
            //act
            var result = forces.GetStatistics();
            //assert
            Assert.Equal(3.5, result.Averidge, 1);
            Assert.Equal(5, result.High);
            Assert.Equal(2, result.Low);
        }
    }

}
