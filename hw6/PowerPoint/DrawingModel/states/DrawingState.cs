using System.Windows.Forms;

namespace DrawingModel
{
    public class DrawingState : ModelState
    {
        private Model _model;
        public bool IsPressed
        {
            get; set;
        }
        public DrawingState(Model model)
        {
            _model = model;
        }

        //  Draw
        public void Draw(IGraphics graphics)
        {
            if (IsPressed)
            {
                _model.DrawHint(graphics);
            }
        }

        // MouseDown
        public void MouseDown(float number1, float number2)
        {
            _model.SetHintFirstPoint(number1, number2);
            IsPressed = true;
        }

        // MouseMove
        public void MouseMove(float number1, float number2)
        {
            if (IsPressed)
            {
                _model.SetHintSecondPoint(number1, number2);
                _model.NotifyModelChanged();
            }
        }

        // MouseUp
        public void MouseUp(float number1, float number2)
        {
            if (IsPressed) 
            {
                _model.SetHintSecondPoint(number1, number2);
                _model.AddHintToShapes();
                IsPressed = false;
                _model.CurrentState = new IdleState(_model);
                _model.NotifyModelChanged();
            }
        }

        // KeyPressed
        public void KeyPressed(Keys keys)
        {
        }
    }
}