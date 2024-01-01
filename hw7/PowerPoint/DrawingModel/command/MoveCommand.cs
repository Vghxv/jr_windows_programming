using System.Drawing;

namespace DrawingModel
{
    public class MoveCommand : ICommand
    {
        private Model _model;
        private Shape _shape;
        private Pair _offset;
        private bool _firstTime;
        public MoveCommand(Model model, Shape shape, Pair offset)
        {
            _model = model;
            _shape = shape;
            _offset = offset;
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
            _model.MoveShape(_shape, _offset);
        }

        // unexecute commmand
        public void ReverseExecute()
        {
            _model.MoveShape(_shape, -_offset);
        }
    }
}