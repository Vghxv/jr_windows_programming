using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;

namespace DrawingModel
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler(EventArgs e);
        public event ModelChangedEventHandler _pageChanged;
        public delegate void PageChangedEventHandler(EventArgs e);
        private List<Page> _pages;
        private Page _currentPage;
        private Pair _adjustPoint;
        private bool _isCloseToAdjust;
        private ModelState _modelState;
        private CommandManager _commandManager;
        
        public int CurrentPageIndex
        {
            get
            {
                return _pages.IndexOf(_currentPage);
            }
            set {
               _currentPage = _pages[value];
            }
        }

        public CommandManager CommandManager
        {
            get
            {
                return _commandManager;
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
            //_shapes = new Shapes();
            _modelState = new IdleState(this);
            _commandManager = new CommandManager();
            _currentPage = new Page(_modelState);
            _pages = new List<Page>
            {
                _currentPage
            };
        }

        // remove shape
        public virtual void RemoveShape(Shape shape)
        {
            _currentPage.RemoveShape(shape);
        }

        // clear shapes
        public void ClearShapes()
        {
            _currentPage.ClearShapes();
        }

        // set all shapes isSelected bool
        public void SetShapeSelected(bool isSelected)
        {
            if (_currentPage == null)
                return;
            _currentPage.SetShapeSelected(isSelected);
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
            _currentPage.AddShape(shape);
        }

        // move _shape
        public virtual void MoveShape(Shape shape, Pair offset)
        {
            _currentPage.MoveShape(shape, offset);
        }

        // resize shape
        public virtual void ResizeShape(Shape shape, Pair offset1, Pair offset2)
        {
            _currentPage.ResizeShape(shape, offset1, offset2);
        }

        // draw
        public void Draw(IGraphics graphics)
        {
            _currentPage.Draw(graphics);
        }

        // notify _model changed 
        public virtual void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged(new EventArgs());
        }

        // notify page changed
        public virtual void NotifyPageChanged()
        {
            if (_pageChanged != null)
                _pageChanged(new EventArgs());
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
        //public (Pair, Pair) GenerateTwoPairs(Size size)
        //{
        //    int seed = PairFactory.GetSeed(0);
        //    Pair widthRange = new Pair(0, size.Width);
        //    Pair heightRange = new Pair(0, size.Height);
        //    Pair firstPair = PairFactory.CreateRandomPair(widthRange, heightRange, seed);
        //    seed = PairFactory.GetSeed(Constant.RANDOM_SEED);
        //    Pair secondPair = PairFactory.CreateRandomPair(widthRange, heightRange, seed);
        //    return (firstPair, secondPair);
        //}

        // resize shapes 
        public void ResizeShapes(Size original, Size target)
        {
            _currentPage.ResizeShapes(original, target);
        }

        // get current page shapes
        public BindingList<Shape> GetCurrentPageShapes()
        {
            return _currentPage.Shapes.ShapeList;
        }

        // handle ArrangeShapesPoints
        public void ArrangeShapesPoints()
        {
            _currentPage.ArrangeShapesPoints();
        }

        // set current page by index
        //public void SetCurrentPage(int index)
        //{
        //    _currentPage = _pages[index];
        //    NotifyPageChanged();
        //}
        // add page
        public void AddPageClick()
        {
            _currentPage = new Page(_modelState);
            _pages.Add(_currentPage);
            NotifyPageChanged();
        }
    }
}