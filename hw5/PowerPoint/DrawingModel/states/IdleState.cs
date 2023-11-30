using System;
using System.Windows.Forms;

namespace DrawingModel
{
    public class IdleState : ModelState
    {
        private Model _model;
        
        public IdleState(Model model)
        {
            _model = model;
            _model.SetShapeSelected(false);
            _model.NotifyModelChanged();
        }

        // Draw
        public void Draw(IGraphics graphics)
        {
        }

        // MouseDown
        public void MouseDown(float number1, float number2)
        {
        }

        // MouseMove
        public void MouseMove(float number1, float number2)
        {
        }

        // MouseUp
        public void MouseUp(float number1, float number2)
        {
            foreach (Shape shape in _model.Shapes.ShapeList)
            {
                if (shape.IsInShape(number1, number2))
                {
                    shape.IsSelected = true;
                    _model.CurrentState = new SelectingState(_model);
                    _model.AdjustPoint = shape.SecondPair;
                    _model.NotifyModelChanged();
                    break;
                }
            }
        }

        // KeyPressed
        public void KeyPressed(Keys keys)
        {
        }
    }
}