using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DrawingModel.Tests
{
    [TestClass]
    public class MoveCommandTests
    {
        private Mock<Model> modelMock;
        private Mock<Shape> shapeMock;
        private MoveCommand moveCommand;

        [TestInitialize]
        public void TestInitialize()
        {
            modelMock = new Mock<Model>();
            shapeMock = new Mock<Shape>();
            moveCommand = new MoveCommand(modelMock.Object, shapeMock.Object, new Pair(10, 5)); // Example offset values
        }

        [TestMethod]
        public void Execute_ShouldMoveShapeWhenNotFirstTime()
        {
            // Arrange
            moveCommand = new MoveCommand(modelMock.Object, shapeMock.Object, new Pair(10, 5));
            moveCommand.Execute(); // Call Execute once to set _firstTime to false

            // Act
            moveCommand.Execute();

            // Assert
            modelMock.Verify(m => m.MoveShape(shapeMock.Object, It.IsAny<Pair>()), Times.Once);
        }


        [TestMethod]
        public void Execute_ShouldNotMoveShapeWhenFirstTime()
        {
            // Arrange
            moveCommand = new MoveCommand(modelMock.Object, shapeMock.Object, new Pair(10, 5)); // Example offset values

            // Act
            moveCommand.Execute();

            // Assert
            modelMock.Verify(m => m.MoveShape(shapeMock.Object, It.IsAny<Pair>()), Times.Never);
        }

        [TestMethod]
        public void ReverseExecute_ShouldMoveShapeBackward()
        {
            // Act
            moveCommand.ReverseExecute();

            // Assert
            modelMock.Verify(m => m.MoveShape(shapeMock.Object, It.Is<Pair>(offset => offset.Number1 == -10 && offset.Number2 == -5)), Times.Once);
        }
    }
}
