using System;
namespace DrawingModel
{
    public class ShapeFactory
    {
        // asd
        public static Shape CreateShape(string shapeName, Pair firstPair, Pair secondPair)
        {
            return (Shape)Activator.CreateInstance(
            Type.GetType(shapeName.ToString()),
            firstPair, secondPair);
        }

        // asd
        public static Shape CreateShape(string shapeName)
        {
            return (Shape)Activator.CreateInstance(
            Type.GetType(shapeName.ToString()));
        }
    }
}
