using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace DrawingModel.Tests
{

    [TestClass]
    public class AddCommandTests
    {
        private Mock<Model> modelMock;
        private Mock<Shape> shapeMock;
        private AddCommand addCommand;

        [TestInitialize]
        public void SetUp()
        {
            // This method will be called before each test method

            // Create new mocks for Model and Shape
            modelMock = new Mock<Model>();
            shapeMock = new Mock<Shape>();

            // Create a new AddCommand with the mocks
            addCommand = new AddCommand(modelMock.Object, shapeMock.Object);
        }

        [TestMethod]
        public void Execute_ShouldAddShapeToModel()
        {
            // Act
            addCommand.Execute();

            // Assert
            modelMock.Verify(m => m.AddShape(shapeMock.Object), Times.Once);
        }

        [TestMethod]
        public void ReverseExecute_ShouldRemoveShapeFromModel()
        {
            // Act
            addCommand.ReverseExecute();

            // Assert
            modelMock.Verify(m => m.RemoveShape(shapeMock.Object), Times.Once);
        }
    }
}