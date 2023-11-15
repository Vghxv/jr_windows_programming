using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DrawingModel
{
    class ShapeFactory
    {
        // asd
        public static Shape CreateShape(string shapeName, DoubleNumber firstDoubleNumber, DoubleNumber secondDoubleNumber)
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
