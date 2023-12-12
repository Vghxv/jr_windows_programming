using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;

namespace DrawingModel.Tests
{
    [TestClass]
    public class ShapesTests
    {
        [TestMethod]
        public void AddShape_WithShape_Test()
        {
            Shapes shapes = new Shapes();
            Shape shape = new DrawingModel.Rectangle();
            shapes.AddShape(shape);
            Assert.AreEqual(1, shapes.ShapeList.Count);
            Assert.AreEqual(shape, shapes.ShapeList.First());
        }

        [TestMethod]
        public void RemoveShape_Test()
        {
            Shapes shapes = new Shapes();
            Shape shape = new Rectangle();
            shapes.AddShape(shape);
            shapes.RemoveShape(shape);
            Assert.AreEqual(0, shapes.ShapeList.Count);
        }

        [TestMethod]
        public void ClearShapes_Test()
        {
            Shapes shapes = new Shapes();
            Shape shape = new Rectangle();
            shapes.AddShape(shape);
            shapes.ClearShapes();
            Assert.AreEqual(0, shapes.ShapeList.Count);
        }

        [TestMethod]
        public void SetShapeSelected_Test()
        {
            Shapes shapes = new Shapes();
            Shape shape1 = new Rectangle(); 
            Shape shape2 = new Ellipse();
            shapes.AddShape(shape1);
            shapes.AddShape(shape2);
            shapes.SetAllShapeSelected(true);
            Assert.IsTrue(shapes.ShapeList.All(shape => shape.IsSelected));
        }

        [TestMethod]
        public void GetEnumerator_Test()
        {
            Shapes shapes = new Shapes();
            Shape shape1 = new DrawingModel.Rectangle();
            Shape shape2 = new Ellipse();
            shapes.AddShape(shape1);
            shapes.AddShape(shape2);
            IEnumerator<Shape> enumerator = shapes.GetEnumerator();
            Assert.IsNotNull(enumerator);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(shape1, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(shape2, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        public void ArrangeShapesPointsTest()
        {
            Shapes shapes= new Shapes();
            Shape shape1 = new Line(new Pair(3, 435), new Pair(341, 1));
            Shape shape2 = new DrawingModel.Rectangle(new Pair(534, 142), new Pair(441, 442));
            Shape shape3 = new Ellipse(new Pair(5, 5), new Pair(7, 7));
            shapes.AddShape(shape1);
            shapes.AddShape(shape2);
            shapes.AddShape(shape3);
            shapes.ArrangeShapesPoints();
            Assert.AreEqual("(3.00,435.00),(341.00,1.00)", shape1.GetInfo());
            Assert.AreEqual("(441.00,142.00),(534.00,442.00)", shape2.GetInfo());
            Assert.AreEqual("(5.00,5.00),(7.00,7.00)", shape3.GetInfo());
        }

        [TestMethod]
        public void ResizeShapes_ShouldProperlyResizeAllShapes()
        {
            Shapes shapes = new Shapes();
            Shape shape1 = new Shape();
            shape1.FirstPair = new Pair(0, 0);
            shape1.SecondPair = new Pair(100, 100);
            shapes.AddShape(shape1);
            Shape shape2 = new Shape();
            shape2.FirstPair = new Pair(50, 50);
            shape2.SecondPair = new Pair(150, 150);
            shapes.AddShape(shape2);
            Pair originalSize = new Pair(200, 200);
            Pair targetSize = new Pair(400, 400);
            shapes.ResizeShapes(originalSize, targetSize);
            Assert.AreEqual(0, shape1.FirstPair.Number1);
            Assert.AreEqual(0, shape1.FirstPair.Number2);
            Assert.AreEqual(200, shape1.SecondPair.Number1);
            Assert.AreEqual(200, shape1.SecondPair.Number2);
            Assert.AreEqual(100, shape2.FirstPair.Number1);
            Assert.AreEqual(100, shape2.FirstPair.Number2);
            Assert.AreEqual(300, shape2.SecondPair.Number1);
            Assert.AreEqual(300, shape2.SecondPair.Number2);
        }

        [TestMethod]
        public void MoveShapeTest() {
            Shapes shapes = new Shapes();
            Shape shape1 = new Shape();
            shape1.FirstPair = new Pair(50, 50);
            shape1.SecondPair = new Pair(150, 150);
            shapes.AddShape(shape1);
            Shape shape2 = new Shape();
            shape2.FirstPair = new Pair(0, 0);
            shape2.SecondPair = new Pair(100, 100);
            shapes.AddShape(shape2);
            Pair offset = new Pair(10, 30);
            shapes.MoveShape(shape2, offset);
            Assert.AreEqual(10, shape2.FirstPair.Number1);
            Assert.AreEqual(30, shape2.FirstPair.Number2);
            Assert.AreEqual(110, shape2.SecondPair.Number1);
            Assert.AreEqual(130, shape2.SecondPair.Number2);

            //Assert.AreEqual(100, shape1.FirstPair.Number1);
            //Assert.AreEqual(100, shape1.FirstPair.Number2);
            //Assert.AreEqual(300, shape1.SecondPair.Number1);
            //Assert.AreEqual(300, shape1.SecondPair.Number2);
        }
    }
}
