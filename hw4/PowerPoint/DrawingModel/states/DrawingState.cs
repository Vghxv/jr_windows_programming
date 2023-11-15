using System.Windows.Forms;

namespace DrawingModel
{
    public class DrawingState : ModelState
    {
        private Model _model;
        private bool IsPressed
        {
            get; set;
        }
        public DrawingState(Model model)
        {
            _model = model;
        }

        //  draw
        public void Draw(IGraphics graphics)
        {
            if (IsPressed)
            {
                _model.DrawHint(graphics);
            }
        }

        // pointerpressed
        public void MouseDown(float number1, float number2)
        {
            _model.SetHintFirstPoint(number1, number2);
            IsPressed = true;
        }

        // pointermoved
        public void MouseMove(float number1, float number2)
        {
            if (IsPressed)
            {
                _model.SetHintSecondPoint(number1, number2);
            }
        }

        // asd
        public void MouseUp(float number1, float number2)
        {
            if (IsPressed) 
            { 
                _model.AddHintToShapes();
                IsPressed = false;
                _model.SetState(new IdleState(_model));
            }
        }

        // asd
        public void KeyPressed(Keys keys)
        {
            
        }
    }
}