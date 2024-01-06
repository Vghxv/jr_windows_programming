
namespace DrawingForm
{
	partial class MainForm
	{
		/// <summary>
		/// designer variable
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  clean up all resources in use
		/// </summary>
		/// <param name="disposing">true if managed resources should be released; otherwise, false </param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// designer support the required method - do not use the code editor to modify
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._menuStripTop = new System.Windows.Forms.MenuStrip();
            this._menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripTop = new System.Windows.Forms.ToolStrip();
            this._toolStripButtonLine = new DrawingForm.ToolStripBindableButton();
            this._toolStripButtonRectangle = new DrawingForm.ToolStripBindableButton();
            this._toolStripButtonEllipse = new DrawingForm.ToolStripBindableButton();
            this._toolStripButtonIdle = new DrawingForm.ToolStripBindableButton();
            this._addSlideButton = new System.Windows.Forms.ToolStripButton();
            this._undoButton = new System.Windows.Forms.ToolStripButton();
            this._redoButton = new System.Windows.Forms.ToolStripButton();
            this._slideInfo = new System.Windows.Forms.FlowLayoutPanel();
            this._rightBox = new System.Windows.Forms.GroupBox();
            this._rightSplitContainer = new System.Windows.Forms.SplitContainer();
            this._deleteSlideButton = new System.Windows.Forms.Button();
            this._shapeOption = new System.Windows.Forms.ComboBox();
            this._addShapeButton = new System.Windows.Forms.Button();
            this._modelInfo = new System.Windows.Forms.DataGridView();
            this._superSplitContainer = new System.Windows.Forms.SplitContainer();
            this._mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this._subSplitContainer = new System.Windows.Forms.SplitContainer();
            this._canvaPanelRegion = new System.Windows.Forms.Panel();
            this._shapeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._menuStripTop.SuspendLayout();
            this._toolStripTop.SuspendLayout();
            this._rightBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._rightSplitContainer)).BeginInit();
            this._rightSplitContainer.Panel1.SuspendLayout();
            this._rightSplitContainer.Panel2.SuspendLayout();
            this._rightSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._modelInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._superSplitContainer)).BeginInit();
            this._superSplitContainer.Panel1.SuspendLayout();
            this._superSplitContainer.Panel2.SuspendLayout();
            this._superSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mainSplitContainer)).BeginInit();
            this._mainSplitContainer.Panel1.SuspendLayout();
            this._mainSplitContainer.Panel2.SuspendLayout();
            this._mainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._subSplitContainer)).BeginInit();
            this._subSplitContainer.Panel1.SuspendLayout();
            this._subSplitContainer.Panel2.SuspendLayout();
            this._subSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._shapeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _menuStripTop
            // 
            this._menuStripTop.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuToolStripMenuItem});
            this._menuStripTop.Location = new System.Drawing.Point(0, 0);
            this._menuStripTop.Name = "_menuStripTop";
            this._menuStripTop.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this._menuStripTop.Size = new System.Drawing.Size(1186, 24);
            this._menuStripTop.TabIndex = 0;
            this._menuStripTop.Text = "menuStrip1";
            // 
            // _menuToolStripMenuItem
            // 
            this._menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._menuToolStripMenuItem.Name = "_menuToolStripMenuItem";
            this._menuToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this._menuToolStripMenuItem.Text = "選單";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this._aboutToolStripMenuItem.Text = "關於";
            // 
            // _toolStripTop
            // 
            this._toolStripTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this._toolStripTop.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._toolStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripButtonLine,
            this._toolStripButtonRectangle,
            this._toolStripButtonEllipse,
            this._toolStripButtonIdle,
            this._addSlideButton,
            this._undoButton,
            this._redoButton});
            this._toolStripTop.Location = new System.Drawing.Point(0, 0);
            this._toolStripTop.Name = "_toolStripTop";
            this._toolStripTop.Size = new System.Drawing.Size(1186, 25);
            this._toolStripTop.TabIndex = 1;
            this._toolStripTop.Text = "toolStrip1";
            // 
            // _toolStripButtonLine
            // 
            this._toolStripButtonLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButtonLine.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonLine.Image")));
            this._toolStripButtonLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonLine.Name = "_toolStripButtonLine";
            this._toolStripButtonLine.Size = new System.Drawing.Size(24, 22);
            this._toolStripButtonLine.Text = "Line";
            this._toolStripButtonLine.Click += new System.EventHandler(this.ProcessLineButton);
            // 
            // _toolStripButtonRectangle
            // 
            this._toolStripButtonRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButtonRectangle.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonRectangle.Image")));
            this._toolStripButtonRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonRectangle.Name = "_toolStripButtonRectangle";
            this._toolStripButtonRectangle.Size = new System.Drawing.Size(24, 22);
            this._toolStripButtonRectangle.Text = "Rectangle";
            this._toolStripButtonRectangle.Click += new System.EventHandler(this.ProcessRectangleButton);
            // 
            // _toolStripButtonEllipse
            // 
            this._toolStripButtonEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButtonEllipse.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonEllipse.Image")));
            this._toolStripButtonEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonEllipse.Name = "_toolStripButtonEllipse";
            this._toolStripButtonEllipse.Size = new System.Drawing.Size(24, 22);
            this._toolStripButtonEllipse.Text = "Ellipse";
            this._toolStripButtonEllipse.Click += new System.EventHandler(this.ProcessEllipseButton);
            // 
            // _toolStripButtonIdle
            // 
            this._toolStripButtonIdle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButtonIdle.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonIdle.Image")));
            this._toolStripButtonIdle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonIdle.Name = "_toolStripButtonIdle";
            this._toolStripButtonIdle.Size = new System.Drawing.Size(24, 22);
            this._toolStripButtonIdle.Text = "Mouse";
            this._toolStripButtonIdle.Click += new System.EventHandler(this.ProcessCursorButton);
            // 
            // _addSlideButton
            // 
            this._addSlideButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._addSlideButton.Image = ((System.Drawing.Image)(resources.GetObject("_addSlideButton.Image")));
            this._addSlideButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._addSlideButton.Name = "_addSlideButton";
            this._addSlideButton.Size = new System.Drawing.Size(24, 22);
            this._addSlideButton.Text = "addSlide";
            this._addSlideButton.Click += new System.EventHandler(this.AddPageClick);
            // 
            // _undoButton
            // 
            this._undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._undoButton.Image = ((System.Drawing.Image)(resources.GetObject("_undoButton.Image")));
            this._undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._undoButton.Name = "_undoButton";
            this._undoButton.Size = new System.Drawing.Size(24, 22);
            this._undoButton.Text = "Undo";
            this._undoButton.Click += new System.EventHandler(this.UndoButtonClick);
            // 
            // _redoButton
            // 
            this._redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._redoButton.Image = ((System.Drawing.Image)(resources.GetObject("_redoButton.Image")));
            this._redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._redoButton.Name = "_redoButton";
            this._redoButton.Size = new System.Drawing.Size(24, 22);
            this._redoButton.Text = "Redo";
            this._redoButton.Click += new System.EventHandler(this.RedoButtonClick);
            // 
            // _slideInfo
            // 
            this._slideInfo.BackColor = System.Drawing.SystemColors.ControlLight;
            this._slideInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._slideInfo.Location = new System.Drawing.Point(0, 0);
            this._slideInfo.Margin = new System.Windows.Forms.Padding(2);
            this._slideInfo.Name = "_slideInfo";
            this._slideInfo.Size = new System.Drawing.Size(116, 592);
            this._slideInfo.TabIndex = 3;
            // 
            // _rightBox
            // 
            this._rightBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this._rightBox.Controls.Add(this._rightSplitContainer);
            this._rightBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rightBox.Location = new System.Drawing.Point(0, 0);
            this._rightBox.Margin = new System.Windows.Forms.Padding(0);
            this._rightBox.Name = "_rightBox";
            this._rightBox.Size = new System.Drawing.Size(418, 592);
            this._rightBox.TabIndex = 2;
            this._rightBox.TabStop = false;
            this._rightBox.Text = "資料顯示";
            // 
            // _rightSplitContainer
            // 
            this._rightSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rightSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._rightSplitContainer.IsSplitterFixed = true;
            this._rightSplitContainer.Location = new System.Drawing.Point(3, 16);
            this._rightSplitContainer.Name = "_rightSplitContainer";
            this._rightSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _rightSplitContainer.Panel1
            // 
            this._rightSplitContainer.Panel1.Controls.Add(this._deleteSlideButton);
            this._rightSplitContainer.Panel1.Controls.Add(this._shapeOption);
            this._rightSplitContainer.Panel1.Controls.Add(this._addShapeButton);
            this._rightSplitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // _rightSplitContainer.Panel2
            // 
            this._rightSplitContainer.Panel2.Controls.Add(this._modelInfo);
            this._rightSplitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._rightSplitContainer.Size = new System.Drawing.Size(412, 573);
            this._rightSplitContainer.SplitterDistance = 76;
            this._rightSplitContainer.TabIndex = 5;
            // 
            // _deleteSlideButton
            // 
            this._deleteSlideButton.AutoSize = true;
            this._deleteSlideButton.Location = new System.Drawing.Point(299, 21);
            this._deleteSlideButton.Margin = new System.Windows.Forms.Padding(2);
            this._deleteSlideButton.Name = "_deleteSlideButton";
            this._deleteSlideButton.Size = new System.Drawing.Size(77, 39);
            this._deleteSlideButton.TabIndex = 6;
            this._deleteSlideButton.Text = "清空全頁";
            this._deleteSlideButton.UseVisualStyleBackColor = true;
            this._deleteSlideButton.Click += new System.EventHandler(this.DeleteSlideButtonClick);
            // 
            // _shapeOption
            // 
            this._shapeOption.FormattingEnabled = true;
            this._shapeOption.Items.AddRange(new object[] {
            "線",
            "矩形",
            "橢圓"});
            this._shapeOption.Location = new System.Drawing.Point(98, 31);
            this._shapeOption.Margin = new System.Windows.Forms.Padding(2);
            this._shapeOption.Name = "_shapeOption";
            this._shapeOption.Size = new System.Drawing.Size(92, 21);
            this._shapeOption.TabIndex = 4;
            // 
            // _addShapeButton
            // 
            this._addShapeButton.AutoSize = true;
            this._addShapeButton.Location = new System.Drawing.Point(18, 21);
            this._addShapeButton.Margin = new System.Windows.Forms.Padding(2);
            this._addShapeButton.Name = "_addShapeButton";
            this._addShapeButton.Size = new System.Drawing.Size(53, 39);
            this._addShapeButton.TabIndex = 3;
            this._addShapeButton.Text = "新增";
            this._addShapeButton.UseVisualStyleBackColor = true;
            this._addShapeButton.Click += new System.EventHandler(this.ProcessAddShapeButton);
            // 
            // _modelInfo
            // 
            this._modelInfo.AllowUserToAddRows = false;
            this._modelInfo.AllowUserToDeleteRows = false;
            this._modelInfo.AllowUserToResizeColumns = false;
            this._modelInfo.AllowUserToResizeRows = false;
            this._modelInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._modelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._modelInfo.Location = new System.Drawing.Point(0, 0);
            this._modelInfo.Margin = new System.Windows.Forms.Padding(2);
            this._modelInfo.Name = "_modelInfo";
            this._modelInfo.ReadOnly = true;
            this._modelInfo.RowHeadersVisible = false;
            this._modelInfo.RowHeadersWidth = 51;
            this._modelInfo.RowTemplate.Height = 24;
            this._modelInfo.Size = new System.Drawing.Size(412, 493);
            this._modelInfo.TabIndex = 0;
            // 
            // _superSplitContainer
            // 
            this._superSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._superSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._superSplitContainer.IsSplitterFixed = true;
            this._superSplitContainer.Location = new System.Drawing.Point(0, 24);
            this._superSplitContainer.Margin = new System.Windows.Forms.Padding(2);
            this._superSplitContainer.Name = "_superSplitContainer";
            this._superSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _superSplitContainer.Panel1
            // 
            this._superSplitContainer.Panel1.Controls.Add(this._toolStripTop);
            // 
            // _superSplitContainer.Panel2
            // 
            this._superSplitContainer.Panel2.Controls.Add(this._mainSplitContainer);
            this._superSplitContainer.Size = new System.Drawing.Size(1186, 620);
            this._superSplitContainer.SplitterDistance = 25;
            this._superSplitContainer.SplitterWidth = 3;
            this._superSplitContainer.TabIndex = 7;
            // 
            // _mainSplitContainer
            // 
            this._mainSplitContainer.BackColor = System.Drawing.SystemColors.WindowFrame;
            this._mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this._mainSplitContainer.Margin = new System.Windows.Forms.Padding(2);
            this._mainSplitContainer.Name = "_mainSplitContainer";
            // 
            // _mainSplitContainer.Panel1
            // 
            this._mainSplitContainer.Panel1.Controls.Add(this._slideInfo);
            // 
            // _mainSplitContainer.Panel2
            // 
            this._mainSplitContainer.Panel2.Controls.Add(this._subSplitContainer);
            this._mainSplitContainer.Size = new System.Drawing.Size(1186, 592);
            this._mainSplitContainer.SplitterDistance = 116;
            this._mainSplitContainer.SplitterWidth = 3;
            this._mainSplitContainer.TabIndex = 7;
            // 
            // _subSplitContainer
            // 
            this._subSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._subSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._subSplitContainer.Location = new System.Drawing.Point(0, 0);
            this._subSplitContainer.Margin = new System.Windows.Forms.Padding(2);
            this._subSplitContainer.Name = "_subSplitContainer";
            // 
            // _subSplitContainer.Panel1
            // 
            this._subSplitContainer.Panel1.Controls.Add(this._canvaPanelRegion);
            // 
            // _subSplitContainer.Panel2
            // 
            this._subSplitContainer.Panel2.Controls.Add(this._rightBox);
            this._subSplitContainer.Size = new System.Drawing.Size(1067, 592);
            this._subSplitContainer.SplitterDistance = 646;
            this._subSplitContainer.SplitterWidth = 3;
            this._subSplitContainer.TabIndex = 0;
            // 
            // _canvaPanelRegion
            // 
            this._canvaPanelRegion.BackColor = System.Drawing.SystemColors.ControlLight;
            this._canvaPanelRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this._canvaPanelRegion.Location = new System.Drawing.Point(0, 0);
            this._canvaPanelRegion.Margin = new System.Windows.Forms.Padding(2);
            this._canvaPanelRegion.Name = "_canvaPanelRegion";
            this._canvaPanelRegion.Size = new System.Drawing.Size(646, 592);
            this._canvaPanelRegion.TabIndex = 6;
            // 
            // _shapeBindingSource
            // 
            this._shapeBindingSource.DataSource = typeof(DrawingModel.Shape);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 644);
            this.Controls.Add(this._superSplitContainer);
            this.Controls.Add(this._menuStripTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this._menuStripTop;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "SlideForge";
            this._menuStripTop.ResumeLayout(false);
            this._menuStripTop.PerformLayout();
            this._toolStripTop.ResumeLayout(false);
            this._toolStripTop.PerformLayout();
            this._rightBox.ResumeLayout(false);
            this._rightSplitContainer.Panel1.ResumeLayout(false);
            this._rightSplitContainer.Panel1.PerformLayout();
            this._rightSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._rightSplitContainer)).EndInit();
            this._rightSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._modelInfo)).EndInit();
            this._superSplitContainer.Panel1.ResumeLayout(false);
            this._superSplitContainer.Panel1.PerformLayout();
            this._superSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._superSplitContainer)).EndInit();
            this._superSplitContainer.ResumeLayout(false);
            this._mainSplitContainer.Panel1.ResumeLayout(false);
            this._mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._mainSplitContainer)).EndInit();
            this._mainSplitContainer.ResumeLayout(false);
            this._subSplitContainer.Panel1.ResumeLayout(false);
            this._subSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._subSplitContainer)).EndInit();
            this._subSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._shapeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStripTop;
        private System.Windows.Forms.ToolStripMenuItem _menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.BindingSource _shapeBindingSource;
        private System.Windows.Forms.FlowLayoutPanel _slideInfo;
        private System.Windows.Forms.GroupBox _rightBox;
        private System.Windows.Forms.ComboBox _shapeOption;
        private System.Windows.Forms.Button _addShapeButton;
        private System.Windows.Forms.DataGridView _modelInfo;
        private System.Windows.Forms.Panel _canvaPanelRegion;
        private System.Windows.Forms.SplitContainer _superSplitContainer;
        private System.Windows.Forms.SplitContainer _mainSplitContainer;
        private System.Windows.Forms.SplitContainer _subSplitContainer;
        private System.Windows.Forms.SplitContainer _rightSplitContainer;
        private System.Windows.Forms.Button _deleteSlideButton;
        private System.Windows.Forms.ToolStripButton _undoButton;
        private System.Windows.Forms.ToolStripButton _redoButton;
        private System.Windows.Forms.ToolStripButton _addSlideButton;
    }
}

