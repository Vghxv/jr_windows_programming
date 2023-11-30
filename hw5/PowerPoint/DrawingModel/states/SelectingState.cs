using System;
using System.Windows.Forms;
namespace DrawingModel
{
    public class SelectingState : ModelState
    {
        private Model _model;
        protected Pair _lastPoint;
        private bool _isMousePressedOnSelected;
        private bool _isMousePressedOnAdjust;
        public bool IsMousePressedOnSelected
        {
            get
            {
                return _isMousePressedOnSelected;
            }
            set
            {
                _isMousePressedOnSelected = value;
            }
        }
        public bool IsMousePressedOnAdjust
        {
            get
            {
                return _isMousePressedOnAdjust;
            }
            set
            {
                _isMousePressedOnAdjust = value;
            }
        }

        public SelectingState(Model model)
        {
            _model = model;
        }

        // MouseDownCheck
        public void MouseDownCheck(float number1, float number2)
        {
            foreach (Shape shape in _model.Shapes.ShapeList)
            {
                if (shape.IsInShape(number1, number2))
                {
                    _model.AdjustPoint = shape.SecondPair;
                    shape.IsSelected = true;
                    _isMousePressedOnSelected = true;
                    _lastPoint = new Pair(number1, number2);
                    _isMousePressedOnAdjust = _model.IsCloseToAdjustPoint(number1, number2);
                    break;
                }
            }
        }

        // MouseDown
        public void MouseDown(float number1, float number2)
        {
            _model.SetShapeSelected(false);
            MouseDownCheck(number1, number2);
            if (!_isMousePressedOnSelected && !_isMousePressedOnAdjust)
            {
                _model.SetShapeSelected(false);
                _model.CurrentState = new IdleState(_model);
            }
            _model.NotifyModelChanged();
        }

        // MouseMoveOnAdujst
        public void AdjustShapes(float number1, float number2)
        {
            foreach (Shape shape in _model.Shapes.ShapeList)
            {
                if (shape.IsSelected)
                {
                    Pair pair = new Pair(number1, number2);
                    shape.SecondPair += (pair - _lastPoint);
                    _lastPoint = new Pair(pair);
                    _model.AdjustPoint = shape.SecondPair;
                    _model.NotifyModelChanged();
                    return;
                }
            }
        }

        // MouseMoveOnSelected
        public void MoveShapes(float number1, float number2)
        {
            foreach (Shape shape in _model.Shapes.ShapeList)
            {
                if (shape.IsSelected)
                {
                    Pair pair = new Pair(number1, number2);
                    shape.Move(pair - _lastPoint);
                    _lastPoint = new Pair(pair);
                    _model.AdjustPoint = shape.SecondPair;
                    _model.NotifyModelChanged();
                    return;
                }
            }
        }

        // MouseMove
        public void MouseMove(float number1, float number2)
        {
            if (_isMousePressedOnAdjust)
            {
                AdjustShapes(number1, number2);
            }
            else if (_isMousePressedOnSelected)
            {
                MoveShapes(number1, number2);
            }
            else
            {
                _model.IsCloseToAdjust = _model.IsCloseToAdjustPoint(number1, number2);
                _model.NotifyModelChanged();
            }
        }

        // MouseUp
        public void MouseUp(float number1, float number2)
        {
            _isMousePressedOnSelected = false;
            _isMousePressedOnAdjust = false;
            _model.IsCloseToAdjust = _model.IsCloseToAdjustPoint(number1, number2);
            _model.Shapes.ArrangeShapesPoints();
            _model.NotifyModelChanged();
        }

        // Draw
        public void Draw(IGraphics graphics)
        {
        }

        // KeyPressed
        public void KeyPressed(Keys keyCode)
        {
            if (keyCode == Keys.Delete)
            {
                foreach (Shape shape in _model.Shapes.ShapeList)
                {
                    if (shape.IsSelected)
                    {
                        _model.RemoveShape(_model.Shapes.ShapeList.IndexOf(shape));
                        _model.NotifyModelChanged();
                        break;
                    }
                }
            }
        }
    }
}
