using DrawingModel;
using System;
using System.Drawing;

namespace DrawingModel
{
    public class DrawCommand : ICommand
    {
        private Shape _shape;
        private Model _model;

        public DrawCommand(Model model, Shape shape)
        {
            _shape = shape;
            _model = model;
        }

        // execute
        public void Execute()
        {
            _model.AddShape(_shape);
        }

        // unexecute
        public void ReverseExecute()
        {
            _model.RemoveShape(_shape);
        }
    }
}
