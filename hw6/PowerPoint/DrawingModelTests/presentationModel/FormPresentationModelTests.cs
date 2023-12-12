using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.Drawing;
using Moq;

namespace DrawingModel.Tests
{
    [TestClass]
    public class FormPresentationModelTests
    {
        Size _size;
        Mock<Model> _model;
        FormPresentationModel _presentationModel;
        PrivateObject _privateObject;

        [TestInitialize]
        public void Initialize()
        {
            _size = new Size(1600, 900);
            _model = new Mock<Model>();
            _presentationModel = new FormPresentationModel(_model.Object);
            _privateObject = new PrivateObject(_presentationModel);
        }
        [TestMethod]
        public void BaseTest()
        {
            Assert.IsNotNull(_presentationModel.Model);
        }

        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(_presentationModel);
        }

        [TestMethod]
        public void IsDrawingPropertyTest()
        {
            _presentationModel.IsLineEnable = true;
            Assert.IsTrue(_presentationModel.IsLineEnable, "IsDrawing should be true when IsLineEnable is true.");
        }

        [TestMethod]
        public void NotifyAllPropertiesTest()
        {
            bool propertyChangedCalled = false;
            _presentationModel.PropertyChanged += (sender, args) => propertyChangedCalled = true;
            _privateObject.Invoke("NotifyAllProperties");
            Assert.IsTrue(propertyChangedCalled, "PropertyChanged event should be triggered.");
        }

        [TestMethod]
        public void HandleCanvasReleasedTest()
        {
            _presentationModel.IsLineEnable = true;
            _presentationModel.HandleCanvasReleased(0, 0);
            Assert.IsFalse(_presentationModel.IsLineEnable);
            Assert.IsFalse(_presentationModel.IsRectangleEnable);
            Assert.IsFalse(_presentationModel.IsEllipseEnable);
            Assert.IsTrue(_presentationModel.IsIdleEnable);
            _presentationModel.HandleCanvasReleased(0, 0);
            Assert.IsFalse(_presentationModel.IsLineEnable);
            Assert.IsFalse(_presentationModel.IsRectangleEnable);
            Assert.IsFalse(_presentationModel.IsEllipseEnable);
            Assert.IsTrue(_presentationModel.IsIdleEnable);
        }

        [TestMethod]
        public void PressAddShapeButtonTest()
        {
            Model model = new Model();
            _presentationModel = new FormPresentationModel(model);
            ComboBox shapeOption = new ComboBox();
            shapeOption.Text = Constant.LINE_CHINESE;
            _presentationModel.ProcessAddShapeButton(shapeOption, _size);
            Assert.AreEqual(1, model.Shapes.ShapeList.Count);
        }

        [TestMethod]
        public void PressLineButtonTest()
        {
            _presentationModel.ProcessLineButton();
            Assert.IsTrue(_presentationModel.IsLineEnable);
            Assert.IsFalse(_presentationModel   .IsRectangleEnable);
            Assert.IsFalse(_presentationModel.IsEllipseEnable);
            Assert.IsFalse(_presentationModel.IsIdleEnable);
        }

        [TestMethod]
        public void PressRectangleButtonTest()
        {
            _presentationModel.ProcessRectangleButton();
            Assert.IsFalse(_presentationModel.IsLineEnable);
            Assert.IsTrue(_presentationModel.IsRectangleEnable);
            Assert.IsFalse(_presentationModel.IsEllipseEnable);
            Assert.IsFalse(_presentationModel.IsIdleEnable);
        }

        [TestMethod]
        public void PressEllipseButtonTest()
        {
            _presentationModel.ProcessEllipseButton();
            Assert.IsFalse(_presentationModel.IsLineEnable);
            Assert.IsFalse(_presentationModel.IsRectangleEnable);
            Assert.IsTrue(_presentationModel.IsEllipseEnable);
            Assert.IsFalse(_presentationModel.IsIdleEnable);
        }

        [TestMethod]
        public void PressCursorButtonTest()
        {
            _presentationModel.ProcessCursorButton();
            Assert.IsFalse(_presentationModel.IsLineEnable);
            Assert.IsFalse(_presentationModel.IsRectangleEnable);
            Assert.IsFalse(_presentationModel.IsEllipseEnable);
            Assert.IsTrue(_presentationModel.IsIdleEnable);
        }

        [TestMethod]
        public void HandleKeyDownTest()
        {
            _presentationModel.HandleKeyDown(Keys.A);
            _model.Verify(m => m.HandleKeyDown(Keys.A), Times.Once);
        }

        [TestMethod]
        public void SetPanelTest()
        {
            DoubleBufferedPanel panel = new DoubleBufferedPanel();
            _presentationModel.DoubleBufferPanel = panel;
            Assert.IsNotNull(_presentationModel.DoubleBufferPanel);
        }

