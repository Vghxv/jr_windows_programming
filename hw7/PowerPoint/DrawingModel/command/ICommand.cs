namespace DrawingModel
{
    public interface ICommand
    {
        // execute
        void Execute();

        // unexecute
        void ReverseExecute();
    }
}
