using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPractice.Command
{
    public class AddPageCommand : ICommand
    {
        Model _model;
        int _pageIndex;
        public AddPageCommand(Model model, int pageIndex)
        {
            _model = model;
            _pageIndex = pageIndex;
        }

        // do
        public void Execute()
        {
            _model.HandleAddPage(_pageIndex);
            _model.CreateNewPage(_pageIndex);
        }

        // undo
        public void CancelExecute()
        {
            _model.HandleDeletePage(_pageIndex);
            _model.DeletePage(_pageIndex);
        }
    }
}
