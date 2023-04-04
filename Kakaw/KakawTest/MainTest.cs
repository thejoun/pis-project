namespace KakawTest
{
    public class MainTest
    {
        [Fact]
        public void SumTest()
        {
            var sum = Kakaw.Program.Add(4, 5);
            
            Assert.Equal(9, sum);
        }
    }
}