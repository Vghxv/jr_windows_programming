using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DrawingModel.Tests
{
    [TestClass]
    public class RectangleTests
    {
        Rectangle _rectangle;

        [TestInitialize]
        public void Initialize()
        {
            _rectangle = new Rectangle();
        }

        [TestMethod]
        public void RectangleConstructorTest()
        {
            Assert.IsNotNull(_rectangle);
        }

        [TestMethod]
        public void RectangleConstructorWithPairsTest()
        {
            Pair firstPair = new Pair(0, 0);
            Pair secondPair = new Pair(2, 2);
            _rectangle = new Rectangle(firstPair, secondPair);

            Assert.IsNotNull(_rectangle);
            Assert.AreEqual(firstPair, _rectangle.FirstPair);
            Assert.AreEqual(secondPair, _rectangle.SecondPair);
        }

        [TestMethod]
        public void GetInfoTest()
        {
            Pair firstPair = new Pair(1, 1);
            Pair secondPair = new Pair(3, 3);
            _rectangle = new Rectangle(firstPair, secondPair);
            Assert.AreEqual($"({firstPair.GetInfo()}),({secondPair.GetInfo()})", _rectangle.GetInfo());
        }

        [TestMethod]
        public void DrawTest_IsSelected()
        {
            Mock<IGraphics> mockGraphics = new Mock<IGraphics>();
            Pair firstPair = new Pair(1, 1);
            Pair secondPair = new Pair(3, 3);
            _rectangle = new Rectangle(firstPair, secondPair);
            _rectangle.IsSelected = true;
            _rectangle.Draw(mockGraphics.Object);
            mockGraphics.Verify(x => x.DrawRectangle(firstPair, secondPair), Times.Once);
        }

        [TestMethod]
        public void DrawTest_IsNotSelected()
        {
            Mock<IGraphics> mockGraphics = new Mock<IGraphics>();
            Pair firstPair = new Pair(1, 1);
            Pair secondPair = new Pair(3, 3);
            _rectangle = new Rectangle(firstPair, secondPair);
            _rectangle.IsSelected = false;
            _rectangle.Draw(mockGraphics.Object);
            mockGraphics.Verify(x => x.DrawRectangle(firstPair, secondPair), Times.Once);
        }

        [TestMethod]
        public void IsInShapeTest()
        {
            Pair firstPair = new Pair(1, 1);
            Pair secondPair = new Pair(3, 3);
            _rectangle = new Rectangle(firstPair, secondPair);
            Assert.IsTrue(_rectangle.IsInShape(2, 2));
            Assert.IsFalse(_rectangle.IsInShape(2, 200));
        }
    }
}
