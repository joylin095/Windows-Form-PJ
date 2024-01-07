using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsPractice;

namespace WindowsPractice.Command
{
    public class MoveCommand : ICommand
    {
        Model _model;
        Dictionary<int, (Point X1Y1, Point WidthHeight)> _beforeMove;
        Dictionary<int, (Point X1Y1, Point WidthHeight)> _afterMove;
        int _pageIndex;
        public MoveCommand(Model model, Dictionary<int, (Point X1Y1, Point WidthHeight)> beforeMove, Dictionary<int, (Point X1Y1, Point WidthHeight)> afterMove, int pageIndex)
        {
            _model = model;
            _beforeMove = beforeMove;
            _afterMove = afterMove;
            _pageIndex = pageIndex;
        }

        // do
        public void Execute()
        {
            _model.SetCurrentPage(_pageIndex);
            foreach (KeyValuePair<int, (Point X1Y1, Point WidthHeight)> afterMoveShape in _afterMove)
            {
                _model.SetDirectly(afterMoveShape.Value.X1Y1, afterMoveShape.Value.WidthHeight, afterMoveShape.Key);
            }
        }

        // undo
        public void CancelExecute()
        {
            _model.SetCurrentPage(_pageIndex);
            foreach (KeyValuePair<int, (Point X1Y1, Point WidthHeight)> brforeMoveShape in _beforeMove)
            {
                _model.SetDirectly(brforeMoveShape.Value.X1Y1, brforeMoveShape.Value.WidthHeight, brforeMoveShape.Key);
            }
        }
    }
}
