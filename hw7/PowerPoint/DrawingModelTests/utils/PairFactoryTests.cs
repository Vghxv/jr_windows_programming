using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingModel.Tests
{
    [TestClass]
    public class PairFactoryTests
    {
        [TestMethod]
        public void CreateDoubleNumber_Test()
        {
            float number1 = 1.5f;
            float number2 = 2.5f;
            Pair pair = PairFactory.CreatePair(number1, number2);
            Assert.IsNotNull(pair);
            Assert.AreEqual(number1, pair.Number1);
            Assert.AreEqual(number2, pair.Number2);
        }

        [TestMethod]
        public void CreateRandomDoubleNumber_Test()
        {
            int minimumX = 1;
            int maximumX = 10;
            int minimumY = 5;
            int maximumY = 15;
            Pair pair1 = new Pair(minimumX, maximumX);
            Pair pair2 = new Pair(minimumY, maximumY);
            Pair randomPair = PairFactory.CreateRandomPair(pair1, pair2, 0);
            Assert.IsNotNull(randomPair);
            Assert.IsTrue(randomPair.Number1 >= minimumX && randomPair.Number1 < maximumX);
            Assert.IsTrue(randomPair.Number2 >= minimumY && randomPair.Number2 < maximumY);
        }
    }
}
