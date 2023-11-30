using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;

namespace DrawingModel.Tests
{
    [TestClass]
    public class PairTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            // Arrange
            Pair pair = new Pair(1, 2);

            // Act
            // Assert
            Assert.AreEqual(1, pair.Number1);
            Assert.AreEqual(2, pair.Number2);
        }

        [TestMethod]
        public void GetInfoMethodTest()
        {
            // Arrange
            Pair pair = new Pair(1, 2);

            // Act
            string info = pair.GetInfo();

            // Assert
            Assert.AreEqual("1,2", info);
        }

        [TestMethod]
        public void CopyConstructorTest()
        {
            // Arrange
            Pair pair = new Pair(1, 2);

            // Act
            Pair newPair = new Pair(pair);

            // Assert
            Assert.AreEqual(1, newPair.Number1);
            Assert.AreEqual(2, newPair.Number2);
        }

        [TestMethod]
        public void MinusOperatorTest()
        {
            // Arrange
            Pair pair1 = new Pair(5, 7);
            Pair pair2 = new Pair(2, 3);

            // Act
            Pair result = pair1 - pair2;

            // Assert
            Assert.AreEqual(3, result.Number1);
            Assert.AreEqual(4, result.Number2);
        }

        [TestMethod]
        public void PlusOperatorTest()
        {
            // Arrange
            Pair pair1 = new Pair(5, 7);
            Pair pair2 = new Pair(2, 3);

            // Act
            Pair result = pair1 + pair2;

            // Assert
            Assert.AreEqual(7, result.Number1);
            Assert.AreEqual(10, result.Number2);
        }

        // Add similar tests for other operators...

        [TestMethod]
        public void AbsOperatorTest()
        {
            // Arrange
            Pair pair = new Pair(-3, -4);

            // Act
            Pair result = ~pair;

            // Assert
            Assert.AreEqual(3, result.Number1);
            Assert.AreEqual(4, result.Number2);
        }

        [TestMethod]
        public void DivideOperatorTest()
        {
            // Arrange
            Pair pair = new Pair(6, 3);
            int divisor = 2;

            // Act
            Pair result = pair / divisor;

            // Assert
            Assert.AreEqual(3, result.Number1);
            Assert.AreEqual(1.5, result.Number2);
        }

        [TestMethod]
        public void GreaterThanOrEqualOperatorTest()
        {
            // Arrange
            Pair pair1 = new Pair(3, 5);
            Pair pair2 = new Pair(2, 4);

            // Act
            bool result = pair1 >= pair2;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LessThanOrEqualOperatorTest()
        {
            // Arrange
            Pair pair1 = new Pair(2, 4);
            Pair pair2 = new Pair(3, 5);

            // Act
            bool result = pair1 <= pair2;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GreaterThanOrEqualOperatorTest2()
        {
            // Arrange
            Pair pair1 = new Pair(2, 4);
            Pair pair2 = new Pair(3, 5);

            // Act
            bool result = pair1 >= pair2;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LessThanOrEqualOperatorTest2()
        {
            // Arrange
            Pair pair1 = new Pair(3, 5);
            Pair pair2 = new Pair(2, 4);

            // Act
            bool result = pair1 <= pair2;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PairAbsoluteValueOperator_ShouldReturnAbsoluteValues()
        {
            // Arrange
            Pair originalPair = new Pair(-5, 10);

            // Act
            Pair absoluteValuePair = ~originalPair;

            // Assert
            Assert.AreEqual(Math.Abs(originalPair.Number1), absoluteValuePair.Number1, "Absolute value of Number1 should be computed correctly.");
            Assert.AreEqual(Math.Abs(originalPair.Number2), absoluteValuePair.Number2, "Absolute value of Number2 should be computed correctly.");
        }

    }
}
