using DrawingModel;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace WindowPowerPoint
{
    public class SelectingState : ModelState
    {
        private Model _model;
        private bool _isPressed;
        private DoubleNumber _lastPoint;
        public SelectingState(Model model)
        {
            _model = model;
        }

        // handle mouse down
        public void MouseDown(float number1, float number2)
        {
            _model.SetShapeSelected(false);
            foreach (Shape shape in _model.ShapesManager.ShapeList)
            {
                if (shape.IsInShape(number1, number2))
                {
                    shape.IsSelected = true;
                    _isPressed = true;
                    _lastPoint = new DoubleNumber(number1, number2);
                    break;
                }
            }
            if (!_isPressed)
            {
                _model.SetShapeSelected(false);
            }
            _model.NotifyModelChanged();
        }

        // handle mouse move
        public void MouseMove(float number1, float number2)
        {
            if (_isPressed)
            {
                foreach (Shape shape in _model.ShapesManager.ShapeList)
                {
                    if (shape.IsSelected)
                    {
                        DoubleNumber doubleNumber = new DoubleNumber(number1, number2);
                        shape.Move(doubleNumber - _lastPoint);
                        _lastPoint = new DoubleNumber(number1, number2);
                        _model.NotifyModelChanged();
                        break;
                    }
                }
            }
        }

        // handle mouse up
        public void MouseUp(float number1, float number2)
        {
            _isPressed = false;
            _model.NotifyModelChanged();
        }

        // handle Draw
        public void Draw(IGraphics graphics)
        {

        }

        // handle key down
        public void KeyPressed(Keys keyCode)
        {
            Console.WriteLine(keyCode);
            if (keyCode == Keys.Delete)
            {
                foreach (Shape shape in _model.ShapesManager.ShapeList)
                {
                    if (shape.IsSelected)
                    {
                        _model.RemoveShape(_model.ShapesManager.ShapeList.IndexOf(shape));
                        _model.NotifyModelChanged();
                        break;
                    }
                }
            }
        }
    }
}
