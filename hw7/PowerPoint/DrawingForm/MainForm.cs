using DrawingModel;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace DrawingForm
{
    public partial class MainForm : Form
    {
        private ToolStrip _toolStripTop;
        private ToolStripBindableButton _toolStripButtonLine;
        private ToolStripBindableButton _toolStripButtonRectangle;
        private ToolStripBindableButton _toolStripButtonEllipse;
        private ToolStripBindableButton _toolStripButtonIdle;
        private DoubleBufferedPanel _doubleBufferPanel;
        private Bitmap _brief;
        private readonly Model _model;
        private readonly FormPresentationModel _presentationModel;
        
        private BindingManagerBase BindingManager
        {
            get
            {
                return BindingContext[_model.GetCurrentPageShapes()];
            }
        }

        public MainForm(FormPresentationModel presentationModel)
        {
            InitializeComponent();
            InitializeModelInfo();
            _presentationModel = presentationModel;
            _model = presentationModel.Model;
            _model._modelChanged += HandleModelChanged;
            _model._pageChanged += HandlePageChanged;
            _toolStripButtonLine.DataBindings.Add(Constant.CHECKED, _presentationModel, Constant.IS_LINE_ENABLE);
            _toolStripButtonRectangle.DataBindings.Add(Constant.CHECKED, _presentationModel, Constant.IS_RECTANGLE_ENABLE);
            _toolStripButtonEllipse.DataBindings.Add(Constant.CHECKED, _presentationModel, Constant.IS_ELLIPSE_ENABLE);
            _toolStripButtonIdle.DataBindings.Add(Constant.CHECKED, _presentationModel, Constant.IS_IDLE_ENABLE);
            _modelInfo.DataSource = _model.GetCurrentPageShapes();
            KeyPreview = true;
            KeyDown += HandleKeyDown;
            Resize += HandleResizeForm;
            _mainSplitContainer.SplitterMoved += MoveLeftSplitter;
            _subSplitContainer.SplitterMoved += MoveRightSplitter;
            InitializeCanvas();
            _presentationModel.AddSlideButton(_slideInfo);
            HandleResizeForm(new object(), EventArgs.Empty);    
        }

        // initialize canva
        public void InitializeCanvas()
        {
            _doubleBufferPanel = new DoubleBufferedPanel();
            _doubleBufferPanel.Name = Constant.CANVA_PANEL;
            _canvaPanelRegion.Controls.Add(_doubleBufferPanel);
            _doubleBufferPanel.BackColor = SystemColors.ControlLightLight;
            _doubleBufferPanel.Size = new Size(Constant.CANVA_PANEL_WIDTH, Constant.CANVA_PANEL_HEIGHT);
            _doubleBufferPanel.Location = new Point((_canvaPanelRegion.Height - _doubleBufferPanel.Height) >> 1, 0);
            _doubleBufferPanel.Margin = new Padding(Constant.CANVA_PANEL_MARGIN);
            _doubleBufferPanel.MouseDown += HandleCanvasPressed;
            _doubleBufferPanel.MouseUp += HandleCanvasReleased;
            _doubleBufferPanel.MouseMove += HandleCanvasMoved;
            _doubleBufferPanel.Paint += HandleCanvasPaint;
            _presentationModel.DoubleBufferPanel = _doubleBufferPanel;
            _brief = new Bitmap(_doubleBufferPanel.Width, _doubleBufferPanel.Height);
        }

        // hangle Left Splitter
        public void MoveLeftSplitter(object sender, EventArgs e)
        {
            Size original = _doubleBufferPanel.Size;
            _presentationModel.HandleButtonResize(_slideInfo);
            _presentationModel.HandleCanvasResize(_doubleBufferPanel, _canvaPanelRegion.Size);
            _model.ResizeShapes(original, _doubleBufferPanel.Size);
            Invalidate(true);
            DrawCanvaPanelToButton();
        }

        // hangle Right Splitter
        public void MoveRightSplitter(object sender, EventArgs e)
        {
            Size original = _doubleBufferPanel.Size;
            _presentationModel.HandleCanvasResize(_doubleBufferPanel, _canvaPanelRegion.Size);
            _model.ResizeShapes(original, _doubleBufferPanel.Size);
            Invalidate(true);
            DrawCanvaPanelToButton();
        }

        // handle resize
        public void HandleResizeForm(object sender, EventArgs e)
        {
            Size original = _doubleBufferPanel.Size;
            _presentationModel.HandleButtonResize(_slideInfo);
            _presentationModel.HandleCanvasResize(_doubleBufferPanel, _canvaPanelRegion.Size);
            _model.ResizeShapes(original, _doubleBufferPanel.Size);
            Invalidate(true);
        }

        // init model info
        public void InitializeModelInfo()
        {
            DataGridViewButtonColumn columnButton = new DataGridViewButtonColumn();
            DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn infoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            _modelInfo.Columns.AddRange(new DataGridViewColumn[] { columnButton, nameDataGridViewTextBoxColumn, infoDataGridViewTextBoxColumn});

            columnButton.HeaderText = Constant.DELETE;
            columnButton.Text = Constant.DELETE;
            columnButton.UseColumnTextForButtonValue = true;

            nameDataGridViewTextBoxColumn.DataPropertyName = Constant.NAME_CHINESE;
            nameDataGridViewTextBoxColumn.HeaderText = Constant.SHAPE;
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            nameDataGridViewTextBoxColumn.Width = Constant.TEXTBOX_COLUMN_WIDTH;

            infoDataGridViewTextBoxColumn.DataPropertyName = Constant.INFO;
            infoDataGridViewTextBoxColumn.HeaderText = Constant.INFO_CHINESE;
            infoDataGridViewTextBoxColumn.ReadOnly = true;
            infoDataGridViewTextBoxColumn.Width = Constant.TEXTBOX_COLUMN_WIDTH;
            infoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _modelInfo.CellContentClick += ModelInfoCellClick;
        }

        // draw canva to button
        public void DrawCanvaPanelToButton()
        {
            _brief = new Bitmap(_doubleBufferPanel.Width, _doubleBufferPanel.Height);
            Button button = (Button)_slideInfo.Controls[_model.CurrentPageIndex];
            _doubleBufferPanel.DrawToBitmap(_brief, new System.Drawing.Rectangle(0, 0, _doubleBufferPanel.Width, _doubleBufferPanel.Height));
            button.Image = new Bitmap(_brief, button.Size);
        }

        // handle page changed
        public void HandlePageChanged(EventArgs e)
        {
            _presentationModel.HandlePageChanged(_slideInfo);
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
            DrawCanvaPanelToButton();
            _presentationModel.HandleStateChanged();
        }

        // handle add shape button click
        public void ProcessAddShapeButton(object sender, EventArgs e)
        {
            _presentationModel.ProcessAddShapeButton(_shapeOption, _doubleBufferPanel.Size);
        }

        // handle Line button click
        public void ProcessLineButton(object sender, EventArgs e)
        {
            _presentationModel.ProcessLineButton();
            _presentationModel.HandleStateChanged();
        }

        // handle Rectangle button click
        public void ProcessRectangleButton(object sender, EventArgs e)
        {
            _presentationModel.ProcessRectangleButton();
            _presentationModel.HandleStateChanged();
        }

        // handle Ellipse button click
        public void ProcessEllipseButton(object sender, EventArgs e)
        {
            _presentationModel.ProcessEllipseButton();
            _presentationModel.HandleStateChanged();
        }

        // handle Idle button click
        public void ProcessCursorButton(object sender, EventArgs e)
        {
            _presentationModel.ProcessCursorButton();
            _presentationModel.HandleStateChanged();
        }

        // model info cell click
        public void ModelInfoCellClick(object sender, DataGridViewCellEventArgs e)
        {
            _presentationModel.ModelInfoCellClick(BindingManager.Position, e.ColumnIndex);
        }

        // hangle key down
        public void HandleKeyDown(object sender, KeyEventArgs e)
        {
            _presentationModel.HandleKeyDown(e.KeyCode);
        }

        // handle add slide button clicked
        public void AddPageClick(object sender, EventArgs e)
        {
            _presentationModel.AddPageClick();
        }

        // handle delete all button clicked
        public void DeleteSlideButtonClick(object sender, EventArgs e)
        {
            _presentationModel.DeleteSlideButton(_slideInfo);
            _presentationModel.AddSlideButton(_slideInfo);
            DrawCanvaPanelToButton();
        }

        // handle undo button
        public void UndoButtonClick(object sender, EventArgs e)
        {
            _model.CommandManager.Undo();
            _model.NotifyModelChanged();
        }

        // handle redo button
        public void RedoButtonClick(object sender, EventArgs e)
        {
            _model.CommandManager.Redo();
            _model.NotifyModelChanged();
        }
    }
}