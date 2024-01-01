using DrawingModel;
using System;
using System.Drawing;

namespace DrawingModel
{
    public class AddCommand : ICommand
    {
        Shape _shape;
        Model _model;

        public AddCommand(Model model, Shape shape)
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
