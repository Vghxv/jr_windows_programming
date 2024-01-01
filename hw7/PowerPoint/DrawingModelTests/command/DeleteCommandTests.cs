using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DrawingModel.Tests
{
    [TestClass]
    public class DeleteCommandTests
    {
        private Mock<Model> modelMock;
        private Mock<Shape> shapeMock;
        private DeleteCommand deleteCommand;

        [TestInitialize]
        public void TestInitialize()
        {
            modelMock = new Mock<Model>();
            shapeMock = new Mock<Shape>();
            deleteCommand = new DeleteCommand(modelMock.Object, shapeMock.Object);
        }

        [TestMethod]
        public void Execute_ShouldRemoveShapeFromModelAndSetIsSelectedToFalse()
        {
            // Act
            deleteCommand.Execute();

            // Assert
            modelMock.Verify(m => m.RemoveShape(shapeMock.Object), Times.Once);
        }



        [TestMethod]
        public void ReverseExecute_ShouldAddShapeToModel()
        {
            // Act
            deleteCommand.ReverseExecute();

            // Assert
            modelMock.Verify(m => m.AddShape(shapeMock.Object), Times.Once);
        }
    }
}
