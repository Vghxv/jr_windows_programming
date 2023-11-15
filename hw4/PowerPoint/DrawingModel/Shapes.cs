using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Shapes
    {
        private BindingList<Shape> _shapeList;
        public BindingList<Shape> ShapeList
        {
            get
            {
                return _shapeList;
            }
        }

        public Shapes()
        {
            _shapeList = new BindingList<Shape>();
        }

        // return enumerator function
        public IEnumerator<Shape> GetEnumerator()
        {
            return _shapeList.GetEnumerator();
        }

        // add a shape to _shapeList
        public void AddShape(string shapeType, DoubleNumber firstDoubleNumber, DoubleNumber secondDoubleNumber)
        {
            _shapeList.Add(ShapeFactory.CreateShape(shapeType, firstDoubleNumber, secondDoubleNumber));
        }

        // add shape
        public void AddShape(Shape shape)
        {
            if ( !(shape is Line))
            {
                shape.ArrangeDoubleNumbers();
            }
            _shapeList.Add(shape);
        }

        // remove a shape from _shapeList by index
        public void RemoveShape(int index)
        {
            _shapeList.RemoveAt(index);
        }

        // asd
        public void ClearShapes()
        {
            _shapeList.Clear();
        }

        // sad
        public void SetShapeSelected(bool selected)
        {
            foreach (Shape shape in _shapeList)
            {
                shape.IsSelected = selected;
            }
        }
    }
}