        [TestMethod]
        public void HandleStateChanged_WhenIsDrawing_CursorIsCross()
        {
            Model model = new Model();
            _presentationModel = new FormPresentationModel(model);
            DoubleBufferedPanel panel = new DoubleBufferedPanel();
            _presentationModel.DoubleBufferPanel = panel;
            model.CurrentState = new DrawingState(model, new Ellipse());
            _presentationModel.HandleStateChanged();
            Assert.AreEqual(Cursors.Cross, panel.Cursor);
            model.IsCloseToAdjust = true;
            _presentationModel.HandleStateChanged();
            Assert.AreEqual(Cursors.SizeNWSE, panel.Cursor);
        }

        [TestMethod]
        public void HandleStateChanged_WhenNotDrawing_CursorIsDefault()
        {
            DoubleBufferedPanel panel = new DoubleBufferedPanel();
            _presentationModel.DoubleBufferPanel = panel;
            _presentationModel.IsLineEnable = false;
            _presentationModel.IsRectangleEnable = false;
            _presentationModel.IsEllipseEnable = false;
            _presentationModel.HandleStateChanged();
            Assert.AreEqual(Cursors.Default, panel.Cursor);
        }

        [TestMethod]
        public void DrawTest()
        {
            DoubleBufferedPanel panel = new DoubleBufferedPanel();
            _presentationModel.DoubleBufferPanel = panel;
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            _presentationModel.Draw(graphics);
        }

        [TestMethod]
        public void HandleCanvasPressedTest()
        {
            float number1 = 10.0f;
            float number2 = 20.0f;
            _presentationModel.HandleCanvasPressed(number1, number2);
            _model.Verify(m=>m.HandleCanvasPressed(number1, number2));

        }

        [TestMethod]
        public void HandleCanvasMovedTest()
        {
            float number1 = 10.0f;
            float number2 = 20.0f;
            _presentationModel.HandleCanvasMoved(number1, number2);
            _model.Verify(m => m.HandleCanvasMoved(number1, number2));

        }

        [TestMethod]
        public void GetShapeNameToAdd_LineChinese_ReturnsCorrectName()
        {
            string shapeName = Constant.LINE_CHINESE;
            string result = _presentationModel.GetShapeNameToAdd(shapeName);
            Assert.AreEqual(Constant.ASSEMBLY + Constant.LINE, result);
        }

        [TestMethod]
        public void GetShapeNameToAdd_RectangleChinese_ReturnsCorrectName()
        {
            string shapeName = Constant.RECTANGLE_CHINESE;
            string result = _presentationModel.GetShapeNameToAdd(shapeName);
            Assert.AreEqual(Constant.ASSEMBLY + Constant.RECTANGLE, result);
        }

        [TestMethod]
        public void GetShapeNameToAdd_EllipseChinese_ReturnsCorrectName()
        {
            string shapeName = Constant.ELLIPSE_CHINESE;
            string result = _presentationModel.GetShapeNameToAdd(shapeName);
            Assert.AreEqual(Constant.ASSEMBLY + Constant.ELLIPSE, result);
        }

