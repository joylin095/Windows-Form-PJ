using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsPractice;

namespace WindowsPractice.Command
{
    class DeleteCommand : ICommand
    {
        Model _model;
        Dictionary<Shape, int> _deleteShapeList = new Dictionary<Shape, int>();
        public DeleteCommand(Model model, Dictionary<Shape, int> deleteShapeList)
        {
            _model = model;
            _deleteShapeList = deleteShapeList;
        }

        // do
        public void Execute()
        {
            int counts = 0;
            foreach (KeyValuePair<Shape, int> deleteShape in _deleteShapeList)
            {
                _model.DeleteData(deleteShape.Value - counts);
                counts += 1;
            }
        }

        // undo
        public void CancelExecute()
        {
            foreach (KeyValuePair<Shape, int> deleteShape in _deleteShapeList)
            {
                _model.AddShape(deleteShape.Key, deleteShape.Value);
            }
        }
    }
}
