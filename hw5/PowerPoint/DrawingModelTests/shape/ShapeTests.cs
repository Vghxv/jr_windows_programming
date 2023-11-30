using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;

namespace DrawingModel.Tests
{
    [TestClass]
    public class ShapeTests
    {
        [TestMethod]
        public void Constructor_ShouldCreateShape()
        {
            // Arrange & Act
            Shape shape = new Shape();

            // Assert
            Assert.IsNotNull(shape);
            // Add more assertions if necessary
        }

        [TestMethod]
        public void NameChineseProperty_ShouldSetAndNotify()
        {
            // Arrange
            Shape shape = new Shape();
            string newNameChinese = "NewName";
            string anotherName = "anotherName";

            // Act
            shape.NameChinese = newNameChinese;
            shape.NameChinese = anotherName;

            // Assert
            Assert.AreEqual(anotherName, shape.NameChinese);

            // Act
            shape.NameChinese = anotherName;

            // Assert
            Assert.AreEqual(anotherName, shape.NameChinese);
        }

        [TestMethod]
        public void FirstPairProperty_ShouldSetAndNotify()
        {
            // Arrange
            Shape shape = new Shape();
            Pair newFirstPair = new Pair(1, 2);

            // Act
            shape.FirstPair = newFirstPair;

            // Assert
            Assert.AreEqual(newFirstPair, shape.FirstPair);

            // Act
            shape.FirstPair = newFirstPair;

            // Assert
            Assert.AreEqual(newFirstPair, shape.FirstPair);
        }

        [TestMethod]
        public void SecondPairProperty_ShouldSetAndNotify()
        {
            // Arrange
            Shape shape = new Shape();
            Pair newSecondPair = new Pair(3, 4);

            // Act
            shape.SecondPair = newSecondPair;

            // Assert
            Assert.AreEqual(newSecondPair, shape.SecondPair);

            // Act
            shape.SecondPair = newSecondPair;

            // Assert
            Assert.AreEqual(newSecondPair, shape.SecondPair);
        }

        [TestMethod]
        public void InfoProperty_ShouldReturnFormattedInfo()
        {
            // Arrange
            Shape shape = new Shape();
            Pair newFirstPair = new Pair(1, 2);
            Pair newSecondPair = new Pair(3, 4);

            // Act
            shape.FirstPair = newFirstPair;
            shape.SecondPair = newSecondPair;

            // Assert
            Assert.AreEqual($"({newFirstPair.GetInfo()}), ({newSecondPair.GetInfo()})", shape.Info);
        }

        [TestMethod]
        public void IsSelectedProperty_ShouldSetAndNotify()
        {
            // Arrange
            Shape shape = new Shape();
            bool newIsSelected = true;

            // Act
            shape.IsSelected = newIsSelected;

            // Assert
            Assert.AreEqual(newIsSelected, shape.IsSelected);
        }

        [TestMethod]
        public void Move_SelectedShape_ShouldUpdateCoordinates()
        {
            // Arrange
            Rectangle rectangle = new Rectangle();
            Pair initialFirstPair = new Pair(1, 1);
            Pair initialSecondPair = new Pair(3, 3);
            rectangle.FirstPair = initialFirstPair;
            rectangle.SecondPair = initialSecondPair;

            Pair offset = new Pair(1, 1);
            rectangle.IsSelected = true;

            // Act
            rectangle.Move(offset);

            // Assert
            Assert.AreEqual(initialFirstPair.Number1 + offset.Number1, rectangle.FirstPair.Number1);
            Assert.AreEqual(initialFirstPair.Number2 + offset.Number2, rectangle.FirstPair.Number2);
            Assert.AreEqual(initialSecondPair.Number1 + offset.Number1, rectangle.SecondPair.Number1);
            Assert.AreEqual(initialSecondPair.Number2 + offset.Number2, rectangle.SecondPair.Number2);
        }

        [TestMethod]
        public void IsInShapeMethod_ShouldReturnFalse()
        {
            // Arrange
            Shape shape = new Shape();

            // Act
            bool isInShape = shape.IsInShape(1, 1);

            // Assert
            Assert.IsFalse(isInShape);
        }

        [TestMethod]
        public void ArrangeDoubleNumbersMethod_ShouldArrangeNumbers()
        {
            // Arrange
            Shape shape = new Rectangle();
            Pair firstPair = new Pair(2, 4);
            Pair secondPair = new Pair(1, 3);
            shape.FirstPair = firstPair;
            shape.SecondPair = secondPair;

            // Act
            shape.ArrangePairs();

            // Assert
            Assert.AreEqual(1, shape.FirstPair.Number1);
            Assert.AreEqual(3, shape.FirstPair.Number2);
            Assert.AreEqual(2, shape.SecondPair.Number1);
            Assert.AreEqual(4, shape.SecondPair.Number2);
        }

        [TestMethod]
        public void GetInfo_ShouldReturnEmptyString()
        {
            // Arrange
            Shape shape = new Shape();
            Pair firstPair = new Pair(1, 1);
            Pair secondPair = new Pair(3, 3);
            shape.FirstPair = firstPair;
            shape.SecondPair = secondPair;

            // Act
            string info = shape.GetInfo();

            // Assert
            Assert.AreEqual(string.Empty, info);
        }

        [TestMethod]
        public void Draw_ShouldNotCallAnyDrawMethods()
        {
            // Arrange
            MockGraphics graphics = new MockGraphics();
            Shape shape = new Shape();

            // Act
            shape.Draw(graphics);

            // Assert
            Assert.IsFalse(graphics.DrawEllipseCalled);
            Assert.IsFalse(graphics.DrawRectangleCalled);
            Assert.IsFalse(graphics.DrawLineCalled);
            Assert.IsFalse(graphics.DrawLineHandleCalled);
            Assert.IsFalse(graphics.DrawRectangleHandleCalled);
        }

        [TestMethod]
        public void OnPropertyChanged_ShouldRaiseEventWithCorrectPropertyName()
        {
            // Arrange
            Shape shape = new Shape();
            bool eventRaised = false;
            string propertyName = null;
            shape.PropertyChanged += (sender, args) =>
            {
                eventRaised = true;
                propertyName = args.PropertyName;
            };

            // Act
            shape.NameChinese = "New Name";

            // Assert
            Assert.IsTrue(eventRaised);
            Assert.AreEqual(nameof(Shape.NameChinese), propertyName);
        }
    }
}
