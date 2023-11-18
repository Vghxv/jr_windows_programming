using System;
using System.ComponentModel;
using System.Drawing;
using DrawingModel; 
using System.Windows.Forms;
using WindowPowerPoint;

namespace DrawingForm
{
    public class FormPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Model _model;
        private DoubleBufferedPanel _panel;
        public bool IsLineEnable
        {
            get; set;
        }
        public bool IsRectangleEnable
        {
            get; set;
        }
        public bool IsEllipseEnable
        {
            get; set;
        }
        public bool IsIdleEnable
        {
            get; set;
        }
        public bool IsSelectEnable
        {
            get; set;
        }

        // asd
        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //asd
        private void NotifyAllProperties()
        {
            Notify(nameof(IsLineEnable));
            Notify(nameof(IsRectangleEnable));
            Notify(nameof(IsEllipseEnable));
            Notify(nameof(IsIdleEnable));
            Notify(nameof(IsSelectEnable));
        }

        //asd
        public FormPresentationModel(Model model)
        {
            _model = model;

        }

        // asd
        public void SetPanel(DoubleBufferedPanel panel)
        {
            _panel = panel;
        }

        // asd
        public Model GetModel() 
        {
            return _model;
        }

        // asd
        public void HandleStateChanged()
        {
            ModelState modelState = _model.GetState();
            if (modelState is DrawingState)
            {
                _panel.Cursor = Cursors.Cross;
            }
            else if (modelState is SelectingState)
            {
                _panel.Cursor = Cursors.SizeAll;
            }
            else
            {
                _panel.Cursor = Cursors.Default;
            }
        }

        // asd
        public void Draw(Graphics graphics)
        {
            _model.Draw(new FormsGraphicsAdaptor(graphics));
        }
        
        // asd
        public void GoPointerPressed(float number1, float number2)
        {
            _model.GoPointerPressed(number1, number2);
        }

        // asd
        public void GoPointerMoved(float number1, float number2)
        {            
            _model.GoPointerMoved(number1, number2);
        }

        // asd
        public void GoPointerReleased(float number1, float number2)
        {
            if (_model.GetState() is DrawingState)
            {
                IsEllipseEnable = false;
                IsLineEnable = false;
                IsRectangleEnable = false;
                IsIdleEnable = true;
                IsSelectEnable = false;
                NotifyAllProperties();
            }
            _model.GoPointerReleased(number1, number2);
        }
        
        // asd
        private string GetShapeNameToAdd(string shapeName)
        {
            switch (shapeName)
            {
                case DrawingModel.Constant.LINE_CHINESE:
                    return Constant.ASSEMBLY + Constant.LINE;
                case DrawingModel.Constant.RECTANGLE_CHINESE:
                    return Constant.ASSEMBLY + Constant.RECTANGLE;
                case DrawingModel.Constant.ELLIPSE_CHINESE:
                    return Constant.ASSEMBLY + Constant.ELLIPSE;
                default:
                    return string.Empty;
            }
        }

        // asd
        public void ButtonAddClick(object sender, EventArgs e, ComboBox shapeOption)
        {
            string shapeToAdd = GetShapeNameToAdd(shapeOption.Text);
            
            if (string.IsNullOrEmpty(shapeToAdd))
            {
                MessageBox.Show(Constant.MESSAGE);
                return;
            }
            _model.AddShape(shapeToAdd);
        }

        // asd
        public void GoToolStripButtonLine(object sender, EventArgs e)
        {
            _model.SetHint(Constant.ASSEMBLY + Constant.LINE);
            _model.SetState(new DrawingState(_model));
            IsLineEnable = true;
            IsRectangleEnable = false;
            IsEllipseEnable = false;
            IsIdleEnable = false;
            IsSelectEnable = false;
            NotifyAllProperties();
        }

        //asd
        public void GoToolStripButtonRectangle(object sender, EventArgs e)
        {
            IsLineEnable = false;
            IsRectangleEnable = true;
            IsEllipseEnable = false;
            IsIdleEnable = false;
            IsSelectEnable = false;
            _model.SetHint(Constant.ASSEMBLY + Constant.RECTANGLE);
            _model.SetState(new DrawingState(_model));
            NotifyAllProperties();
        }

        //a dasd
        public void GoToolStripButtonEllipse(object sender, EventArgs e)
        {
            IsLineEnable = false;
            IsRectangleEnable = false;
            IsEllipseEnable = true;
            IsIdleEnable = false;
            IsSelectEnable = false;
            _model.SetHint(Constant.ASSEMBLY + Constant.ELLIPSE);
            _model.SetState(new DrawingState(_model));
            NotifyAllProperties();
        }

        // asd
        public void GoToolStripButtonIdle(object sender, EventArgs e)
        {
            _model.SetState(new IdleState(_model));
            IsLineEnable = false;
            IsRectangleEnable = false;
            IsEllipseEnable = false;
            IsIdleEnable = true;
            IsSelectEnable = false;
            NotifyAllProperties();
        }

        // asd
        public void GoToolStripButtonSelect(object sender, EventArgs e)
        {
            _model.SetState(new SelectingState(_model));
            IsLineEnable = false;
            IsRectangleEnable = false;
            IsEllipseEnable = false;
            IsIdleEnable = false;
            IsSelectEnable = true;
            NotifyAllProperties();
        }

        // asd
        public void DeleteRowFromDataGridView(object sender, DataGridViewCellEventArgs e, BindingManagerBase bindingManagerBase)
        {
            _model.RemoveShape(bindingManagerBase.Position);
        }

        // asd
        public void HandleKeyDown(Keys keys)
        {
            _model.HandleKeyDown(keys);
        }
    }
}