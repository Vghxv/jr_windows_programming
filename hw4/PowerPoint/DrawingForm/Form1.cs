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
        private ToolStripBindableButton _toolStripButtonSelect;
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
                return BindingContext[_model.ShapesManager.ShapeList];
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
            
            _model = presentationModel.GetModel();
            _presentationModel = presentationModel;
            _presentationModel.SetPanel(_panel);
            
            _model._modelChanged += HandleModelChanged;
            _toolStripButtonLine.DataBindings.Add(Constant.CHECKED, _presentationModel, Constant.IS_LINE_ENABLE);
            _toolStripButtonRectangle.DataBindings.Add(Constant.CHECKED, _presentationModel, Constant.IS_LINE_ENABLE);
            _toolStripButtonEllipse.DataBindings.Add(Constant.CHECKED, _presentationModel, Constant.IS_ELLIPSE_ENABLE);
            _toolStripButtonIdle.DataBindings.Add(Constant.CHECKED, _presentationModel, Constant.IS_IDLE_ENABLE);
            _toolStripButtonSelect.DataBindings.Add(Constant.CHECKED, _presentationModel, Constant.IS_SELECT_ENABLE);
            _modelInfo.DataSource = _model.ShapesManager.ShapeList;
            _brief = new Bitmap(_panel.Width, _panel.Height);
            KeyPreview = true;
            KeyDown += HandleKeyDown; 
        }

        //sd
        private void InitializeModelInfo()
        {
            DataGridViewButtonColumn columnButton = new DataGridViewButtonColumn();
            columnButton.HeaderText = Constant.DELETE;
            columnButton.Text = Constant.DELETE;
            columnButton.UseColumnTextForButtonValue = true;
            _modelInfo.Columns.Insert(0, columnButton);
            _modelInfo.CellContentClick += ModelInfoCellDeleteClick;
        }

        // generate thumbnails
        private void GenerateBrief()
        {
            _panel.DrawToBitmap(_brief, new System.Drawing.Rectangle(Constant.ZERO_INTEGER, Constant.ZERO_INTEGER, _panel.Width, _panel.Height));
            _slideButton.Image = new Bitmap(_brief, _slideButton.Size);
        }

        // asd
        public void HandleCanvasPressed(object sender, MouseEventArgs e)
        {
            _presentationModel.GoPointerPressed(e.X, e.Y);
        }

        // asd
        public void HandleCanvasReleased(object sender, MouseEventArgs e)
        {
            _presentationModel.GoPointerReleased(e.X, e.Y);
        }

        // asd
        public void HandleCanvasMoved(object sender, MouseEventArgs e)
        {
            _presentationModel.GoPointerMoved(e.X, e.Y);
        }

        //asd 
        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        //asd
        public void HandleModelChanged(object sender, EventArgs e)
        {
            Invalidate(true);
            GenerateBrief();
            _presentationModel.HandleStateChanged();
        }

        // asd
        private void ButtonAddClick(object sender, EventArgs e)
        {
            _presentationModel.ButtonAddClick(sender, e, _shapeOption);
        }

        // asd
        private void ToolStripButtonLine(object sender, EventArgs e)
        {
            _presentationModel.GoToolStripButtonLine(sender, e);
        }

        // asd
        private void ToolStripButtonRectangle(object sender, EventArgs e)
        {
            _presentationModel.GoToolStripButtonRectangle(sender, e);
        }

        // asd
        private void ToolStripButtonEllipse(object sender, EventArgs e)
        {
            _presentationModel.GoToolStripButtonEllipse(sender, e);
        }

        // asd
        private void ToolStripButtonIdle(object sender, EventArgs e)
        {
            _presentationModel.GoToolStripButtonIdle(sender, e);
        }

        // asd
        private void ModelInfoCellDeleteClick(object sender, DataGridViewCellEventArgs e)
        {
            _presentationModel.DeleteRowFromDataGridView(sender, e, _BindingManager);
        }

        // asd
        private void ToolStripButtonSelectClick(object sender, EventArgs e)
        {
            _presentationModel.GoToolStripButtonSelect(sender, e);
        }

        // asd
        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            _presentationModel.HandleKeyDown(e.KeyCode);
        }
    }
}