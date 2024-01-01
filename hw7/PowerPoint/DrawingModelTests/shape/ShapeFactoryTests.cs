using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingModel.Tests
{
    [TestClass]
    public class ShapeFactoryTests
    {
        [TestMethod]
        public void CreateShape_WithParameters_Test()
        {
            string shapeName = "DrawingModel.Rectangle";
            Pair firstPair = new Pair(1, 2);
            Pair secondPair = new Pair(3, 4);
            Shape shape = ShapeFactory.CreateShape(shapeName, firstPair, secondPair);
            Assert.IsNotNull(shape);
            Assert.AreEqual(shapeName, shape.GetType().FullName);
            Assert.AreEqual(firstPair, shape.FirstPair);
            Assert.AreEqual(secondPair, shape.SecondPair);
        }

        [TestMethod]
        public void CreateShape_WithoutParameters_Test()
        {
            string shapeName = "DrawingModel.Ellipse";
            Shape shape = ShapeFactory.CreateShape(shapeName);
            Assert.IsNotNull(shape);
            Assert.AreEqual(shapeName, shape.GetType().FullName);
        }
    }
}
