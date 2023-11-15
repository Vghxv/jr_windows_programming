using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PowerPoint
{
    class ShapeFactory
    {
        private const string ASSEMBLY_NAME = "PowerPoint.";

        private const int MIN_X = 0;
        private const int MIN_Y = 0;
        private const int MAX_X = 500;
        private const int MAX_Y = 500;
        // public static Shape CreateShape(string shapeName, Vector2d vector2D1, Vector2d vector2D2)
        public static Shape CreateShape(string shapeNameChinese)
        {
            StringBuilder shapeName = new StringBuilder("");
            if ( shapeNameChinese == Shape.RECTANGLE_CHINESE)
            {
                shapeName.Append(Shape.RECTANGLE);
            }
            else if ( shapeNameChinese == Shape.LINE_CHINESE)
            {
                shapeName.Append(Shape.LINE);
            }
            DoubleNumber firstDoubleNumber = DoubleNumberFactory.CreateRandomDoubleNumber(MIN_X, MAX_X, MIN_Y, MAX_Y);
            DoubleNumber secondDoubleNumber = DoubleNumberFactory.CreateRandomDoubleNumber(firstDoubleNumber.Number1, MAX_X, firstDoubleNumber.Number2, MAX_Y);
            return (Shape)Activator.CreateInstance(Type.GetType(ASSEMBLY_NAME + shapeName.ToString()), firstDoubleNumber, secondDoubleNumber);
        }
    }
}
