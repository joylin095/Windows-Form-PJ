using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPractice.Command
{
    public class DeletePageCommand : ICommand
    {
        Model _model;
        Shapes _shapes;
        int _pageIndex;
        public DeletePageCommand(Model model, Shapes shapes, int pageIndex)
        {
            _model = model;
            _shapes = shapes;
            _pageIndex = pageIndex;
        }

        // do
        public void Execute()
        {
            _model.DeletePage(_pageIndex);
            _model.HandleDeletePage(_pageIndex);
        }

        // undo
        public void CancelExecute()
        {
            _model.InsertPage(_pageIndex, _shapes);
            _model.HandleAddPage();
            
        }
    }
}
