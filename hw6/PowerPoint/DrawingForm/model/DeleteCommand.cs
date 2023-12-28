namespace DrawingModel
{
    public class DeleteCommand : ICommand
    {
        Model _model;
        Shape _shape;
        public DeleteCommand(Model model, Shape shape)
        {
            _model = model;
            _shape = shape;
        }

        // execute command
        public void Execute()
        {
            _model.RemoveShape(_shape);
        }

        // execute command with index
        public void Execute(int index)
        {
            _model.RemoveShapeByIndex(index);
        }

        // unexecute command
        public void UnExecute()
        {
            _model.AddShape(_shape);
        }

        // unexecute command with index
        public void UnExecute(int index)
        {
            _model.AddShapeByIndex(index, _shape);
        }
    }
}