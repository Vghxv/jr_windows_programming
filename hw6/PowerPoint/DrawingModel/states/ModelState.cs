using System.Windows.Forms;

namespace DrawingModel
{
    public interface ModelState
    {
        // mouse down
        void MouseDown(float number1, float number2);
        
        // mouse up
        void MouseUp(float number1, float number2);
        
        // mouse move
        void MouseMove(float number1, float number2);
        
        // draw
        void Draw(IGraphics graphics);

        // key pressed
        void KeyPressed(Keys keys);
    }
}