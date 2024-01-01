using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DrawingModel.Tests
{
    [TestClass]
    public class PairTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Pair pair = new Pair(1, 2);
            Assert.AreEqual(1, pair.Number1);
            Assert.AreEqual(2, pair.Number2);
        }

        [TestMethod]
        public void GetInfoMethodTest()
        {
            Pair pair = new Pair(1, 2);
            string info = pair.GetInfo();
            Assert.AreEqual("1.00,2.00", info);
        }

        [TestMethod]
        public void CopyConstructorTest()
        {
            Pair pair = new Pair(1, 2);
            Pair newPair = new Pair(pair);
            Assert.AreEqual(1, newPair.Number1);
            Assert.AreEqual(2, newPair.Number2);
        }

        [TestMethod]
        public void MinusOperatorTest()
        {
            Pair pair1 = new Pair(5, 7);
            Pair pair2 = new Pair(2, 3);
            Pair result = pair1 - pair2;
            Assert.AreEqual(3, result.Number1);
            Assert.AreEqual(4, result.Number2);
        }

        [TestMethod]
        public void PlusOperatorTest()
        {
            Pair pair1 = new Pair(5, 7);
            Pair pair2 = new Pair(2, 3);
            Pair result = pair1 + pair2;
            Assert.AreEqual(7, result.Number1);
            Assert.AreEqual(10, result.Number2);
        }

        [TestMethod]
        public void AbsOperatorTest()
        {
            Pair pair = new Pair(-3, -4);
            Pair result = ~pair;
            Assert.AreEqual(3, result.Number1);
            Assert.AreEqual(4, result.Number2);
        }

        [TestMethod]
        public void DivideOperatorTest()
        {
            Pair pair = new Pair(6, 3);
            int divisor = 2;
            Pair result = pair / divisor;
            Assert.AreEqual(3, result.Number1);
            Assert.AreEqual(1.5, result.Number2);
        }

        [TestMethod]
        public void GreaterThanOrEqualOperatorTest()
        {
            Pair pair1 = new Pair(3, 5);
            Pair pair2 = new Pair(2, 4);
            bool result = pair1 >= pair2;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LessThanOrEqualOperatorTest()
        {
            Pair pair1 = new Pair(2, 4);
            Pair pair2 = new Pair(3, 5);
            bool result = pair1 <= pair2;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GreaterThanOrEqualOperatorTest2()
        {
            Pair pair1 = new Pair(2, 4);
            Pair pair2 = new Pair(3, 5);
            bool result = pair1 >= pair2;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LessThanOrEqualOperatorTest2()
        {
            Pair pair1 = new Pair(3, 5);
            Pair pair2 = new Pair(2, 4);
            bool result = pair1 <= pair2;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PairAbsoluteValueOperator_ShouldReturnAbsoluteValues()
        {
            Pair originalPair = new Pair(-5, 10);
            Pair absoluteValuePair = ~originalPair;
            Assert.AreEqual(Math.Abs(originalPair.Number1), absoluteValuePair.Number1);
            Assert.AreEqual(Math.Abs(originalPair.Number2), absoluteValuePair.Number2);
        }

        [TestMethod]
        public void EqualityOperator_Equals_ReturnsTrue()
        {
            // Arrange
            Pair pair1 = new Pair(10.0f, 20.0f);
            Pair pair2 = new Pair(10.0f, 20.0f);

            // Act
            bool result = pair1 == pair2;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EqualityOperator_NotEquals_ReturnsFalse()
        {
            // Arrange
            Pair pair1 = new Pair(10.0f, 20.0f);
            Pair pair2 = new Pair(15.0f, 25.0f);

            // Act
            bool result = pair1 == pair2;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InequalityOperator_Equals_ReturnsFalse()
        {
            // Arrange
            Pair pair1 = new Pair(10.0f, 20.0f);
            Pair pair2 = new Pair(10.0f, 20.0f);

            // Act
            bool result = pair1 != pair2;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InequalityOperator_NotEquals_ReturnsTrue()
        {
            // Arrange
            Pair pair1 = new Pair(10.0f, 20.0f);
            Pair pair2 = new Pair(15.0f, 25.0f);

            // Act
            bool result = pair1 != pair2;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MultiplicationOperator_MultiplyByNumber_ReturnsCorrectResult()
        {
            // Arrange
            Pair pair = new Pair(5.0f, 10.0f);
            int multiplier = 3;

            // Act
            Pair result = pair * multiplier;

            // Assert
            Assert.AreEqual(15.0f, result.Number1);
            Assert.AreEqual(30.0f, result.Number2);
        }

        [TestMethod]
        public void ToStringTest()
        {
            Pair pair = new Pair(5.0f, 10.0f);
            pair.ToString();
        }

        [TestMethod]
        public void EqualsTest() {
            Pair pair = new Pair(5.0f, 10.0f);
            pair.GetHashCode();
        }
    }
}
