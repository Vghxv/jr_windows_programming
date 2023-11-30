using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System.Windows.Forms;
using System.Linq;

namespace DrawingModel.Tests
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void AddShape_Should_Add_Shape_To_Shapes()
        {
            // Arrange
            Model model = new Model();
            int initialCount = model.Shapes.ShapeList.Count;

            // Act
            model.AddShape("DrawingModel.Rectangle");

            // Assert
            Assert.AreEqual(initialCount + 1, model.Shapes.ShapeList.Count);
        }

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
        public void SetHint_Should_Set_Hint_In_Model()
        {
            // Arrange
            Model model = new Model();
            string shapeName = "DrawingModel.Rectangle";

            // Act
            model.SetHint(ShapeFactory.CreateShape(shapeName));

            // Assert
            Assert.IsTrue(model.Hint is Rectangle);
        }

        [TestMethod]
        public void RemoveShape_Should_Remove_Shape_At_Index()
        {
            // Arrange
            Model model = new Model();
            Shape shape1 = new Rectangle();
            Shape shape2 = new Line();
            model.AddShape(shape1);
            model.AddShape(shape2);

            // Act
            model.RemoveShape(0);

            // Assert
            Assert.AreEqual(1, model.Shapes.ShapeList.Count);
            Assert.AreSame(shape2, model.Shapes.ShapeList[0]);
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
            Assert.AreEqual(0, model.Shapes.ShapeList.Count);
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
            Keys keys = Keys.A; // Replace with the desired key

            // Act
            model.HandleKeyDown(keys);

            // Assert
            Assert.IsTrue(mockState.KeyPressedCalled);
            Assert.AreEqual(keys, mockState.LastKeys);
        }
        [TestMethod]
        public void AddHintToShapes_ShouldAddHintToShapesList()
        {
            // Arrange
            Model model = new Model();
            model.SetHint(ShapeFactory.CreateShape("DrawingModel.Rectangle"));
            // Act
            model.AddHintToShapes();

            // Assert
            Assert.AreEqual(1 ,model.Shapes.ShapeList.Count);
            Assert.IsTrue(model.Shapes.ShapeList.First() is Rectangle);
        }

        [TestMethod]
        public void SetHintFirstPoint_ShouldSetFirstPointCorrectly()
        {
            // Arrange
            Model model = new Model();
            model.SetHint(ShapeFactory.CreateShape("DrawingModel.Rectangle"));

            float firstPointX = 10;
            float firstPointY = 20;

            // Act
            model.SetHintFirstPoint(firstPointX, firstPointY);

            // Assert
            Assert.AreEqual(firstPointX, model.Hint.FirstPair.Number1);
            Assert.AreEqual(firstPointY, model.Hint.FirstPair.Number2);
        }

        [TestMethod]
        public void SetHintSecondPoint_ShouldSetSecondPointCorrectly()
        {
            // Arrange
            Model model = new Model();
            model.SetHint(ShapeFactory.CreateShape("DrawingModel.Rectangle"));

            float secondPointX = 30;
            float secondPointY = 40;

            // Act
            model.SetHintSecondPoint(secondPointX, secondPointY);

            // Assert
            Assert.AreEqual(secondPointX, model.Hint.SecondPair.Number1);
            Assert.AreEqual(secondPointY, model.Hint.SecondPair.Number2);
        }

        [TestMethod]
        public void DrawHint_ShouldCallDrawMethodOfHint()
        {
            // Arrange
            Model model = new Model();
            MockGraphics mockGraphics = new MockGraphics();
            model.SetHint(ShapeFactory.CreateShape("DrawingModel.Rectangle"));

            // Act
            model.DrawHint(mockGraphics);

            // Assert
        }
        [TestMethod]
        public void Draw_ShouldCallDrawMethodOfShapesAndModelState()
        {
            // Arrange
            Model model = new Model();
            MockGraphics mockGraphics = new MockGraphics();
            Ellipse shape1 = new Ellipse(); // Use your mock or a real shape for testing
            Rectangle shape2 = new Rectangle(); // Use your mock or a real shape for testing
            model.Shapes.AddShape(shape1);
            model.Shapes.AddShape(shape2);
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

            Assert.IsTrue(mockModelState.DrawCalled);
            // Ensure that the Draw method of each shape in _shapes and Draw method of the model state are called
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
    }
}
