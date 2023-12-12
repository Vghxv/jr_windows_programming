using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DrawingModel
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler(EventArgs e);
        private Shapes _shapes;
        private Pair _adjustPoint;
        private bool _isCloseToAdjust;
        private ModelState _modelState;
        private CommandManager _commandManager;

        public CommandManager CommandManager
        {
            get
            {
                return _commandManager;
            }
        }

        public virtual Shapes Shapes
        {
            get
            {
                return _shapes;
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

        public virtual bool IsCloseToAdjust
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
            _commandManager = new CommandManager();
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

        // handle canvas pressed
        public virtual void HandleCanvasPressed(float number1, float number2)
        {
            _modelState.MouseDown(number1, number2);
        }

        // handle canvas moved
        public virtual void HandleCanvasMoved(float number1, float number2)
        {
            _modelState.MouseMove(number1, number2);
        }

        // handle canvas released
        public virtual void HandleCanvasReleased(float number1, float number2)
        {
            _modelState.MouseUp(number1, number2);
        }

        // handle key down
        public virtual void HandleKeyDown(Keys keys)
        {
            _modelState.KeyPressed(keys);
        }

        // add _shape by _shape
        public virtual void AddShape(Shape shape)
        {
            _shapes.AddShape(shape);
        }

        // move _shape
        public virtual void MoveShape(Shape shape ,Pair offset)
        {
            _shapes.MoveShape(shape, offset);
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

        // notify _model changed 
        public virtual void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged(new EventArgs());
        }

        // closeness to adjustPoint
        public bool IsCloseToAdjustPoint(float number1, float number2)
        {
            float deltaX = number1 - _adjustPoint.Number1;
            float deltaY = number2 - _adjustPoint.Number2;
            float distance = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            return distance < Constant.POINT_DELTA;
        }

        // generate two random pair
        public (Pair, Pair) GenerateTwoPairs(Size size)
        {
            int seed = PairFactory.GetSeed(0);
            Pair widthRange = new Pair(0, size.Width);
            Pair heightRange = new Pair(0, size.Height);
            Pair firstPair = PairFactory.CreateRandomPair(widthRange, heightRange, seed);
            seed = PairFactory.GetSeed(Constant.RANDOM_SEED);
            Pair secondPair = PairFactory.CreateRandomPair(widthRange, heightRange, seed);
            return (firstPair, secondPair);
        }

        // resize shapes 
        public void ResizeShapes(Size original, Size target)
        {
            _shapes.ResizeShapes(new Pair(original), new Pair(target));
        }
    }
}