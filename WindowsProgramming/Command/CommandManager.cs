using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPractice.Command
{
    public class CommandManager
    {
        Stack<ICommand> _undo = new Stack<ICommand>();
        Stack<ICommand> _redo = new Stack<ICommand>();

        // do
        public void Execute(ICommand command)
        {
            command.Execute();
            _undo.Push(command);// push command 進 undo stack
            _redo.Clear();// 清除redo stack
        }

        // undo
        public void Undo()
        {
            ICommand command = _undo.Pop();
            _redo.Push(command);
            command.CancelExecute();
        }

        // redo
        public void Redo()
        {
            ICommand command = _redo.Pop();
            _undo.Push(command);
            command.Execute();
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _redo.Count != 0;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _undo.Count != 0;
            }
        }
    }
}
