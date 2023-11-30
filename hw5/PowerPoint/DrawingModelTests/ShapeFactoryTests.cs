using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;

namespace DrawingModel.Tests
{
    [TestClass]
    public class ShapeFactoryTests
    {
        [TestMethod]
        public void CreateShape_WithParameters_Test()
        {
            // Arrange
            string shapeName = "DrawingModel.Rectangle"; // Assuming Rectangle is a valid shape name in your application
            Pair firstPair = new Pair(1, 2);
            Pair secondPair = new Pair(3, 4);

            // Act
            Shape shape = ShapeFactory.CreateShape(shapeName, firstPair, secondPair);

            // Assert
            Assert.IsNotNull(shape);
            Assert.AreEqual(shapeName, shape.GetType().FullName);
            Assert.AreEqual(firstPair, shape.FirstPair);
            Assert.AreEqual(secondPair, shape.SecondPair);
        }

        [TestMethod]
        public void CreateShape_WithoutParameters_Test()
        {
            // Arrange
            string shapeName = "DrawingModel.Ellipse"; // Assuming Ellipse is a valid shape name in your application

            // Act
            Shape shape = ShapeFactory.CreateShape(shapeName);

            // Assert
            Assert.IsNotNull(shape);
            Assert.AreEqual(shapeName, shape.GetType().FullName);
            // Add more assertions if needed for default parameters or specific behavior
        }
    }
}
