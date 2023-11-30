using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace DrawingModel
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
        public bool IsDrawing
        {
            get 
            {
                return IsLineEnable || IsRectangleEnable || IsEllipseEnable;
            }
        }
        public DoubleBufferedPanel Panel
        {
            get
            {
                return _panel;
            }
            set
            {
                _panel = value;
            }
        }

        // notify tool strip buttons
        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // notify all tool strip buttons
        public void NotifyAllProperties()
        {
            Notify(nameof(IsLineEnable));
            Notify(nameof(IsRectangleEnable));
            Notify(nameof(IsEllipseEnable));
            Notify(nameof(IsIdleEnable));
        }

        // constructor
        public FormPresentationModel(Model model)
        {
            _model = model;
        }

        public Model Model 
        {
            get
            {
                return _model;
            }
        }

        // hangle change cursor
        public void HandleStateChanged()
        {
            if (_model.IsCloseToAdjust)
            {
                _panel.Cursor = Cursors.SizeNWSE;
            }
            else if (_model.CurrentState is DrawingState)
            {
                _panel.Cursor = Cursors.Cross;
            }
            else
            {
                _panel.Cursor = Cursors.Default;
            }
        }

        // draw
        public void Draw(Graphics graphics)
        {
            _model.Draw(new FormsGraphicsAdaptor(graphics));
        }
        
        // handle canvas pressed
        public void HandleCanvasPressed(float number1, float number2)
        {
            _model.HandleCanvasPressed(number1, number2);
        }

        // handle canvas moved
        public void HandleCanvasMoved(float number1, float number2)
        {            
            _model.HandleCanvasMoved(number1, number2);
        }

        // handle canvas released
        public void HandleCanvasReleased(float number1, float number2)
        {
            if (IsDrawing)
            {
                IsEllipseEnable = false;
                IsLineEnable = false;
                IsRectangleEnable = false;
                IsIdleEnable = true;
                NotifyAllProperties();
            }
            _model.HandleCanvasReleased(number1, number2);
        }
        
        // get shape name to add
        public string GetShapeNameToAdd(string shapeName)
        {
            switch (shapeName)
            {
                case Constant.LINE_CHINESE:
                    return Constant.ASSEMBLY + Constant.LINE;
                case Constant.RECTANGLE_CHINESE:
                    return Constant.ASSEMBLY + Constant.RECTANGLE;
                case Constant.ELLIPSE_CHINESE:
                    return Constant.ASSEMBLY + Constant.ELLIPSE;
                default:
                    return string.Empty;
            }
        }

        // press add shape button
        public void ProcessAddShapeButton(object sender, EventArgs e, ComboBox shapeOption)
        {
            string shapeToAdd = GetShapeNameToAdd(shapeOption.Text);
            
            if (string.IsNullOrEmpty(shapeToAdd))
            {
                return;
            }
            _model.AddShape(shapeToAdd);
            _model.NotifyModelChanged();
        }

        // press line button
        public void ProcessLineBotton(object sender, EventArgs e)
        {
            _model.SetHint(ShapeFactory.CreateShape(Constant.ASSEMBLY + Constant.LINE));
            _model.CurrentState = new DrawingState(_model);
            _model.SetShapeSelected(false);
            _model.NotifyModelChanged();
            IsLineEnable = true;
            IsRectangleEnable = IsEllipseEnable = IsIdleEnable = false;
            NotifyAllProperties();
        }

        // press rectangle button
        public void ProcessRectangleButton(object sender, EventArgs e)
        {
            IsRectangleEnable = true;
            IsLineEnable = IsEllipseEnable = IsIdleEnable = false;
            _model.SetHint(ShapeFactory.CreateShape(Constant.ASSEMBLY + Constant.RECTANGLE));
            _model.CurrentState = new DrawingState(_model);
            _model.SetShapeSelected(false);
            _model.NotifyModelChanged();
            NotifyAllProperties();
        }

        // press ellipse button
        public void ProcessEllispeButton(object sender, EventArgs e)
        {
            _model.SetHint(ShapeFactory.CreateShape(Constant.ASSEMBLY + Constant.ELLIPSE));
            _model.CurrentState = new DrawingState(_model);
            _model.SetShapeSelected(false);
            _model.NotifyModelChanged();
            IsLineEnable = IsEllipseEnable = IsIdleEnable = false;
            IsEllipseEnable = true;
            NotifyAllProperties();
        }

        // press cursor button
        public void ProcessCursorButton(object sender, EventArgs e)
        {
            _model.CurrentState = new IdleState(_model);
            _model.SetShapeSelected(false);
            _model.NotifyModelChanged();
            IsLineEnable = IsRectangleEnable = IsEllipseEnable = false;
            IsIdleEnable = true;
            NotifyAllProperties();
        }

        // handle key down
        public void HandleKeyDown(Keys keys)
        {
            _model.HandleKeyDown(keys);
        }
    }
}