using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Model
    {
        private Shapes _shapes;
                                
        public Model()
        {
            _shapes = new Shapes();
        }

        // get shapes
        public Shapes GetShapes()
        { 
            return _shapes;	
        }

        //		add a shape to _shapes
        public void AddShape(string shapeType)
        {
            _shapes.AddShape(shapeType);
        }

        //		remove a shape from _shapes
        public void RemoveShape(Shape shape)
        {
            _shapes.RemoveShape(shape);
        }

        // sfds
        public void GetShape(int index)
        {
            _shapes.GetShape(index);
        }
                                
        // ad
        public Shape GetLastShape()
        {
            return _shapes.GetLastShape();
        }
    }
}