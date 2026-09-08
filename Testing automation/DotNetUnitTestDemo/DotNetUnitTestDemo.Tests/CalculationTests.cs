namespace DotNetUnitTestDemo.Tests
{
    [TestClass]
    public sealed class CalculationTests
    {
        [TestMethod]
        public void SumCalculation()
        {
            // arrange
            int a = 5;
            int b = 6;
            int expected = a + b;

            // act
            int result = Calculations.Sum(a, b);

            // assert
            Assert.AreEqual(expected, result);
        }
    }
}
