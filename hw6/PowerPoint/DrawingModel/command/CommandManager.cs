using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrawingModel
{
    public class CommandManager
    {
        Stack<ICommand> _undo = new Stack<ICommand>();
        Stack<ICommand> _redo = new Stack<ICommand>();

        // execute
        public void Execute(ICommand command)
        {
            command.Execute();
            _undo.Push(command);
            _redo.Clear();
        }

        // undo execute
        public void Undo()
        {
            if (_undo.Count > 0)
            {
                ICommand command = _undo.Pop();
                _redo.Push(command);
                command.ReverseExecute();
            }
        }

        // redo execute
        public void Redo()
        {
            if (_redo.Count > 0)
            {
                ICommand command = _redo.Pop();
                _undo.Push(command);
                command.Execute();
            }
        }
    }
}
