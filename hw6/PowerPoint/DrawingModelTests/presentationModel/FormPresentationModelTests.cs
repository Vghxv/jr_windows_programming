using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace DrawingModel.Tests
{
    [TestClass]
    public class FormPresentationModelTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            // Arrange
            Model model = new Model();

            // Act
            FormPresentationModel presentationModel = new FormPresentationModel(model);

            // Assert
            Assert.IsNotNull(presentationModel);
            Assert.AreEqual(model, presentationModel.Model);
        }

        [TestMethod]
        public void IsDrawingPropertyTest()
        {
            // Arrange
            Model model = new Model();
            FormPresentationModel presentationModel = new FormPresentationModel(model);

            // Act
            presentationModel.IsLineEnable = true;

            // Assert
            Assert.IsTrue(presentationModel.IsDrawing, "IsDrawing should be true when IsLineEnable is true.");
        }

        [TestMethod]
        public void NotifyAllPropertiesTest()
        {
            // Arrange
            Model model = new Model();
            FormPresentationModel presentationModel = new FormPresentationModel(model);
            bool propertyChangedCalled = false;
            presentationModel.PropertyChanged += (sender, args) => propertyChangedCalled = true;

            // Act
            presentationModel.NotifyAllProperties();

            // Assert
            Assert.IsTrue(propertyChangedCalled, "PropertyChanged event should be triggered.");
        }

        [TestMethod]
        public void HandleCanvasReleasedTest()
        {
            // Arrange
            Model model = new Model();
            FormPresentationModel presentationModel = new FormPresentationModel(model);

            // Act
            presentationModel.IsLineEnable = true;
            presentationModel.HandleCanvasReleased(0, 0);

            // Assert
            Assert.IsFalse(presentationModel.IsLineEnable);
            Assert.IsFalse(presentationModel.IsRectangleEnable);
            Assert.IsFalse(presentationModel.IsEllipseEnable);
            Assert.IsTrue(presentationModel.IsIdleEnable);

            // Act
            presentationModel.HandleCanvasReleased(0, 0);

            // Assert
            Assert.IsFalse(presentationModel.IsLineEnable);
            Assert.IsFalse(presentationModel.IsRectangleEnable);
            Assert.IsFalse(presentationModel.IsEllipseEnable);
            Assert.IsTrue(presentationModel.IsIdleEnable);
        }

        [TestMethod]
        public void PressAddShapeButtonTest()
        {
            // Arrange
            Model model = new Model();
            FormPresentationModel presentationModel = new FormPresentationModel(model);
            ComboBox shapeOption = new ComboBox();
            shapeOption.Text = Constant.LINE_CHINESE;

            // Act
            presentationModel.ProcessAddShapeButton(null, EventArgs.Empty, shapeOption);

            // Assert
            Assert.AreEqual(1, model.Shapes.ShapeList.Count); // Assuming adding a shape increases the shape count by 1
        }

        [TestMethod]
        public void PressLineButtonTest()
        {
            // Arrange
            Model model = new Model();
            FormPresentationModel presentationModel = new FormPresentationModel(model);

            // Act
            presentationModel.ProcessLineBotton(null, EventArgs.Empty);

            // Assert
            Assert.IsTrue(presentationModel.IsLineEnable);
            Assert.IsFalse(presentationModel.IsRectangleEnable);
            Assert.IsFalse(presentationModel.IsEllipseEnable);
            Assert.IsFalse(presentationModel.IsIdleEnable);
        }

        [TestMethod]
        public void PressRectangleButtonTest()
        {
            // Arrange
            Model model = new Model();
            FormPresentationModel presentationModel = new FormPresentationModel(model);

            // Act
            presentationModel.ProcessRectangleButton(null, EventArgs.Empty);

            // Assert
            Assert.IsFalse(presentationModel.IsLineEnable);
            Assert.IsTrue(presentationModel.IsRectangleEnable);
            Assert.IsFalse(presentationModel.IsEllipseEnable);
            Assert.IsFalse(presentationModel.IsIdleEnable);
        }

        [TestMethod]
        public void PressEllispeButtonTest()
        {
            // Arrange
            Model model = new Model();
            FormPresentationModel presentationModel = new FormPresentationModel(model);

            // Act
            presentationModel.ProcessEllispeButton(null, EventArgs.Empty);

            // Assert
            Assert.IsFalse(presentationModel.IsLineEnable);
            Assert.IsFalse(presentationModel.IsRectangleEnable);
            Assert.IsTrue(presentationModel.IsEllipseEnable);
            Assert.IsFalse(presentationModel.IsIdleEnable);
        }

        [TestMethod]
        public void PressCursorButtonTest()
        {
            // Arrange
            Model model = new Model();
            FormPresentationModel presentationModel = new FormPresentationModel(model);

            // Act
            presentationModel.ProcessCursorButton(null, EventArgs.Empty);

            // Assert
            Assert.IsFalse(presentationModel.IsLineEnable);
            Assert.IsFalse(presentationModel.IsRectangleEnable);
            Assert.IsFalse(presentationModel.IsEllipseEnable);
            Assert.IsTrue(presentationModel.IsIdleEnable);
        }

        [TestMethod]
        public void HandleKeyDownTest()
        {
            // Arrange
            Model model = new Model();
            FormPresentationModel presentationModel = new FormPresentationModel(model);

            // Act
            presentationModel.HandleKeyDown(Keys.A);

            //
        }
        [TestMethod]
        public void SetPanelTest()
        {
            // Arrange
            Model model = new Model();
            FormPresentationModel presentationModel = new FormPresentationModel(model);
            DoubleBufferedPanel panel = new DoubleBufferedPanel();

            // Act
            presentationModel.Panel = panel;

            // Assert
            Assert.AreEqual(panel, presentationModel.Panel);
        }

        [TestMethod]
        public void HandleStateChanged_WhenIsDrawing_CursorIsCross()
        {
            // Arrange
            Model model = new Model();
            FormPresentationModel presentationModel = new FormPresentationModel(model);
            DoubleBufferedPanel panel = new DoubleBufferedPanel();
            presentationModel.Panel = panel;
            model.CurrentState = new DrawingState(model);

            // Act
            presentationModel.HandleStateChanged();

            // Assert
            Assert.AreEqual(Cursors.Cross, panel.Cursor);

            // Act
            model.IsCloseToAdjust = true;
            presentationModel.HandleStateChanged();

            // Assert
            Assert.AreEqual(Cursors.SizeNWSE, panel.Cursor);
        }

        [TestMethod]
        public void HandleStateChanged_WhenNotDrawing_CursorIsDefault()
        {
            // Arrange
            Model model = new Model();
            FormPresentationModel presentationModel = new FormPresentationModel(model);
            DoubleBufferedPanel panel = new DoubleBufferedPanel();
            presentationModel.Panel = panel;
            presentationModel.IsLineEnable = false;
            presentationModel.IsRectangleEnable = false;
            presentationModel.IsEllipseEnable = false;

            // Act
            presentationModel.HandleStateChanged();

            // Assert
            Assert.AreEqual(Cursors.Default, panel.Cursor);
        }

        [TestMethod]
        public void DrawTest()
        {
            // Arrange
            Model model = new Model();
            FormPresentationModel presentationModel = new FormPresentationModel(model);
            DoubleBufferedPanel panel = new DoubleBufferedPanel();
            presentationModel.Panel = panel;
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            
            // Act
            presentationModel.Draw(graphics);

            // Assert
            // Add assertions based on the expected behavior of drawing on the graphics object.
        }

        [TestMethod]
        public void HandleCanvasPressedTest()
        {
            // Arrange
            Model model = new Model();
            FormPresentationModel presentationModel = new FormPresentationModel(model);
            float number1 = 10.0f;
            float number2 = 20.0f;

            // Act
            presentationModel.HandleCanvasPressed(number1, number2);

            // Assert
            // Add assertions based on the expected behavior when canvas is pressed.
        }

        [TestMethod]
        public void HandleCanvasMovedTest()
        {
            // Arrange
            Model model = new Model();
            FormPresentationModel presentationModel = new FormPresentationModel(model);
            float number1 = 10.0f;
            float number2 = 20.0f;
            // Act
            presentationModel.HandleCanvasMoved(number1, number2);
            // Assert
        }

        [TestMethod]
        public void GetShapeNameToAdd_LineChinese_ReturnsCorrectName()
        {
            // Arrange
            FormPresentationModel presentationModel = new FormPresentationModel(new Model());
            string shapeName = Constant.LINE_CHINESE;

            // Act
            string result = presentationModel.GetShapeNameToAdd(shapeName);

            // Assert
            Assert.AreEqual(Constant.ASSEMBLY + Constant.LINE, result);
        }

        [TestMethod]
        public void GetShapeNameToAdd_RectangleChinese_ReturnsCorrectName()
        {
            // Arrange
            FormPresentationModel presentationModel = new FormPresentationModel(new Model());
            string shapeName = Constant.RECTANGLE_CHINESE;

            // Act
            string result = presentationModel.GetShapeNameToAdd(shapeName);

            // Assert
            Assert.AreEqual(Constant.ASSEMBLY + Constant.RECTANGLE, result);
        }

        [TestMethod]
        public void GetShapeNameToAdd_EllipseChinese_ReturnsCorrectName()
        {
            // Arrange
            FormPresentationModel presentationModel = new FormPresentationModel(new Model());
            string shapeName = Constant.ELLIPSE_CHINESE;

            // Act
            string result = presentationModel.GetShapeNameToAdd(shapeName);

            // Assert
            Assert.AreEqual(Constant.ASSEMBLY + Constant.ELLIPSE, result);
        }

        [TestMethod]
        public void GetShapeNameToAdd_InvalidShapeName_ReturnsEmptyString()
        {
            // Arrange
            FormPresentationModel presentationModel = new FormPresentationModel(new Model());
            string shapeName = "InvalidShape";

            // Act
            string result = presentationModel.GetShapeNameToAdd(shapeName);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void PressAddShapeButton_WithValidShapeName_AddsShapeAndNotifiesModelChanged()
        {
            // Arrange
            Model model = new Model();
            FormPresentationModel presentationModel = new FormPresentationModel(model);
            var shapeOption = new ComboBox { Text = Constant.LINE_CHINESE };

            // Act
            presentationModel.ProcessAddShapeButton(null, EventArgs.Empty, shapeOption);

            // Assert
            // Verify that the shape is added
            Assert.AreEqual(1, model.Shapes.ShapeList.Count);

            // Verify that the shape name is correct
            Assert.AreEqual(Constant.LINE_CHINESE, model.Shapes.ShapeList[0].NameChinese);

        }

        [TestMethod]
        public void PressAddShapeButton_WithInvalidShapeName_DoesNotAddShapeOrNotifyModelChanged()
        {
            // Arrange
            Model model = new Model();
            FormPresentationModel presentationModel = new FormPresentationModel(model);
            var shapeOption = new ComboBox { Text = "InvalidShape" };

            // Act
            presentationModel.ProcessAddShapeButton(null, EventArgs.Empty, shapeOption);

            // Assert
            // Verify that no shape is added
            Assert.AreEqual(0, model.Shapes.ShapeList.Count);
        }
    }
}
