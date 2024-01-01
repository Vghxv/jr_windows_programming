using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
namespace DrawingModel.Tests
{
    [TestClass]
    public class ShapeTests
    {
        Shape _shape;

        [TestInitialize]
        public void Initialize()
        {
            _shape = new Shape();
        }

        [TestMethod]
        public void Constructor_ShouldCreateShape()
        {
            _shape = new Shape();
            Assert.IsNotNull(_shape);
        }

        [TestMethod]
        public void NameChineseProperty_ShouldSetAndNotify()
        {
            // Arrange
            Shape shape = new Shape();
            string newNameChinese = "NewName";
            string anotherName = "anotherName";
            bool ischanged = false;
            shape.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "NameChinese")
                    ischanged = true;
            };
            shape.NameChinese = newNameChinese;
            Assert.AreEqual(newNameChinese, shape.NameChinese);
            Assert.IsTrue(ischanged);
            ischanged = false;
            shape.NameChinese = anotherName;
            Assert.AreEqual(anotherName, shape.NameChinese);
            Assert.IsTrue(ischanged);
            ischanged = false;
            shape.NameChinese = anotherName;
            Assert.AreEqual(anotherName, shape.NameChinese);
            Assert.IsFalse(ischanged);
        }

        [TestMethod]
        public void FirstPairProperty_ShouldSetAndNotify()
        {
            Shape shape = new Shape();
            Pair newFirstPair = new Pair(1, 2);
            bool isChanged = false;
            shape.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "FirstPair")
                    isChanged = true;
            };
            shape.FirstPair = newFirstPair;
            Assert.AreEqual(newFirstPair, shape.FirstPair);
            Assert.IsTrue(isChanged);
            isChanged = false;
            shape.FirstPair = newFirstPair;
            Assert.AreEqual(newFirstPair, shape.FirstPair);
            Assert.IsFalse(isChanged);
        }

        [TestMethod]
        public void SecondPairProperty_ShouldSetAndNotify()
        {
            Shape shape = new Shape();
            Pair newSecondPair = new Pair(3, 4);
            bool isChanged = false;
            shape.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "SecondPair")
                    isChanged = true;
            };
            shape.SecondPair = newSecondPair;
            Assert.AreEqual(newSecondPair, shape.SecondPair);
            Assert.IsTrue(isChanged);
            isChanged = false;
            shape.SecondPair = newSecondPair;
            Assert.AreEqual(newSecondPair, shape.SecondPair);
            Assert.IsFalse(isChanged);
        }


        [TestMethod]
        public void InfoProperty_ShouldReturnFormattedInfo()
        {
            Shape shape = new Shape();
            Pair newFirstPair = new Pair(1, 2);
            Pair newSecondPair = new Pair(3, 4);
            shape.FirstPair = newFirstPair;
            shape.SecondPair = newSecondPair;
            Assert.AreEqual($"({newFirstPair.GetInfo()}), ({newSecondPair.GetInfo()})", shape.Info);
        }

        [TestMethod]
        public void IsSelectedProperty_ShouldSetAndNotify()
        {
            Shape shape = new Shape();
            bool newIsSelected = true;
            shape.IsSelected = newIsSelected;
            Assert.AreEqual(newIsSelected, shape.IsSelected);
        }

        [TestMethod]
        public void Move_SelectedShape_ShouldUpdateCoordinates()
        {
            Shape shape = new Shape();
            Pair initialFirstPair = new Pair(1, 1);
            Pair initialSecondPair = new Pair(3, 3);
            shape.FirstPair = initialFirstPair;
            shape.SecondPair = initialSecondPair;
            Pair offset = new Pair(1, 1);
            shape.IsSelected = true;
            shape.Move(offset);
            Assert.AreEqual(initialFirstPair.Number1 + offset.Number1, shape.FirstPair.Number1);
            Assert.AreEqual(initialFirstPair.Number2 + offset.Number2, shape.FirstPair.Number2);
            Assert.AreEqual(initialSecondPair.Number1 + offset.Number1, shape.SecondPair.Number1);
            Assert.AreEqual(initialSecondPair.Number2 + offset.Number2, shape.SecondPair.Number2);
        }

        [TestMethod]
        public void IsInShapeMethod_ShouldReturnFalse()
        {
            Shape shape = new Shape();
            bool isInShape = shape.IsInShape(1, 1);
            Assert.IsFalse(isInShape);
        }

        [TestMethod]
        public void ArrangeDoubleNumbersMethod_ShouldArrangeNumbers()
        {
            Shape shape = new Shape();
            Pair firstPair = new Pair(2, 4);
            Pair secondPair = new Pair(1, 3);
            shape.FirstPair = firstPair;
            shape.SecondPair = secondPair;
            shape.ArrangePairs();
            Assert.AreEqual(1, shape.FirstPair.Number1);
            Assert.AreEqual(3, shape.FirstPair.Number2);
            Assert.AreEqual(2, shape.SecondPair.Number1);
            Assert.AreEqual(4, shape.SecondPair.Number2);
        }

        [TestMethod]
        public void GetInfo_ShouldReturnEmptyString()
        {
            Shape shape = new Shape();
            Pair firstPair = new Pair(1, 1);
            Pair secondPair = new Pair(3, 3);
            shape.FirstPair = firstPair;
            shape.SecondPair = secondPair;
            string info = shape.GetInfo();
            Assert.AreEqual(string.Empty, info);
        }

        [TestMethod]
        public void Draw_ShouldNotCallAnyDrawMethods()
        {
            MockGraphics graphics = new MockGraphics();
            Shape shape = new Shape();
            shape.Draw(graphics);
            Assert.IsFalse(graphics.DrawEllipseCalled);
            Assert.IsFalse(graphics.DrawRectangleCalled);
            Assert.IsFalse(graphics.DrawLineCalled);
            Assert.IsFalse(graphics.DrawLineHandleCalled);
            Assert.IsFalse(graphics.DrawRectangleHandleCalled);
        }

        [TestMethod]
        public void OnPropertyChanged_ShouldRaiseEventWithCorrectPropertyName()
        {
            Shape shape = new Shape();
            bool eventRaised = false;
            string propertyName = null;
            shape.PropertyChanged += (sender, args) =>
            {
                eventRaised = true;
                propertyName = args.PropertyName;
            };
            shape.NameChinese = "New Name";
            Assert.IsTrue(eventRaised);
            Assert.AreEqual(nameof(Shape.NameChinese), propertyName);
        }

        [TestMethod]
        public void Resize_ShouldProperlyResizePairs()
        {
            Shape shape = new Shape();
            shape.FirstPair = new Pair(0, 0);
            shape.SecondPair = new Pair(100, 100);
            Pair originalSize = new Pair(200, 200);
            Pair targetSize = new Pair(400, 400);
            shape.Resize(originalSize, targetSize);
            Assert.AreEqual(0, shape.FirstPair.Number1);
            Assert.AreEqual(0, shape.FirstPair.Number2);
            Assert.AreEqual(200, shape.SecondPair.Number1);
            Assert.AreEqual(200, shape.SecondPair.Number2);
        }
    }
}
