using System.CodeDom;
using System.Windows.Forms;
namespace DrawingModel
{
    public class SelectingState : ModelState
    {
        private Model _model;
        private Pair _startPair;
        private Pair _lastPair;
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

        // perform checks in MouseDown
        public void MouseDownCheck(float number1, float number2)
        {
            foreach (Shape shape in _model.GetCurrentPageShapes())
            {
                if (shape.IsInShape(number1, number2))
                {
                    _model.AdjustPoint = shape.SecondPair;
                    shape.IsSelected = true;
                    _isMousePressedOnSelected = true;
                    _startPair = _lastPair = new Pair(number1, number2);
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

        // called in MouseMove when mouse is pressed on adjust
        public void AdjustShapes(float number1, float number2)
        {
            foreach (Shape shape in _model.GetCurrentPageShapes())
            {
                if (shape.IsSelected)
                {
                    Pair pair = new Pair(number1, number2);
                    shape.SecondPair += (pair - _lastPair);
                    _lastPair = new Pair(pair);
                    _model.AdjustPoint = shape.SecondPair;
                    _model.NotifyModelChanged();
                    return;
                }
            }
        }

        // called in MouseMove when mouse is pressed on selected
        public void MoveShapes(float number1, float number2)
        {
            foreach (Shape shape in _model.GetCurrentPageShapes())
            {
                if (shape.IsSelected)
                {
                    Pair pair = new Pair(number1, number2);
                    shape.Move(pair - _lastPair);
                    _lastPair = new Pair(pair);
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
            foreach (Shape shape in _model.GetCurrentPageShapes())
            {
                if (_isMousePressedOnAdjust)
                {
                    var location = shape.GetLocation();
                    _model.CommandManager.Execute(new ResizeCommand(_model, shape, location.Item1 - shape.FirstPair, location.Item2 - _startPair));
                    break;
                }
                else if (_isMousePressedOnSelected)
                {
                    _model.CommandManager.Execute(new MoveCommand(_model, shape, new Pair(number1, number2) - _startPair));
                    break;
                }
            }
            _isMousePressedOnSelected = false;
            _isMousePressedOnAdjust = false;
            _model.IsCloseToAdjust = _model.IsCloseToAdjustPoint(number1, number2);
            _model.ArrangeShapesPoints();
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
                foreach (Shape shape in _model.GetCurrentPageShapes())
                {
                    if (shape.IsSelected)
                    {
                        _model.CommandManager.Execute(new DeleteCommand(_model, shape));
                        _model.NotifyModelChanged();
                        break;
                    }
                }
            }
        }
    }
}
