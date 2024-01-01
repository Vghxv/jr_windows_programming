namespace DrawingModel
{
    public class DeleteCommand : ICommand
    {
        private Model _model;
        private Shape _shape;

        public DeleteCommand(Model model, Shape shape)
        {
            _model = model;
            _shape = shape;
        }

        // execute command
        public void Execute()
        {
            _shape.IsSelected = false;
            _model.RemoveShape(_shape);
        }

        // unexecute command
        public void ReverseExecute()
        {
            _model.AddShape(_shape);
        }
    }
}