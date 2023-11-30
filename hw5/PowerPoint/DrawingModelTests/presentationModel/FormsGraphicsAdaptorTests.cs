using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using DrawingModel;

namespace DrawingModel.Tests
{
    [TestClass]
    public class FormsGraphicsAdaptorTests
    {
        [TestMethod]
        public void DrawLineTest()
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            FormsGraphicsAdaptor formsGraphicsAdaptor = new FormsGraphicsAdaptor(graphics);
            Pair pair1 = new Pair(10, 10);
            Pair pair2 = new Pair(30, 30);

            // Act
            formsGraphicsAdaptor.DrawLine(pair1, pair2);

            // Assert
            // You can add assertions here based on your expectations
        }


        [TestMethod]
        public void DrawRectangleTest()
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            FormsGraphicsAdaptor formsGraphicsAdaptor = new FormsGraphicsAdaptor(graphics);
            Pair pair1 = new Pair(10, 10);
            Pair pair2 = new Pair(30, 30);

            // Act
            formsGraphicsAdaptor.DrawRectangle(pair1, pair2);

            // Assert
            // You can add assertions here based on your expectations
        }

        [TestMethod]
        public void DrawEllipseTest()
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            FormsGraphicsAdaptor formsGraphicsAdaptor = new FormsGraphicsAdaptor(graphics);
            Pair pair1 = new Pair(10, 10);
            Pair pair2 = new Pair(30, 30);

            // Act
            formsGraphicsAdaptor.DrawEllipse(pair1, pair2);

            // Assert
            // You can add assertions here based on your expectations
        }

        [TestMethod]
        public void DrawRectangleHandleTest()
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            FormsGraphicsAdaptor formsGraphicsAdaptor = new FormsGraphicsAdaptor(graphics);
            Pair pair1 = new Pair(10, 10);
            Pair pair2 = new Pair(30, 30);

            // Act
            formsGraphicsAdaptor.DrawRectangleHandle(pair1, pair2);

            // Assert
            // You can add assertions here based on your expectations
        }

        [TestMethod]
        public void DrawLineHandleTest()
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            FormsGraphicsAdaptor formsGraphicsAdaptor = new FormsGraphicsAdaptor(graphics);
            Pair pair1 = new Pair(10, 10);
            Pair pair2 = new Pair(30, 30);

            // Act
            formsGraphicsAdaptor.DrawLineHandle(pair1, pair2);

            // Assert
            // You can add assertions here based on your expectations
        }

        [TestMethod]
        public void ClearAllTest()
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            FormsGraphicsAdaptor formsGraphicsAdaptor = new FormsGraphicsAdaptor(graphics);

            // Act
            formsGraphicsAdaptor.ClearAll();

            // Assert
            // Verify that the method is called without specific assertions.
        }

        [TestMethod]
        public void Constructor()
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            FormsGraphicsAdaptor formsGraphicsAdaptor = new FormsGraphicsAdaptor(graphics);

            // Assert
            // Verify that the method is called without specific assertions.
        }
    }
}
