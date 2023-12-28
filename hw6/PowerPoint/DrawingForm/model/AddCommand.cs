using DrawingModel;
using System;
using System.Drawing;

namespace DrawingModel
{
    class AddCommand : ICommand
    {
        Shape _shape;
        Model _model;

        public AddCommand(Model model, Shape shape)
        {
            _shape = shape;
            _model = model;
        }

        public void Execute()
        {
            _model.AddShape(_shape);
        }

        public void UnExecute()
        {
            _model.RemoveShape(_shape);
        }
    }
}
