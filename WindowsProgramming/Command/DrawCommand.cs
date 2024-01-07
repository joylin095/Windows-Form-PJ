using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsPractice;

namespace WindowsPractice.Command
{
    public class DrawCommand : ICommand
    {
        Model _model;
        Shape _shape;
        int _pageIndex;
        public DrawCommand(Model model, Shape shape, int pageIndex)
        {
            _model = model;
            _shape = shape;
            _pageIndex = pageIndex;
        }

        // do
        public void Execute()
        {
            _model.SetCurrentPage(_pageIndex);
            _model.AddShape(_shape);  
        }

        // undo
        public void CancelExecute()
        {
            _model.SetCurrentPage(_pageIndex);
            _model.DeleteData(_model.BindingShapeList.Count - 1);
        }
    }
}
