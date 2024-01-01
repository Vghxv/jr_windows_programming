using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DrawingModel.Tests
{
    [TestClass]
    public class DrawCommandTests
    {
        private Mock<Model> modelMock;
        private Mock<Shape> shapeMock;
        private DrawCommand drawCommand;

        [TestInitialize]
        public void TestInitialize()
        {
            modelMock = new Mock<Model>();
            shapeMock = new Mock<Shape>();
            drawCommand = new DrawCommand(modelMock.Object, shapeMock.Object);
        }

        [TestMethod]
        public void Execute_ShouldAddShapeToModel()
        {
            // Act
            drawCommand.Execute();

            // Assert
            modelMock.Verify(m => m.AddShape(shapeMock.Object), Times.Once);
        }

        [TestMethod]
        public void ReverseExecute_ShouldRemoveShapeFromModel()
        {
            // Act
            drawCommand.ReverseExecute();

            // Assert
            modelMock.Verify(m => m.RemoveShape(shapeMock.Object), Times.Once);
        }
    }
}
