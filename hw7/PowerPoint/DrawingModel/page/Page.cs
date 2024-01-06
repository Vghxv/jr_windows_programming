using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingModel
{
    public class Page
    {
        private Shapes _shapes;
        private ModelState _modelState;
        
        public Page(ModelState modelState)
        {
            _shapes = new Shapes();
            _modelState = modelState;
        }

        public virtual Shapes Shapes
        {
            get
            {
                return _shapes;
            }
        }

        // remove shape
        public virtual void RemoveShape(Shape shape)
        {
            _shapes.RemoveShape(shape);
        }

        // clear shapes
        public void ClearShapes()
        {
            _shapes.ClearShapes();
        }

        // set all shapes isSelected bool
        public void SetShapeSelected(bool isSelected)
        {
            _shapes.SetAllShapeSelected(isSelected);
        }

        // add _shape by _shape
        public virtual void AddShape(Shape shape)
        {
            _shapes.AddShape(shape);
        }

        // move _shape
        public virtual void MoveShape(Shape shape, Pair offset)
        {
            _shapes.MoveShape(shape, offset);
        }

        // resize shape
        public virtual void ResizeShape(Shape shape, Pair offset1, Pair offset2)
        {
            _shapes.ResizeShape(shape, offset1, offset2);
        }

        // draw
        public void Draw(IGraphics graphics)
        {
            foreach (Shape shape in _shapes)
            {
                shape.Draw(graphics);
            }
            _modelState.Draw(graphics);
        }

        // handle resize shape
        public void ResizeShapes(Size original, Size target)
        {
            _shapes.ResizeShapes(new Pair(original), new Pair(target));
        }

        // handle ArrangeShapesPoints
        public void ArrangeShapesPoints()
        {
            _shapes.ArrangeShapesPoints();
        }
    }
}
    