        [TestMethod]
        public void GetShapeNameToAdd_InvalidShapeName_ReturnsEmptyString()
        {
            string shapeName = "InvalidShape";
            string result = _presentationModel.GetShapeNameToAdd(shapeName);
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void PressAddShapeButton_WithValidShapeName_AddsShapeAndNotifiesModelChanged()
        {
            Model model = new Model();
            _presentationModel = new FormPresentationModel(model);
            var shapeOption = new ComboBox { Text = Constant.LINE_CHINESE };
            _presentationModel.ProcessAddShapeButton(shapeOption, _size);
            Assert.AreEqual(1, model.Shapes.ShapeList.Count);
        }

        [TestMethod]
        public void PressAddShapeButton_WithInvalidShapeName_DoesNotAddShapeOrNotifyModelChanged()
        {
            Model model = new Model();
            _presentationModel = new FormPresentationModel(model);
            var shapeOption = new ComboBox { Text = "InvalidShape" };
            _presentationModel.ProcessAddShapeButton(shapeOption, _size);

            Assert.AreEqual(0, model.Shapes.ShapeList.Count);
        }

        [TestMethod]
        public void PressAddShapeButton_WithValidShapeNameAndInvalidSize_DoesNotAddShapeOrNotifyModelChanged()
        {
            Model model = new Model();
            _presentationModel = new FormPresentationModel(model);
            var shapeOption = new ComboBox { Text = Constant.LINE_CHINESE };
            var invalidSize = new Size(0, 0);
            _presentationModel.ProcessAddShapeButton(shapeOption, invalidSize);
            Assert.AreEqual(0, model.Shapes.ShapeList.Count);
        }

        [TestMethod]
        public void PressAddShapeButton_WithValidShapeNameAndValidSize_AddsShapeAndNotifiesModelChanged()
        {
            Model model = new Model();
            _presentationModel = new FormPresentationModel(model);
            var shapeOption = new ComboBox { Text = Constant.LINE_CHINESE };
            _presentationModel.ProcessAddShapeButton(shapeOption, _size);
            Assert.AreEqual(1, model.Shapes.ShapeList.Count);
        }

        [TestMethod]
        public void ModelInfoCellClicked_NotifiesModelChanged_WhenValidCellClicked()
        {
            var model = new Model();
            _presentationModel = new FormPresentationModel(model);
            Line shape = new Line();
            model.AddShape(shape);
            _presentationModel.ModelInfoCellClick(0, 0);
            Assert.AreEqual(0, model.Shapes.ShapeList.Count);
        }

        [TestMethod]
        public void ModelInfoCellClicked_DoesNotNotifyModelChanged_WhenInvalidCellClicked()
        {
            var model = new Model();
            _presentationModel = new FormPresentationModel(model);
            Line shape = new Line();
            model.AddShape(shape);
            _presentationModel.ModelInfoCellClick(0, 1);
            Assert.AreEqual(1, model.Shapes.ShapeList.Count);
        }


        [TestMethod]
        public void AddSlideButton_AddsButtonToSlideInfo()
        {
            // Arrange
            var model = new Model();
            var formPresentationModel = new FormPresentationModel(model);
            var slideInfo = new FlowLayoutPanel();

            // Act
            formPresentationModel.AddSlideButton(slideInfo);

            // Assert
            Assert.AreEqual(1, slideInfo.Controls.Count);
            Assert.IsInstanceOfType(slideInfo.Controls[0], typeof(Button));
        }

        [TestMethod]
        public void DeleteSlideButton_ClearsControlsInSlideInfo()
        {
            // Arrange
            var model = new Model();
            var formPresentationModel = new FormPresentationModel(model);
            var slideInfo = new FlowLayoutPanel();
            formPresentationModel.AddSlideButton(slideInfo);

            // Act
            formPresentationModel.DeleteSlideButton(slideInfo);

            // Assert
            Assert.AreEqual(0, slideInfo.Controls.Count);
        }

        [TestMethod]
        public void HandleButtonResize_UpdatesSizeOfControlsInSlideInfo()
        {
            // Arrange
            var model = new Model();
            var formPresentationModel = new FormPresentationModel(model);
            var slideInfo = new FlowLayoutPanel();
            formPresentationModel.AddSlideButton(slideInfo);
            var originalSize = slideInfo.Controls[0].Size;

            // Act
            formPresentationModel.HandleButtonResize(slideInfo);

            // Assert
            Assert.AreEqual(originalSize.Width, slideInfo.Controls[0].Width);
            Assert.AreEqual(originalSize.Height, slideInfo.Controls[0].Height);
        }

        [TestMethod]
        public void HandleCanvasResize_UpdatesSizeAndLocationOfCanva()
        {
            var model = new Model();
            var formPresentationModel = new FormPresentationModel(model);
            var canva = new DoubleBufferedPanel();
            formPresentationModel.DoubleBufferPanel = canva;
            var regionSize = new Size(800, 700);
            canva.Size = new Size(640, 360);
            int expectedWidth = regionSize.Width - Constant.SPLITTER_OFFSET;
            int expectedHeight = expectedWidth / Constant.ASPECT_RATIO_X * Constant.ASPECT_RATIO_Y;
            int expectedX = 0;
            int expectedY = (regionSize.Height - expectedHeight) / 2;
            formPresentationModel.HandleCanvasResize(canva, regionSize);
            Assert.AreEqual(expectedWidth, canva.Width);
            Assert.AreEqual(expectedHeight, canva.Height);
            Assert.AreEqual(expectedX, canva.Location.X);
            Assert.AreEqual(expectedY, canva.Location.Y);
            Assert.IsTrue(canva.Width > 0);
            Assert.IsTrue(canva.Height > 0);
            regionSize = new Size(800, 400);
            canva.Size = new Size(640, 360);
            expectedHeight = regionSize.Height;
            expectedWidth = expectedHeight / Constant.ASPECT_RATIO_Y * Constant.ASPECT_RATIO_X;
            expectedX = (regionSize.Width - expectedWidth) / 2;
            expectedY = 0;
            formPresentationModel.HandleCanvasResize(canva, regionSize);
            Assert.AreEqual(expectedWidth, canva.Width);
            Assert.AreEqual(expectedHeight, canva.Height);
            Assert.AreEqual(expectedX, canva.Location.X);
            Assert.AreEqual(expectedY, canva.Location.Y);
            Assert.IsTrue(canva.Width > 0);
            Assert.IsTrue(canva.Height > 0);
        }


    }
}
