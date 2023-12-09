using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsPractice;

namespace WindowsPractice.Command
{
    class AddCommand : ICommand
    {
        Model _model;
        Shape _shape;
        public AddCommand(Model model, Shape shape)
        {
            _model = model;
            _shape = shape;
        }

        // do
        public void Execute()
        {
            _model.AddShape(_shape);
        }

        // undo
        public void CancelExecute()
        {
            _model.DeleteData(_model.BindingShapeList.Count - 1);
        }
    }
}
