using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;

namespace DrawingModel.Tests
{
    [TestClass]
    public class PairFactoryTests
    {
        [TestMethod]
        public void CreateDoubleNumber_Test()
        {
            // Arrange
            float number1 = 1.5f;
            float number2 = 2.5f;

            // Act
            Pair pair = PairFactory.CreateDoubleNumber(number1, number2);

            // Assert
            Assert.IsNotNull(pair);
            Assert.AreEqual(number1, pair.Number1);
            Assert.AreEqual(number2, pair.Number2);
        }

        [TestMethod]
        public void CreateRandomDoubleNumber_Test()
        {
            // Arrange
            int minimumX = 1;
            int maximumX = 10;
            int minimumY = 5;
            int maximumY = 15;

            // Act
            Pair randomPair = PairFactory.CreateRandomDoubleNumber(minimumX, maximumX, minimumY, maximumY);

            // Assert
            Assert.IsNotNull(randomPair);
            Assert.IsTrue(randomPair.Number1 >= minimumX && randomPair.Number1 < maximumX);
            Assert.IsTrue(randomPair.Number2 >= minimumY && randomPair.Number2 < maximumY);
        }
    }
}
