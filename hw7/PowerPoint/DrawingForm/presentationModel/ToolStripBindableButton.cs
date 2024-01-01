using System.Windows.Forms;
namespace DrawingForm
{
    public class ToolStripBindableButton : ToolStripButton, IBindableComponent
    {
        private ControlBindingsCollection _dataBindings;
        private BindingContext _bindingContext;

        // asd
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

        //asd
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