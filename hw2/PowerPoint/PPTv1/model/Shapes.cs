using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Shapes
    {
        private List<Shape> _shapeArray;
        public Shapes()
        {
            _shapeArray = new List<Shape>();
        }

        // add a shape to _shapeArray
        public void AddShape(string shapeType)
        {
            _shapeArray.Add(ShapeFactory.CreateShape(shapeType));
        }

        //	remove a shape from _shapeArray
        public void RemoveShape(Shape shape)
        {
            _shapeArray.Remove(shape);
        }

        //		remove a shape from _shapeArray by index
        public void RemoveShape(int index)
        {
            _shapeArray.RemoveAt(index);
        }

        //		get a shape from _shapeArray by index
        public Shape GetShape(int index)
        {
            return _shapeArray[index];
        }

        // return last
        public Shape GetLastShape()
        {
            return _shapeArray[ _shapeArray.Count - 1 ];
        }

        //		get the number of shapes in _shapeArray
        public int GetShapeCount()
        {
            return _shapeArray.Count;
        }

        //		get _shapeArray
        public List<Shape> GetShapeArray() 
        { 
            return _shapeArray;
        }
    }
}
