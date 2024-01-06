using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace DrawingModel.Tests
{
    [TestClass]
    public class IdleStateTests
    {
        [TestMethod]
        public void MouseUp_ShouldSelectShape()
        {
            // Arrange
            Model model = new Model();
            IdleState idleState = new IdleState(model);
            Rectangle shape = new Rectangle(new Pair(0, 0), new Pair(3, 8)); // Replace with the actual shape you are using

            // Add the shape to the model
            model.AddShape(shape);

            // Act
            idleState.MouseUp(1, 1);

            // Assert
            Assert.IsTrue(shape.IsSelected);
            Assert.IsInstanceOfType(model.CurrentState, typeof(SelectingState), "State should be changed to SelectingState.");
        }

        [TestMethod]
        public void MouseUp_ShouldNotSelectShape()
        {
            // Arrange
            Model model = new Model();
            IdleState idleState = new IdleState(model);
            Rectangle shape = new Rectangle(new Pair(50, 50), new Pair(80, 100));

            // Add the shape to the model
            model.AddShape(shape);

            // Act
            idleState.MouseUp(1, 1);

            // Assert
            Assert.IsFalse(shape.IsSelected);
            Assert.IsNotInstanceOfType(model.CurrentState, typeof(SelectingState), "State should not be changed to SelectingState.");
        }

        [TestMethod]
        public void MouseMove()
        {
            // Arrange
            Model model = new Model();
            IdleState idleState = new IdleState(model);

            // Act
            idleState.MouseMove(1, 1);

            // Assert
            // Add assertions based on the expected behavior of MouseMove in the IdleState
        }

        [TestMethod]
        public void MouseUp()
        {
            // Arrange
            Model model = new Model();
            IdleState idleState = new IdleState(model);

            // Act
            idleState.MouseUp(1, 1);

            // Assert
            // Add assertions based on the expected behavior of MouseUp in the IdleState
        }

        [TestMethod]
        public void KeyPressed()
        {
            // Arrange
            Model model = new Model();
            IdleState idleState = new IdleState(model);

            // Act
            idleState.KeyPressed(Keys.A);

            // Assert
            // Add assertions based on the expected behavior of KeyPressed in the IdleState
        }

        [TestMethod]
        public void Draw()
        {
            // Arrange
            Model model = new Model();
            IdleState state = new IdleState(model);
            MockGraphics mockGraphics = new MockGraphics();

            // Act
            state.Draw(mockGraphics);

            // Assert
            Assert.IsFalse(mockGraphics.DrawLineCalled);
            Assert.IsFalse(mockGraphics.DrawEllipseCalled);
            Assert.IsFalse(mockGraphics.DrawRectangleCalled);
            Assert.IsFalse(mockGraphics.DrawLineHandleCalled);
            Assert.IsFalse(mockGraphics.DrawRectangleHandleCalled);
        }
    }
}