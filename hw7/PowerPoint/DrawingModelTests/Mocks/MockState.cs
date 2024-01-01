using System.Windows.Forms;

namespace DrawingModel.Tests
{
    // MockModelState class extends ModelState for testing purposes
    public class MockModelState : ModelState
    {
        public bool MouseDownCalled
        {
            get;
            private set;
        }

        public bool MouseMoveCalled
        {
            get;
            private set;
        }

        public bool MouseUpCalled
        {
            get;
            private set;
        }

        public bool KeyPressedCalled
        {
            get;
            private set;
        }

        public bool DrawCalled
        {
            get;
            private set;
        }

        public float LastNumber1
        {
            get;
            private set;
        }

        public float LastNumber2
        {
            get;
            private set;
        }

        public Keys LastKeys
        {
            get;
            private set;
        }

        public IGraphics LastGraphics
        {
            get;
            private set;
        }

        // Method to handle mouse down event
        public void MouseDown(float number1, float number2)
        {
            MouseDownCalled = true;
            LastNumber1 = number1;
            LastNumber2 = number2;
        }

        // Method to handle mouse move event
        public void MouseMove(float number1, float number2)
        {
            MouseMoveCalled = true;
            LastNumber1 = number1;
            LastNumber2 = number2;
        }

        // Method to handle mouse up event
        public void MouseUp(float number1, float number2)
        {
            MouseUpCalled = true;
            LastNumber1 = number1;
            LastNumber2 = number2;
        }

        // Method to handle drawing
        public void Draw(IGraphics graphics)
        {
            DrawCalled = true;
            LastGraphics = graphics;
        }

        // Method to handle key pressed event
        public void KeyPressed(Keys keys)
        {
            KeyPressedCalled = true;
            LastKeys = keys;
        }
    }
}
