using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingModel.Tests
{
    [TestClass]
    public class DrawingStateTests
    {
        [TestMethod]
        public void Constructor()
        {
            // Arrange
            Model model = new Model();
            DrawingState state = new DrawingState(model);
            // Act
            // Assert
        }

        [TestMethod]
        public void MouseDown()
        {
            // Arrange
            Model model = new Model();
            model.SetHint(ShapeFactory.CreateShape("DrawingModel.Line"));
            DrawingState state = new DrawingState(model);
            // Act
            state.MouseDown(1, 3);
            // Assert
            Assert.IsTrue(model.Hint is Line);
            Assert.AreEqual(1, model.Hint.FirstPair.Number1);
            Assert.AreEqual(3, model.Hint.FirstPair.Number2);
            Assert.IsTrue(state.IsPressed);
        }

        [TestMethod]
        public void MouseMove()
        {
            // Arrange
            Model model = new Model();
            model.SetHint(ShapeFactory.CreateShape("DrawingModel.Line"));
            DrawingState state = new DrawingState(model);
            state.MouseDown(1, 3);

            // Act
            state.MouseMove(4, 6);

            // Assert
            Assert.AreEqual(4, model.Hint.SecondPair.Number1);
            Assert.AreEqual(6, model.Hint.SecondPair.Number2);

            // Act
            state.IsPressed = false;
            state.MouseMove(344, 123);

            // Assert
            Assert.AreEqual(4, model.Hint.SecondPair.Number1);
            Assert.AreEqual(6, model.Hint.SecondPair.Number2);

        }

        [TestMethod]
        public void MouseUp()
        {
            // Arrange
            Model model = new Model();
            model.SetHint(ShapeFactory.CreateShape("DrawingModel.Line"));
            DrawingState state = new DrawingState(model);
            state.MouseDown(1, 3);

            // Act
            state.MouseUp(4, 6);

            // Assert
            Assert.AreEqual(4, model.Hint.SecondPair.Number1);
            Assert.AreEqual(6, model.Hint.SecondPair.Number2);
            Assert.IsFalse(state.IsPressed);

            state.MouseUp(344, 123);

            // Assert
            Assert.AreEqual(4, model.Hint.SecondPair.Number1);
            Assert.AreEqual(6, model.Hint.SecondPair.Number2);
        }

        [TestMethod]
        public void KeyPressed()
        {
            // Arrange
            Model model = new Model();
            DrawingState state = new DrawingState(model);

            // Act
            state.KeyPressed(Keys.A);

            // Assert
        }

        [TestMethod]
        public void Draw()
        {
            // Arrange
            Model model = new Model();
            model.SetHint(ShapeFactory.CreateShape("DrawingModel.Rectangle"));
            DrawingState state = new DrawingState(model);
            MockGraphics graphics = new MockGraphics();

            // Act
            state.IsPressed = false;
            state.Draw(graphics);

            // Assert
            Assert.IsFalse(graphics.DrawRectangleCalled);

            // Act
            state.IsPressed = true;
            state.Draw(graphics);

            // Assert
            Assert.IsTrue(graphics.DrawRectangleCalled);
        }
    }
}
