using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework2
{
    public class ToolStripBindButton : ToolStripButton, IBindableComponent
    {
        private ControlBindingsCollection _dataBindings;

        private BindingContext _bindingContext;

        public ControlBindingsCollection DataBindings
        {
            get
            {
                if (_dataBindings == null)
                {
                    _dataBindings = new ControlBindingsCollection(this);
                }
                return _dataBindings;
            }
        }

        public BindingContext BindingContext
        {
            get
            {
                if (_bindingContext == null)
                {
                    _bindingContext = new BindingContext();
                }
                return _bindingContext;
            }
            set
            {
                _bindingContext = value;
            }
        }
    }
}
