using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System.Linq;
using System;
using System.Collections.Generic;

namespace DrawingModel.Tests
{
    [TestClass]
    public class ShapesTests
    {
        [TestMethod]
        public void AddShape_WithParameters_Test()
        {
            // Arrange
            Shapes shapes = new Shapes();
            string shapeType = "DrawingModel.Rectangle"; // Assuming Rectangle is a valid shape type in your application
            Pair firstPair = new Pair(1, 2);
            Pair secondPair = new Pair(3, 4);

            // Act
            shapes.AddShape(shapeType, firstPair, secondPair);

            // Assert
            Assert.AreEqual(1, shapes.ShapeList.Count);
            //Console.WriteLine();
            Assert.IsTrue(shapes.ShapeList.First() is Rectangle);
            // Add more assertions if needed
        }

        [TestMethod]
        public void AddShape_WithShape_Test()
        {
            // Arrange
            Shapes shapes = new Shapes();
            Shape shape = new Rectangle(); // Assuming Rectangle is a valid shape in your application

            // Act
            shapes.AddShape(shape);

            // Assert
            Assert.AreEqual(1, shapes.ShapeList.Count);
            Assert.AreEqual(shape, shapes.ShapeList.First());
            // Add more assertions if needed
        }

        [TestMethod]
        public void RemoveShape_Test()
        {
            // Arrange
            Shapes shapes = new Shapes();
            Shape shape = new Rectangle(); // Assuming Rectangle is a valid shape in your application
            shapes.AddShape(shape);

            // Act
            shapes.RemoveShape(0);

            // Assert
            Assert.AreEqual(0, shapes.ShapeList.Count);
            // Add more assertions if needed
        }

        [TestMethod]
        public void ClearShapes_Test()
        {
            // Arrange
            Shapes shapes = new Shapes();
            Shape shape = new Rectangle(); // Assuming Rectangle is a valid shape in your application
            shapes.AddShape(shape);

            // Act
            shapes.ClearShapes();

            // Assert
            Assert.AreEqual(0, shapes.ShapeList.Count);
            // Add more assertions if needed
        }

        [TestMethod]
        public void SetShapeSelected_Test()
        {
            // Arrange
            Shapes shapes = new Shapes();
            Shape shape1 = new Rectangle(); // Assuming Rectangle is a valid shape in your application
            Shape shape2 = new Ellipse(); // Assuming Ellipse is a valid shape in your application
            shapes.AddShape(shape1);
            shapes.AddShape(shape2);

            // Act
            shapes.SetShapeSelected(true);

            // Assert
            Assert.IsTrue(shapes.ShapeList.All(shape => shape.IsSelected));
            // Add more assertions if needed
        }

        [TestMethod]
        public void GetEnumerator_Test()
        {
            // Arrange
            Shapes shapes = new Shapes();
            Shape shape1 = new Rectangle();
            Shape shape2 = new Ellipse();
            shapes.AddShape(shape1);
            shapes.AddShape(shape2);

            // Act
            IEnumerator<Shape> enumerator = shapes.GetEnumerator();

            // Assert
            Assert.IsNotNull(enumerator);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(shape1, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(shape2, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }


        [TestMethod]
        public void GetLocationTest()
        {
            // Arrange
            Pair pair1 = new Pair(10, 80);
            Pair pair2 = new Pair(75, 47);
            Shape shape = new Rectangle(pair1, pair2);

            // Act
            (Pair, Pair) result = shape.GetLocation();

            // Assert
            Assert.AreEqual(10, result.Item1.Number1);
            Assert.AreEqual(47, result.Item1.Number2);
            Assert.AreEqual(75, result.Item2.Number1);
            Assert.AreEqual(80, result.Item2.Number2);
        }

        [TestMethod]
        public void ArrangeShapesPointsTest()
        {
            // Arrange
            Shapes shapes= new Shapes();
            Shape shape1 = new Line(new Pair(3, 435), new Pair(341, 1));
            Shape shape2 = new Rectangle(new Pair(534, 142), new Pair(441, 442));
            Shape shape3 = new Ellipse(new Pair(5, 5), new Pair(7, 7));

            shapes.AddShape(shape1);
            shapes.AddShape(shape2);
            shapes.AddShape(shape3);

            // Act
            shapes.ArrangeShapesPoints();

            // Assert
            Assert.AreEqual("(3,435),(341,1)", shape1.GetInfo());
            Assert.AreEqual("(441,142),(534,442)", shape2.GetInfo());
            Assert.AreEqual("(5,5),(7,7)", shape3.GetInfo());
        }
    }
}
