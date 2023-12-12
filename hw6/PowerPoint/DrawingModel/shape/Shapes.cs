using System.Collections.Generic;
using System.ComponentModel;
namespace DrawingModel
{
    public class Shapes
    {
        public Shapes()
        {
            ShapeList = new BindingList<Shape>();
        }

        public virtual BindingList<Shape> ShapeList
        {
            get;
            set;
        }

        // return enumerator function
        public IEnumerator<Shape> GetEnumerator()
        {
            return ShapeList.GetEnumerator();
        }

        // add shape
        public virtual void AddShape(Shape shape)
        {
            if (!(shape is Line))
            {
                shape.ArrangePairs();
            }
            ShapeList.Add(shape);
        }

        // remove shape
        public virtual void RemoveShape(Shape shape)
        {
            ShapeList.Remove(shape);
        }

        // clear shapes
        public virtual void ClearShapes()
        {
            ShapeList.Clear();
        }

        // set all shapes isSelected bool
        public virtual void SetAllShapeSelected(bool selected)
        {
            foreach (Shape shape in ShapeList)
            {
                shape.IsSelected = selected;
            }
        }

        // rearrange shapes points
        public virtual void ArrangeShapesPoints()
        {
            foreach (Shape shape in ShapeList)
            {
                if (!(shape is Line))
                {
                    shape.ArrangePairs();
                }
            }
        }

        // resize shapes 
        public virtual void ResizeShapes(Pair original, Pair target)
        {
            foreach (Shape shape in ShapeList)
            {
                shape.Resize(original, target);
            }
        }

        // move shapes
        public virtual void MoveShape(Shape targetShape, Pair offset)
        {
            foreach (Shape shape in ShapeList)
            {
                if (shape == targetShape)
                {
                    shape.Move(new Pair(offset));
                    return;
                }
            }
        }
    }
}
