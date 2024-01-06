using System.Drawing;

namespace DrawingModel
{
    public class ResizeCommand : ICommand
    {
        private Model _model;
        private Shape _shape;
        private Pair _offset1;
        private Pair _offset2;
        private bool _firstTime;
        public ResizeCommand(Model model, Shape shape, Pair offset1, Pair offset2)
        {
            _model = model;
            _shape = shape;
            _offset1 = offset1;
            _offset2 = offset2;
            _firstTime = true;
        }

        // execute command
        public void Execute()
        {
            if (_firstTime)
            {
                _firstTime = false;
                return;
            }
            _model.ResizeShape(_shape, _offset1, _offset2);
        }

        // unexecute commmand
        public void ReverseExecute()
        {
            _model.ResizeShape(_shape, -_offset1, -_offset2);
        }
    }
}