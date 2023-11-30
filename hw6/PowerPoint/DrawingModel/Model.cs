using System;
using System.Windows.Forms;

namespace DrawingModel
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler(EventArgs e);
        private Shapes _shapes;
        private Shape _hint;
        private Pair _adjustPoint;
        private bool _isCloseToAdjust;
        private ModelState _modelState;

        public Shapes Shapes
        {
            get
            {
                return _shapes;
            }
        }

        public Shape Hint
        {
            get
            {
                return _hint;
            }
        }

        public virtual ModelState CurrentState
        {
            get
            {
                return _modelState;
            }
            set
            {
                _modelState = value;
            }
        }

        public Pair AdjustPoint
        {
            get
            {
                return _adjustPoint;
            }
            set
            {
                _adjustPoint = value;
            }
        }

        public bool IsCloseToAdjust
        {
            get
            {
                return _isCloseToAdjust;
            }
            set
            {
                _isCloseToAdjust = value;
            }
        }
        public Model() 
        { 
            _shapes = new Shapes();
            _modelState = new IdleState(this);
        }

        // remove shape by index
        public void RemoveShape(int index)
        {
            _shapes.RemoveShape(index);
        }

        // clear shapes
        public void ClearShapes()
        {
            _shapes.ClearShapes();
        }

        // set all shapes isSelected bool
        public void SetShapeSelected(bool isSelected)
        {
            _shapes.SetShapeSelected(isSelected);
        }

        // handle canvas pressed
        public void HandleCanvasPressed(float number1, float number2)
        {
            _modelState.MouseDown(number1, number2);
        }

        // handle canvas moved
        public void HandleCanvasMoved(float number1, float number2)
        {
            _modelState.MouseMove(number1, number2);
        }

        // handle canvas released
        public void HandleCanvasReleased(float number1, float number2)
        {
            _modelState.MouseUp(number1, number2);
        }

        // handle key down
        public void HandleKeyDown(Keys keys)
        {
            _modelState.KeyPressed(keys);
        }

        // add shape by name
        public void AddShape(string name)
        {
            Pair firstPair = PairFactory.CreateRandomDoubleNumber(
            Constant.MIN_X, Constant.MAX_X, Constant.MIN_Y, Constant.MAX_Y);
            Pair secondPair = PairFactory.CreateRandomDoubleNumber(
            (int)firstPair.Number1, Constant.MAX_X, (int)firstPair.Number2, Constant.MAX_Y);
            _shapes.AddShape(name, firstPair, secondPair);
        }

        // add shape by shape
        public virtual void AddShape(Shape shape)
        {
            _shapes.AddShape(shape);
        }

        // add hint to shapes
        public virtual void AddHintToShapes()
        {
            _shapes.AddShape(_hint);
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

        // notify model changed 
        public virtual void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged(new EventArgs());
        }

        // set hint
        public void SetHint(Shape shape)
        {
            _hint = shape;
        }

        // draw hint
        public virtual void DrawHint(IGraphics graphics)
        {
            _hint.Draw(graphics);
        }

        // set hint first point
        public virtual void SetHintFirstPoint(float number1, float number2)
        {
            _hint.FirstPair.Number1 = number1;
            _hint.FirstPair.Number2 = number2;
        }

        // set hint second point
        public virtual void SetHintSecondPoint(float number1, float number2)
        {
            _hint.SecondPair.Number1 = number1;
            _hint.SecondPair.Number2 = number2;
        }

        // closeness to adjustPoint
        public bool IsCloseToAdjustPoint(float number1, float number2)
        {
            float deltaX = number1 - _adjustPoint.Number1;
            float deltaY = number2 - _adjustPoint.Number2;
            float distance = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            return distance < Constant.POINT_DELTA;
        }
    }
}