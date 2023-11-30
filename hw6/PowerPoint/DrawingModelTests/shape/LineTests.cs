using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DrawingModel.Tests
{
    [TestClass]
    public class LineTests
    {
        Line _line;
        PrivateObject _privateObject;

        [TestInitialize]
        public void Initialize()
        {
            _line = new Line();
            _privateObject = new PrivateObject(_line);
        }

        [TestMethod]
        public void LineConstructorTest()
        {
            Assert.IsNotNull(_line);
            Assert.AreEqual(Constant.LINE_CHINESE, _line.NameChinese);
        }

        [TestMethod]
        public void LineConstructorWithPairsTest()
        {
            Pair firstPair = new Pair(1, 1);
            Pair secondPair = new Pair(3, 3);
            _line = new Line(firstPair, secondPair);
            _privateObject = new PrivateObject(_line);
            Assert.AreEqual(Constant.LINE_CHINESE, _line.NameChinese);
            Assert.AreEqual(firstPair, _line.FirstPair);
            Assert.AreEqual(secondPair, _line.SecondPair);
        }

        [TestMethod]
        public void GetInfoTest()
        {
            Pair firstPair = new Pair(1, 1);
            Pair secondPair = new Pair(3, 3);
            _line = new Line(firstPair, secondPair);
            _privateObject = new PrivateObject(_line);
            Assert.AreEqual($"({firstPair.GetInfo()}),({secondPair.GetInfo()})", _line.GetInfo());
        }

        [TestMethod]
        public void DrawTest_IsSelected()
        {
            Mock<IGraphics> mockGraphics = new Mock<IGraphics>();
            Pair firstPair = new Pair(1, 1);
            Pair secondPair = new Pair(3, 3);
            _line = new Line(firstPair, secondPair);
            _line.IsSelected = true;
            // Act
            _line.Draw(mockGraphics.Object);
            // Assert
            mockGraphics.Verify(x => x.DrawLine(firstPair, secondPair), Times.Once);
        }

        [TestMethod]
        public void DrawTest_IsNotSelected()
        {
            Mock<IGraphics> mockGraphics = new Mock<IGraphics>();
            Pair firstPair = new Pair(1, 1);
            Pair secondPair = new Pair(300, 300);
            _line = new Line(firstPair, secondPair);
            _line.IsSelected = false;
            // Act
            _line.Draw(mockGraphics.Object);
            // Assert
            mockGraphics.Verify(x => x.DrawLine(firstPair, secondPair), Times.Once);
            mockGraphics.Verify(x => x.DrawLineHandle(firstPair, secondPair), Times.Never);
        }

        [TestMethod]
        public void IsInBox()
        {
            // Arrange
            Pair topLeftPair = new Pair(10, 10);
            Pair bottomRightPair = new Pair(20, 20);
            Assert.IsTrue((bool)_privateObject.Invoke("IsInBox", new Pair(15, 15), topLeftPair, bottomRightPair));
            Assert.IsFalse((bool)_privateObject.Invoke("IsInBox", new Pair(0, 0), topLeftPair, bottomRightPair));
            Assert.IsFalse((bool)_privateObject.Invoke("IsInBox", new Pair(200, 200), topLeftPair, bottomRightPair));
            Assert.IsFalse((bool)_privateObject.Invoke("IsInBox", new Pair(15, 200), topLeftPair, bottomRightPair));
            Assert.IsFalse((bool)_privateObject.Invoke("IsInBox", new Pair(200, 15), topLeftPair, bottomRightPair));
        }

        [TestMethod]
        public void IsInShapeTest_IsInShape()
        {
            // Arrange
            Pair firstPair = new Pair(1, 1);
            Pair secondPair = new Pair(3, 3);
            Line line = new Line(firstPair, secondPair);

            // Act
            bool isInShape = line.IsInShape(2, 2);

            // Assert
            Assert.IsTrue(isInShape);
        }

        [TestMethod]
        public void IsInShapeTest_IsNotInShape()
        {
            // Arrange
            Pair firstPair = new Pair(1, 1);
            Pair secondPair = new Pair(3, 3);
            Line line = new Line(firstPair, secondPair);

            // Act
            bool isInShape = line.IsInShape(4, 100);

            // Assert
            Assert.IsFalse(isInShape);
        }

        [TestMethod]
        public void IsInBoxTest_IsInBox()
        {
            // Arrange
            Line line = new Line();
            Pair topLeftPair = new Pair(10, 10);
            Pair bottomRightPair = new Pair(20, 20);

            // Act
            // Assert
            Assert.IsTrue(line.IsInBox(new Pair(15, 15), topLeftPair, bottomRightPair));
            Assert.IsTrue(line.IsInBox(new Pair(29, 29), topLeftPair, bottomRightPair));
            Assert.IsTrue(line.IsInBox(new Pair(1, 29), topLeftPair, bottomRightPair));
            Assert.IsTrue(line.IsInBox(new Pair(29, 1), topLeftPair, bottomRightPair));
            Assert.IsTrue(line.IsInBox(new Pair(15, 29), topLeftPair, bottomRightPair));
            Assert.IsTrue(line.IsInBox(new Pair(29, 15), topLeftPair, bottomRightPair));
        }

        [TestMethod]
        public void IsInBoxTest_IsNotInBox()
        {
            // Arrange
            Line line = new Line();
            Pair topLeftPair = new Pair(10, 10);
            Pair bottomRightPair = new Pair(20, 20);

            // Acta
            // Assert
            Assert.IsFalse(line.IsInBox(new Pair(0, 0), topLeftPair, bottomRightPair));
            Assert.IsFalse(line.IsInBox(new Pair(200, 200), topLeftPair, bottomRightPair));
            Assert.IsFalse(line.IsInBox(new Pair(0, 200), topLeftPair, bottomRightPair));
            Assert.IsFalse(line.IsInBox(new Pair(200, 0), topLeftPair, bottomRightPair));
            Assert.IsFalse(line.IsInBox(new Pair(30, 200), topLeftPair, bottomRightPair));
            Assert.IsFalse(line.IsInBox(new Pair(200, 30), topLeftPair, bottomRightPair));

        }

        [TestMethod]
        public void CalculateDistanceTest()
        {
            // using private object to test private method
            // Arrange
            Pair firstPair = new Pair(1, 1);
            Pair secondPair = new Pair(3, 3);
            _line = new Line(firstPair, secondPair);
            // Act
            double distance = (double)_privateObject.Invoke("CalculateDistance", 2, 2);
            // Assert
            Assert.AreEqual(0, distance);
        }
    }
}
