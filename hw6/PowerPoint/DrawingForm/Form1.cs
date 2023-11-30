using DrawingModel;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace DrawingForm
{
    public partial class Form1 : Form
    {
        private DoubleBufferedPanel _panel;
        private ToolStrip _toolStripTop;
        private ToolStripBindableButton _toolStripButtonLine;
        private ToolStripBindableButton _toolStripButtonRectangle;
        private ToolStripBindableButton _toolStripButtonEllipse;
        private ToolStripBindableButton _toolStripButtonIdle;
        private Model _model;
        private FormPresentationModel _presentationModel;
        private Bitmap _brief;
        
        private BindingManagerBase _BindingManager
        {
            get
            {
                return BindingContext[_model.Shapes.ShapeList];
            }
        }

        public Form1(FormPresentationModel presentationModel)
        {
            InitializeComponent();
            InitializeModelInfo();
            _panel.BackColor = Color.LightYellow;
            _panel.MouseDown += HandleCanvasPressed;
            _panel.MouseUp += HandleCanvasReleased;
            _panel.MouseMove += HandleCanvasMoved;
            _panel.Paint += HandleCanvasPaint;
            Controls.Add(_panel);
            
            _model = presentationModel.Model;
            _presentationModel = presentationModel;
            _presentationModel.Panel = _panel;
            
            _model._modelChanged += HandleModelChanged;
            _toolStripButtonLine.DataBindings.Add(Constant.CHECKED, _presentationModel, Constant.IS_LINE_ENABLE);
            _toolStripButtonRectangle.DataBindings.Add(Constant.CHECKED, _presentationModel, Constant.IS_RECTANGLE_ENABLE);
            _toolStripButtonEllipse.DataBindings.Add(Constant.CHECKED, _presentationModel, Constant.IS_ELLIPSE_ENABLE);
            _toolStripButtonIdle.DataBindings.Add(Constant.CHECKED, _presentationModel, Constant.IS_IDLE_ENABLE);
            _modelInfo.DataSource = _model.Shapes.ShapeList;
            _brief = new Bitmap(_panel.Width, _panel.Height);
            KeyPreview = true;
            KeyDown += HandleKeyDown; 
        }

        // init model info
        private void InitializeModelInfo()
        {
            DataGridViewButtonColumn columnButton = new DataGridViewButtonColumn();
            columnButton.HeaderText = Constant.DELETE;
            columnButton.Text = Constant.DELETE;
            columnButton.UseColumnTextForButtonValue = true;
            _modelInfo.Columns.Insert(0, columnButton);
            _modelInfo.CellContentClick += ModelInfoCellClick;
        }

        // generate brief
        private void GenerateBrief()
        {
            _panel.DrawToBitmap(_brief, new System.Drawing.Rectangle(Constant.ZERO_INTEGER, Constant.ZERO_INTEGER, _panel.Width, _panel.Height));
            _slideButton.Image = new Bitmap(_brief, _slideButton.Size);
        }

        // handle canvas pressed
        public void HandleCanvasPressed(object sender, MouseEventArgs e)
        {
            _presentationModel.HandleCanvasPressed(e.X, e.Y);
        }

        // handle canvas released
        public void HandleCanvasReleased(object sender, MouseEventArgs e)
        {
            _presentationModel.HandleCanvasReleased(e.X, e.Y);
        }

        // handle canvas moved
        public void HandleCanvasMoved(object sender, MouseEventArgs e)
        {
            _presentationModel.HandleCanvasMoved(e.X, e.Y);
        }

        // handle canvas paint
        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        // handle model changed
        public void HandleModelChanged(EventArgs e)
        {
            Invalidate(true);
            GenerateBrief();
            _presentationModel.HandleStateChanged();
        }

        // handle add shape button click
        private void ProcessAddShapeButton(object sender, EventArgs e)
        {
            _presentationModel.ProcessAddShapeButton(sender, e, _shapeOption);
        }

        // handle Line button click
        private void ProcessLineBotton(object sender, EventArgs e)
        {
            _presentationModel.ProcessLineBotton(sender, e);
            _presentationModel.HandleStateChanged();
        }

        // handle Rectangle button click
        private void ProcessRectangleButton(object sender, EventArgs e)
        {
            _presentationModel.ProcessRectangleButton(sender, e);
            _presentationModel.HandleStateChanged();

        }

        // handle Ellipse button click
        private void ProcessEllispeButton(object sender, EventArgs e)
        {
            _presentationModel.ProcessEllispeButton(sender, e);
            _presentationModel.HandleStateChanged();
        }

        // handle Idle button click
        private void ProcessCursorButton(object sender, EventArgs e)
        {
            _presentationModel.ProcessCursorButton(sender, e);
            _presentationModel.HandleStateChanged();
        }

        // model info cell click
        private void ModelInfoCellClick(object sender, DataGridViewCellEventArgs e)
        {
            _model.RemoveShape(_BindingManager.Position);
            _model.NotifyModelChanged();
        }

        // hangle key down
        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            _presentationModel.HandleKeyDown(e.KeyCode);
        }
    }
}