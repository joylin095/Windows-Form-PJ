using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsPractice;

namespace WindowsPractice.Command
{
    class MoveCommand : ICommand
    {
        Model _model;
        Dictionary<(Point X1Y1, Point WidthHeight), int> _beforeMove;
        Dictionary<(Point X1Y1, Point WidthHeight), int> _afterMove;
        public MoveCommand(Model model, Dictionary<(Point X1Y1, Point WidthHeight), int> beforeMove, Dictionary<(Point X1Y1, Point WidthHeight), int> afterMove)
        {
            _model = model;
            _beforeMove = beforeMove;
            _afterMove = afterMove;
        }

        // do
        public void Execute()
        {
            foreach (KeyValuePair<(Point X1Y1, Point WidthHeight), int> afterMoveShape in _afterMove)
            {
                _model.SetDirectly(afterMoveShape.Key.X1Y1, afterMoveShape.Key.WidthHeight, afterMoveShape.Value);
            }
        }

        // undo
        public void CancelExecute()
        {
            foreach (KeyValuePair<(Point X1Y1, Point WidthHeight), int> brforeMoveShape in _beforeMove)
            {
                _model.SetDirectly(brforeMoveShape.Key.X1Y1, brforeMoveShape.Key.WidthHeight, brforeMoveShape.Value);
            }
        }
    }
}
