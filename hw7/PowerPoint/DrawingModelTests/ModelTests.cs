using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;

namespace DrawingModel.Tests
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void HandleCanvasPressed_Should_Set_ModelState()
        {
            // Arrange
            Model model = new Model();
            model.CurrentState = new IdleState(model);

            // Act
            model.HandleCanvasPressed(1, 1);

            // Assert
            Assert.IsTrue(model.CurrentState is IdleState);
        }

        [TestMethod]
        public void ClearShapes_Should_Remove_All_Shapes()
        {
            // Arrange
            Model model = new Model();
            Shape shape1 = new Rectangle();
            Shape shape2 = new Line();
            model.AddShape(shape1);
            model.AddShape(shape2);

            // Act
            model.ClearShapes();

            // Assert
            Assert.AreEqual(0, model.GetCurrentPageShapes().Count);
        }

        [TestMethod]
        public void HandleCanvasPressed_ShouldCallMouseDown_OnModelState()
        {
            // Arrange
            Model model = new Model();
            MockModelState mockState = new MockModelState();
            model.CurrentState = mockState;

            // Act
            model.HandleCanvasPressed(10, 20);

            // Assert
            Assert.IsTrue(mockState.MouseDownCalled);
            Assert.AreEqual(10, mockState.LastNumber1);
            Assert.AreEqual(20, mockState.LastNumber2);
        }

        [TestMethod]
        public void HandleCanvasMoved_ShouldCallMouseMove_OnModelState()
        {
            // Arrange
            Model model = new Model();
            MockModelState mockState = new MockModelState();
            model.CurrentState = mockState;

            // Act
            model.HandleCanvasMoved(30, 40);

            // Assert
            Assert.IsTrue(mockState.MouseMoveCalled);
            Assert.AreEqual(30, mockState.LastNumber1);
            Assert.AreEqual(40, mockState.LastNumber2);
        }

        [TestMethod]
        public void HandleCanvasReleased_ShouldCallMouseUp_OnModelState()
        {
            // Arrange
            Model model = new Model();
            MockModelState mockState = new MockModelState();
            model.CurrentState = mockState;

            // Act
            model.HandleCanvasReleased(50, 60);

            // Assert
            Assert.IsTrue(mockState.MouseUpCalled);
            Assert.AreEqual(50, mockState.LastNumber1);
            Assert.AreEqual(60, mockState.LastNumber2);
        }

        [TestMethod]
        public void HandleKeyDown_ShouldCallKeyPressed_OnModelState()
        {
            // Arrange
            Model model = new Model();
            MockModelState mockState = new MockModelState();
            model.CurrentState = mockState;
            Keys keys = Keys.A; 

            // Act
            model.HandleKeyDown(keys);

            // Assert
            Assert.IsTrue(mockState.KeyPressedCalled);
            Assert.AreEqual(keys, mockState.LastKeys);
        }

        [TestMethod]
        public void Draw_ShouldCallDrawMethodOfShapesAndModelState()
        {
            // Arrange
            Model model = new Model();
            MockGraphics mockGraphics = new MockGraphics();
            Ellipse shape1 = new Ellipse();
            DrawingModel.Rectangle shape2 = new Rectangle();
            model.AddShape(shape1);
            model.AddShape(shape2);
            MockModelState mockModelState = new MockModelState();
            model.CurrentState = mockModelState;

            // Act
            model.Draw(mockGraphics);

            // Assert
            Assert.IsFalse(mockGraphics.DrawLineCalled);
            Assert.IsTrue(mockGraphics.DrawEllipseCalled);
            Assert.IsTrue(mockGraphics.DrawRectangleCalled);
            Assert.IsFalse(mockGraphics.DrawLineHandleCalled);
            Assert.IsFalse(mockGraphics.DrawRectangleHandleCalled);
        }

        [TestMethod]
        public void NotifyModelChanged_ShouldRaiseModelChangedEvent()
        {
            // Arrange
            Model model = new Model();
            bool eventRaised = false;

            model._modelChanged += (args) => eventRaised = true;

            // Act
            model.NotifyModelChanged();

            // Assert
            Assert.IsTrue(eventRaised);
        }

        [TestMethod]
        public void AdjustPoint_Property_ShouldBeSetCorrectly()
        {
            // Arrange
            Model model = new Model();
            Pair expectedAdjustPoint = new Pair(10, 20);

            // Act
            model.AdjustPoint = expectedAdjustPoint;
            Pair actualAdjustPoint = model.AdjustPoint;

            // Assert
            Assert.AreEqual(expectedAdjustPoint.Number1, actualAdjustPoint.Number1, "AdjustPoint.Number1 should be set correctly.");
            Assert.AreEqual(expectedAdjustPoint.Number2, actualAdjustPoint.Number2, "AdjustPoint.Number2 should be set correctly.");
        }

        [TestMethod]
        public void ResizeShapes_WhenCalled_ShouldResizeShapes()
        {
            // Arrange
            Model model = new Model();
            Shape shape1 = new Rectangle(new Pair(100, 100), new Pair(200, 200));
            Shape shape2 = new Line(new Pair(100, 100), new Pair(300, 400));
            model.AddShape(shape1);
            model.AddShape(shape2);

            Size originalSize = new Size(100, 50);
            Size targetSize = new Size(200, 300);

            // Act
            model.ResizeShapes(originalSize, targetSize);

            // Assert
            Assert.IsTrue(new Pair(200, 600) == shape1.FirstPair); 
            Assert.IsTrue(new Pair(400, 1200) == shape1.SecondPair); 
            Assert.IsTrue(new Pair(200, 600) == shape2.FirstPair); 
            Assert.IsTrue(new Pair(600, 2400) == shape2.SecondPair); 
        }

        [TestMethod]
        public void MoveShape_WhenCalled_ShouldMoveShape()
        {
            Model model = new Model();
            Shape shape1 = new Rectangle(new Pair(100, 100), new Pair(200, 200));
            Shape shape2 = new Line(new Pair(100, 100), new Pair(300, 400));
            model.AddShape(shape1);
            model.AddShape(shape2);

            Pair offset = new Pair(100, 100);
            model.MoveShape(shape2, offset);
            Assert.IsTrue(new Pair(200, 200) == shape2.FirstPair);
            Assert.IsTrue(new Pair(400, 500) == shape2.SecondPair);


        }
    }
}
