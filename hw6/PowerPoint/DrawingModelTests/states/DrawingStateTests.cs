using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using Moq;
namespace DrawingModel.Tests
{
    [TestClass]
    public class DrawingStateTests
    {
        private DrawingState _drawingState;
        private Mock<Model> _mockModel;
        private Mock<Ellipse> _mockEllipse;

        [TestInitialize]
        public void Initialize()
        {
            _mockModel = new Mock<Model>();
            _mockEllipse = new Mock<Ellipse>();
            _drawingState = new DrawingState(_mockModel.Object, _mockEllipse.Object);
        }

        [TestMethod]
        public void Constructor()
        { 
            Assert.IsNotNull(_drawingState);
        }

        [TestMethod]
        public void MouseDown()
        {
            Model model = new Model();
            Ellipse ellipse = new Ellipse();
            _drawingState = new DrawingState(model, ellipse);
            _drawingState.MouseDown(1, 3);
            Assert.AreEqual(1, ellipse.FirstPair.Number1);
            Assert.AreEqual(3, ellipse.FirstPair.Number2);
            Assert.IsTrue(_drawingState.IsPressed);
        }

        [TestMethod]
        public void MouseMove()
        {
            Model model = new Model();
            Ellipse ellipse = new Ellipse();
            _drawingState = new DrawingState(model, ellipse);
            _drawingState.MouseDown(1, 3);
            _drawingState.MouseMove(4, 6);

            Assert.AreEqual(4, ellipse.SecondPair.Number1);
            Assert.AreEqual(6, ellipse.SecondPair.Number2);

            _drawingState.IsPressed = false;
            _drawingState.MouseMove(344, 123);

            Assert.AreEqual(4, ellipse.SecondPair.Number1);
            Assert.AreEqual(6, ellipse.SecondPair.Number2);

        }

        [TestMethod]
        public void MouseUp()
        {
            Model model = new Model();
            Ellipse ellipse = new Ellipse();
            _drawingState = new DrawingState(model, ellipse);
            _drawingState.MouseDown(1, 3);
            _drawingState.MouseUp(4, 6);

            Assert.AreEqual(4, ellipse.SecondPair.Number1);
            Assert.AreEqual(6, ellipse.SecondPair.Number2);
            Assert.IsFalse(_drawingState.IsPressed);

            _drawingState.MouseUp(344, 123);

            Assert.AreEqual(4, ellipse.SecondPair.Number1);
            Assert.AreEqual(6, ellipse.SecondPair.Number2);
        }

        [TestMethod]
        public void KeyPressed()
        {
            _drawingState.KeyPressed(Keys.A);
        }

        [TestMethod]
        public void Draw_WithIsPressedTrue()
        {
            _drawingState = new DrawingState(new Model(), new Ellipse());
            MockGraphics graphics = new MockGraphics();

            _drawingState.IsPressed = true;
            _drawingState.Draw(graphics);

            Assert.IsTrue(graphics.DrawEllipseCalled);
        }

        [TestMethod]
        public void Draw_WithIsPressedFalse()
        {
            _drawingState = new DrawingState(new Model(), new Ellipse());
            MockGraphics graphics = new MockGraphics();
            _drawingState.IsPressed = false;
            _drawingState.Draw(graphics);
            Assert.IsFalse(graphics.DrawEllipseCalled);
        }
    }
}
