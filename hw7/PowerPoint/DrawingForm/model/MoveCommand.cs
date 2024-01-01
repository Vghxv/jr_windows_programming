using System.Drawing;

namespace DrawingModel
{
    public class MoveCommand : ICommand
    {
        Model _model;
        Shape _shape;
        Point _offset;
        // ensure that the first excute will not move the shape
        bool _firstMove;
        public MoveCommand(Model model, Shape shape, Point offset)
        {
            _model = model;
            _shape = shape;
            _offset = offset;
            _firstMove = true;
        }

        // execute command
        public void Execute()
        {
            if (_firstMove)
            {
                _firstMove = false;
                return;
            }
            _model.MoveShape(_shape, _offset);
        }

        // unexecute commmand
        public void Unexecute()
        {
            _model.MoveShape(_shape, new Point(-_offset.X, -_offset.Y));
        }
    }
}