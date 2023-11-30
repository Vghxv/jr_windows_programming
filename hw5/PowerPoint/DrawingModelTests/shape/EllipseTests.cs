using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DrawingModel.Tests
{
    [TestClass]
    public class EllipseTests
    {
        Ellipse _ellipse;
        PrivateObject _privateObject;

        [TestInitialize]
        public void Initialize()
        {
            _ellipse = new Ellipse();
            _privateObject = new PrivateObject(_ellipse);
        }

        [TestMethod]
        public void EllipseConstructorTest()
        {
            Assert.IsNotNull(_ellipse);
            Assert.AreEqual(Constant.ELLIPSE_CHINESE, _ellipse.NameChinese);
        }

        [TestMethod]
        public void EllipseConstructorWithPairsTest()
        {
            Pair firstPair = new Pair(1, 1);
            Pair secondPair = new Pair(3, 3);
            _ellipse = new Ellipse(firstPair, secondPair);
            _privateObject = new PrivateObject(_ellipse);
            Assert.AreEqual(Constant.ELLIPSE_CHINESE, _ellipse.NameChinese);
            Assert.AreEqual(firstPair, _ellipse.FirstPair);
            Assert.AreEqual(secondPair, _ellipse.SecondPair);
        }

        [TestMethod]
        public void GetInfoTest()
        {
            Pair firstPair = new Pair(1, 1);
            Pair secondPair = new Pair(3, 3);
            _ellipse = new Ellipse(firstPair, secondPair);
            _privateObject = new PrivateObject(_ellipse);
            Assert.AreEqual($"({firstPair.GetInfo()}),({secondPair.GetInfo()})", _ellipse.GetInfo());
        }

        [TestMethod]
        public void DrawTest_IsSelected()
        {
            Mock<IGraphics> mockGraphics = new Mock<IGraphics>();
            Pair firstPair = new Pair(1, 1);
            Pair secondPair = new Pair(3, 3);
            _ellipse = new Ellipse(firstPair, secondPair);
            _ellipse.IsSelected = true;
            _ellipse.Draw(mockGraphics.Object);
            mockGraphics.Verify(x => x.DrawEllipse(firstPair, secondPair), Times.Once);
        }

        [TestMethod]
        public void DrawTest_IsNotelected()
        {
            Mock<IGraphics> mockGraphics = new Mock<IGraphics>();
            Pair firstPair = new Pair(1, 1);
            Pair secondPair = new Pair(3, 3);
            _ellipse = new Ellipse(firstPair, secondPair);
            _ellipse.IsSelected = false;
            _ellipse.Draw(mockGraphics.Object);
            mockGraphics.Verify(x => x.DrawEllipse(firstPair, secondPair), Times.Once);
        }

        [TestMethod]
        public void IsInShapeTest()
        {
            Pair firstPair = new Pair(10, 10);
            Pair secondPair = new Pair(30, 30);
            _ellipse = new Ellipse(firstPair, secondPair);
            _privateObject = new PrivateObject(_ellipse);
            Assert.IsTrue(_ellipse.IsInShape(20, 20));
            Assert.IsFalse(_ellipse.IsInShape(50, 50));
            Assert.IsFalse(_ellipse.IsInShape(0, 20));
            Assert.IsFalse(_ellipse.IsInShape(20, 0));
        }
    }
}
