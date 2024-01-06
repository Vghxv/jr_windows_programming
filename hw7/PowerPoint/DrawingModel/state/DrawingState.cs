using System.Windows.Forms;

namespace DrawingModel
{
    public class DrawingState : ModelState
    {
        private Model _model;
        private Shape _hint;
        public bool IsPressed
        {
            get; set;
        }
        public DrawingState(Model model, Shape shape)
        {
            _model = model;
            _hint = shape;
        }

        //  Draw
        public void Draw(IGraphics graphics)
        {
            if (IsPressed)
            {
                _hint.Draw(graphics);
            }
        }

        // MouseDown
        public void MouseDown(float number1, float number2)
        {
            _hint.FirstPair = new Pair(number1, number2);
            IsPressed = true;
        }

        // MouseMove
        public void MouseMove(float number1, float number2)
        {
            if (IsPressed)
            {
                _hint.SecondPair = new Pair(number1, number2);
                _model.NotifyModelChanged();
            }
        }

        // MouseUp
        public void MouseUp(float number1, float number2)
        {
            if (IsPressed) 
            {
                _hint.SecondPair = new Pair(number1, number2);
                _model.CommandManager.Execute(new DrawCommand(_model, _hint));
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