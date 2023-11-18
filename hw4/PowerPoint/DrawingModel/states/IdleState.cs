using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        // asd
        public void Draw(IGraphics graphics)
        {
        }

        // asd
        public void MouseDown(float number1, float number2)
        {
        }

        // asd
        public void MouseMove(float number1, float number2)
        {

        }

        // asd
        public void MouseUp(float number1, float number2)
        {
            
        }

        // asd
        public void KeyPressed(Keys keys)
        {
        }
    }
}