using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsPractice;

namespace WindowsPractice.Command
{
    public class DeleteCommand : ICommand
    {
        Model _model;
        Dictionary<Shape, int> _deleteShapeList = new Dictionary<Shape, int>();
        int _pageIndex;
        public DeleteCommand(Model model, Dictionary<Shape, int> deleteShapeList, int pageIndex)
        {
            _model = model;
            _deleteShapeList = deleteShapeList;
            _pageIndex = pageIndex;
        }

        // do
        public void Execute()
        {
            int counts = 0;
            _model.SetCurrentPage(_pageIndex);
            foreach (KeyValuePair<Shape, int> deleteShape in _deleteShapeList)
            {
                _model.DeleteData(deleteShape.Value - counts);
                counts += 1;
            }
        }

        // undo
        public void CancelExecute()
        {
            _model.SetCurrentPage(_pageIndex);
            foreach (KeyValuePair<Shape, int> deleteShape in _deleteShapeList)
            {
                _model.AddShape(deleteShape.Key, deleteShape.Value);
            }
        }
    }
}
