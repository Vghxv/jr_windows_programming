using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace DrawingModel.Tests
{
    [TestClass]
    public class SelectingStateTests
    {
        // Helper method to create the Model with shapes
        private Model CreateModelWithShapes()
        {
            Model model = new Model();
            Rectangle rectangle = new Rectangle(new Pair(0, 0), new Pair(50, 160));
            Line line = new Line(new Pair(200, 200), new Pair(400, 500));
            model.AddShape(line);
            model.AddShape(rectangle);
            return model;
        }

        // Helper method to get the selected _rectangle
        private Shape GetSelectedShape(Model model)
        {
            foreach (Shape shape in model.GetCurrentPageShapes())
            {
                if (shape.IsSelected)
                {
                    return shape;
                }
            }
            return null;
        }

        [TestMethod]
        public void MouseDown_SelectInsideShape()
        {
            // Arrange
            Model model = CreateModelWithShapes();
            SelectingState selectingState = new SelectingState(model);

            // Act
            selectingState.MouseDown(1, 1);

            // Assert
            Assert.IsTrue(model.GetCurrentPageShapes()[1].IsSelected);
            Assert.IsTrue(selectingState.IsMousePressedOnSelected);
        }

        [TestMethod]
        public void MouseDown_SelectOutsideShape()
        {
            // Arrange
            Model model = CreateModelWithShapes();
            SelectingState selectingState = new SelectingState(model);

            // Act
            selectingState.MouseDown(100, 100);

            // Assert
            Assert.IsFalse(model.GetCurrentPageShapes()[0].IsSelected);
            Assert.IsFalse(selectingState.IsMousePressedOnSelected);
            Assert.IsInstanceOfType(model.CurrentState, typeof(IdleState), "State should be changed to IdleState.");
        }

        [TestMethod]
        public void MouseMove_WhenPressedOnSelected_ShouldMoveShape()
        {
            // Arrange
            Model model = CreateModelWithShapes();
            SelectingState selectingState = new SelectingState(model);
            selectingState.MouseDown(1, 1);

            // Act
            selectingState.MouseMove(3, 5);

            // Assert
            Shape selectedShape = null;
            foreach (Shape shape in model.GetCurrentPageShapes())
            {
                if (shape.IsSelected)
                {
                    selectedShape = shape;
                    break;
                }
            }

            Assert.IsNotNull(selectedShape, "A selected shape should be found.");
            Assert.AreEqual(2, selectedShape.FirstPair.Number1);
            Assert.AreEqual(4, selectedShape.FirstPair.Number2);
            Assert.AreEqual(52, selectedShape.SecondPair.Number1);
            Assert.AreEqual(164, selectedShape.SecondPair.Number2);
        }

        [TestMethod]
        public void MouseMove_WhenNotPressedOnSelected_ShouldNotMoveShape()
        {
            // Arrange
            Model model = CreateModelWithShapes();
            SelectingState selectingState = new SelectingState(model);
            Shape shape = model.GetCurrentPageShapes()[0];
            shape.IsSelected = true;
            model.AdjustPoint = shape.SecondPair;

            // Act
            selectingState.MouseDown(0, 0);
            selectingState.MouseMove(3, 5);

            // Assert
            Assert.AreEqual(200, shape.FirstPair.Number1);
            Assert.AreEqual(200, shape.FirstPair.Number2);
            Assert.AreEqual(400, shape.SecondPair.Number1);
            Assert.AreEqual(500, shape.SecondPair.Number2);
        }

        [TestMethod]
        public void MouseMoveOnAdjust_ShouldMoveShape()
        {
            // Arrange
            Model model = CreateModelWithShapes();
            SelectingState selectingState = new SelectingState(model);
            Rectangle rectangle = (Rectangle)model.GetCurrentPageShapes()[1];
            selectingState.MouseDown(29, 78); // Simulate pressing on a _rectangle
            selectingState.IsMousePressedOnAdjust = true;

            // Act
            selectingState.AdjustShapes(8, 10);

            // Assert
            Assert.IsTrue(rectangle.IsSelected);
            Assert.IsTrue(selectingState.IsMousePressedOnSelected);
            Assert.IsTrue(selectingState.IsMousePressedOnAdjust);
            Assert.AreEqual(0, rectangle.FirstPair.Number1);
            Assert.AreEqual(0, rectangle.FirstPair.Number2);
            Assert.AreEqual(29, rectangle.SecondPair.Number1);
            Assert.AreEqual(92, rectangle.SecondPair.Number2);

            // Act
            selectingState.AdjustShapes(100, 200);

            Assert.AreEqual(121, rectangle.SecondPair.Number1);
            Assert.AreEqual(282, rectangle.SecondPair.Number2);
        }

        [TestMethod]
        public void MouseUp_ShouldResetPressedFlags()
        {
            // Arrange
            Model model = CreateModelWithShapes();
            SelectingState selectingState = new SelectingState(model);
            Rectangle rectangle = (Rectangle)model.GetCurrentPageShapes()[1];
            selectingState.MouseDownCheck(5, 5); // Simulate pressing on a _rectangle
            selectingState.IsMousePressedOnAdjust = true;

            // Act
            selectingState.MouseUp(8, 10);

            // Assert
            Assert.IsFalse(selectingState.IsMousePressedOnSelected);
            Assert.IsFalse(selectingState.IsMousePressedOnAdjust);
        }

        [TestMethod]
        public void KeyPressed_ShouldRemoveSelectedShapeOnDelete()
        {
            // Arrange
            Model model = CreateModelWithShapes();
            SelectingState selectingState = new SelectingState(model);
            Rectangle rectangle = (Rectangle)model.GetCurrentPageShapes()[1];
            rectangle.IsSelected = true;

            // Act
            selectingState.KeyPressed(Keys.Delete);

            // Assert
            Assert.AreEqual(1, model.GetCurrentPageShapes().Count, "The selected shape should be removed.");
        }

        [TestMethod]
        public void KeyPressed_ShouldNotRemoveShapeOnNonDeleteKey()
        {
            // Arrange
            Model model = CreateModelWithShapes();
            SelectingState selectingState = new SelectingState(model);
            Rectangle shape = (Rectangle)model.GetCurrentPageShapes()[1];
            shape.IsSelected = true;

            // Act
            selectingState.KeyPressed(Keys.A); // A key is not Delete

            // Assert
            Assert.AreEqual(2, model.GetCurrentPageShapes().Count, "The shape should not be removed.");
        }

        [TestMethod]
        public void Draw_ShouldNotDrawAnything()
        {
            // Arrange
            Model model = new Model();
            SelectingState state = new SelectingState(model);
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

        [TestMethod]
        public void MouseMoveOnSelected_ShouldMoveSelectedShape()
        {
            // Arrange
            Model model = CreateModelWithShapes();
            SelectingState selectingState = new SelectingState(model);
            selectingState.MouseDown(1, 1);

            // Act
            selectingState.MoveShapes(3, 5);

            // Assert
            Shape selectedShape = GetSelectedShape(model);
            Assert.IsNotNull(selectedShape, "A selected shape should be found.");
            Assert.AreEqual(2, selectedShape.FirstPair.Number1);
            Assert.AreEqual(4, selectedShape.FirstPair.Number2);
            Assert.AreEqual(52, selectedShape.SecondPair.Number1);
            Assert.AreEqual(164, selectedShape.SecondPair.Number2);
        }

        [TestMethod]
        public void MouseMove_ShouldMoveSelectedShapeWhenPressedOnSelected()
        {
            // Arrange
            Model model = CreateModelWithShapes();
            SelectingState selectingState = new SelectingState(model);
            selectingState.MouseDown(1, 1);

            // Act
            selectingState.MouseMove(3, 5);

            // Assert
            Shape selectedShape = GetSelectedShape(model);
            Assert.IsNotNull(selectedShape, "A selected shape should be found.");
            Assert.AreEqual(2, selectedShape.FirstPair.Number1);
            Assert.AreEqual(4, selectedShape.FirstPair.Number2);
            Assert.AreEqual(52, selectedShape.SecondPair.Number1);
            Assert.AreEqual(164, selectedShape.SecondPair.Number2);
        }

        [TestMethod]
        public void MouseMove_ShouldSetIsCloseToAdjustWhenNotPressedOnSelected()
        {
            // Arrange
            Model model = CreateModelWithShapes();
            SelectingState selectingState = new SelectingState(model);

            // Act
            selectingState.MouseDown(30, 30);
            selectingState.MouseUp(30, 30);
            selectingState.MouseMove(45, 160);

            // Assert
            Assert.IsTrue(model.IsCloseToAdjust, "IsCloseToAdjust should be true when not pressed on selected.");
        }

        [TestMethod]
        public void MouseMove_ShouldCallMouseMoveOnAdujstWhenPressedOnAdjust()
        {
            // Arrange
            Model model = CreateModelWithShapes();
            SelectingState selectingState = new SelectingState(model);
            selectingState.IsMousePressedOnAdjust = true;

            // Act
            selectingState.MouseMove(3, 5);

            // Assert
        }

        [TestMethod]
        public void MouseMove_ShouldCallMouseMoveOnSelectedWhenPressedOnSelected()
        {
            // Arrange
            Model model = CreateModelWithShapes();
            SelectingState selectingState = new SelectingState(model);
            selectingState.IsMousePressedOnSelected = true;

            // Act
            selectingState.MouseMove(3, 5);

            // Assert
        }

        [TestMethod]
        public void MouseMove_ShouldSetIsCloseToAdjustAndNotifyModelChangedWhenNeitherPressedOnAdjustNorSelected()
        {
            // Arrange
            Model model = CreateModelWithShapes();
            SelectingState selectingState = new SelectingState(model);
            selectingState.IsMousePressedOnAdjust = false;
            selectingState.IsMousePressedOnSelected = false;
            bool eventTrigger = false;
            model._modelChanged += (arg) => eventTrigger = true;
            // Act
            selectingState.MouseDown(30, 30);
            selectingState.MouseUp(30, 30);
            selectingState.MouseMove(3, 5);

            // Assert
            Assert.IsFalse(model.IsCloseToAdjust);
            Assert.IsTrue(eventTrigger);
        }

        [TestMethod]
        public void MouseUp_WhileIsMousePressedOnSelected_IsTrue()
        {
            Model model = CreateModelWithShapes();
            SelectingState selectingState = new SelectingState(model);
            selectingState.IsMousePressedOnAdjust = false;
            selectingState.IsMousePressedOnSelected = true;
            selectingState.MouseDown(30, 30);
            selectingState.MouseUp(40, 40);
        }

        [TestMethod]
        public void MouseUp_WhileIsMousePressedOnSelected_IsFalse()
        {
            Model model = CreateModelWithShapes();
            SelectingState selectingState = new SelectingState(model);
            selectingState.MouseDown(30, 30);
            selectingState.MouseMove(35, 35);
            selectingState.MouseUp(40, 40);
        }
    }
}