using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using DrawingModel;
namespace DrawingForm
{
    public class FormPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Model _model;
        private DoubleBufferedPanel _doubleBufferPanel;
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
        public DoubleBufferedPanel DoubleBufferPanel
        {
            get
            {
                return _doubleBufferPanel;
            }
            set
            {
                _doubleBufferPanel = value;
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
                _doubleBufferPanel.Cursor = Cursors.SizeNWSE;
            }
            else if (_model.CurrentState is DrawingState)
            {
                _doubleBufferPanel.Cursor = Cursors.Cross;
            }
            else
            {
                _doubleBufferPanel.Cursor = Cursors.Default;
            }
        }

        // handle _model changed
        public void ModelInfoCellClick(int position, int index)
        {
            if (index == 0)
            {
                _model.CommandManager.Execute(new DeleteCommand(_model, _model.Shapes.ShapeList[position]));
                _model.NotifyModelChanged();
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
        
        // get _shape name to add
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

        // press add _shape button
        public void ProcessAddShapeButton(ComboBox shapeOption, Size size)
        {
            string shapeToAdd = GetShapeNameToAdd(shapeOption.Text);
            if (string.IsNullOrEmpty(shapeToAdd) || (size.Width == 0 && size.Height == 0))
            {
                MessageBox.Show("choose shape first!");
                return;
            }
            using (var newDialog = new CoordinateForm())
            {
                newDialog.StartPosition = FormStartPosition.CenterParent;
                var result = newDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //var pairs = _model.GenerateTwoPairs(size);
                    if(
                        float.TryParse(newDialog.Input1, out float floatValue1) &&
                        float.TryParse(newDialog.Input2, out float floatValue2) &&
                        float.TryParse(newDialog.Input3, out float floatValue3) &&
                        float.TryParse(newDialog.Input4, out float floatValue4))
                    {
                        Shape shape = ShapeFactory.CreateShape(shapeToAdd, new Pair(floatValue1, floatValue2), 
                            new Pair(floatValue3, floatValue4));
                        _model.CommandManager.Execute(new AddCommand(_model, shape));
                        _model.NotifyModelChanged();
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid numbers");
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                }
            }
        }

        // press line button
        public void ProcessLineButton()
        {
            _model.CurrentState = new DrawingState(_model, ShapeFactory.CreateShape(Constant.ASSEMBLY + Constant.LINE));
            _model.SetShapeSelected(false);
            _model.NotifyModelChanged();
            IsLineEnable = true;
            IsRectangleEnable = IsEllipseEnable = IsIdleEnable = false;
            NotifyAllProperties();
        }

        // press rectangle button
        public void ProcessRectangleButton()
        {
            IsRectangleEnable = true;
            IsLineEnable = IsEllipseEnable = IsIdleEnable = false;
            _model.CurrentState = new DrawingState(_model, ShapeFactory.CreateShape(Constant.ASSEMBLY + Constant.RECTANGLE));
            _model.SetShapeSelected(false);
            _model.NotifyModelChanged();
            NotifyAllProperties();
        }

        // press ellipse button
        public void ProcessEllipseButton()
        {
            _model.CurrentState = new DrawingState(_model, ShapeFactory.CreateShape(Constant.ASSEMBLY + Constant.ELLIPSE));
            _model.SetShapeSelected(false);
            _model.NotifyModelChanged();
            IsLineEnable = IsRectangleEnable = IsIdleEnable = false;
            IsEllipseEnable = true;
            NotifyAllProperties();
        }

        // press cursor button
        public void ProcessCursorButton()
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

        // add slide button
        public void AddSlideButton(FlowLayoutPanel slideInfo)
        {
            int targetWidth = slideInfo.Width - Constant.SPLITTER_OFFSET;
            int targetHeight = targetWidth / Constant.ASPECT_RATIO_X * Constant.ASPECT_RATIO_Y;
            Button slideButton = new Button();
            slideButton.BackColor = SystemColors.ControlLightLight;
            slideButton.Location = new Point(0, 0);
            slideButton.Margin = new Padding(Constant.SLIDE_BUTTON_MARGIN);
            slideButton.Name = Constant.SLIDE_BUTTON;
            slideButton.Size = new Size(targetWidth, targetHeight);
            slideButton.TabIndex = 0;
            slideButton.UseVisualStyleBackColor = false;
            slideInfo.Controls.Add(slideButton);
        }

        // delete slide button
        public void DeleteSlideButton(FlowLayoutPanel slideInfo)
        {
            slideInfo.Controls.Clear();
        }

        // handle Button resize
        public void HandleButtonResize(FlowLayoutPanel slideInfo)
        {
            int targetWidth = slideInfo.Width - Constant.SPLITTER_OFFSET;
            int targetHeight = targetWidth / Constant.ASPECT_RATIO_X * Constant.ASPECT_RATIO_Y;
            foreach (Control control in slideInfo.Controls)
            {
                control.Size = new Size(targetWidth, targetHeight);
            }
        }

        // handle Canvas resize
        public void HandleCanvasResize(DoubleBufferedPanel doubleBufferPanel, Size regionSize)
        {
            if (((float)regionSize.Width / regionSize.Height) < ((float)Constant.ASPECT_RATIO_X / Constant.ASPECT_RATIO_Y))
            {
                int targetWidth = regionSize.Width - Constant.SPLITTER_OFFSET;
                int targetHeight = targetWidth / Constant.ASPECT_RATIO_X * Constant.ASPECT_RATIO_Y;
                doubleBufferPanel.Size = new Size(targetWidth, targetHeight);
                doubleBufferPanel.Location = new Point(0, (regionSize.Height - targetHeight) >> 1);
            }
            else
            {
                int targetHeight = regionSize.Height;
                int targetWidth = targetHeight / Constant.ASPECT_RATIO_Y * Constant.ASPECT_RATIO_X;
                doubleBufferPanel.Size = new Size(targetWidth, targetHeight);
                doubleBufferPanel.Location = new Point((regionSize.Width - targetWidth) >> 1, 0);
            }
        }
    }
}