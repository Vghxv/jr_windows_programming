using System;
namespace DrawingModel
{
    public class ShapeFactory
    {
        // asd
        public static Shape CreateShape(string shapeName, Pair firstDoubleNumber, Pair secondDoubleNumber)
        {
            return (Shape)Activator.CreateInstance(
            Type.GetType(shapeName.ToString()),
            firstDoubleNumber, secondDoubleNumber);
        }

        // asd
        public static Shape CreateShape(string shapeName)
        {
            return (Shape)Activator.CreateInstance(
            Type.GetType(shapeName.ToString()));
        }
    }
}
