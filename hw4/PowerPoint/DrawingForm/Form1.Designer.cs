
namespace DrawingForm
{
	partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._menuStripTop = new System.Windows.Forms.MenuStrip();
            this._menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._rightBox = new System.Windows.Forms.GroupBox();
            this._shapeOption = new System.Windows.Forms.ComboBox();
            this._buttonAdd = new System.Windows.Forms.Button();
            this._modelInfo = new System.Windows.Forms.DataGridView();
            this._slideInfo = new System.Windows.Forms.FlowLayoutPanel();
            this._slideButton = new System.Windows.Forms.Button();
            this._toolStripTop = new System.Windows.Forms.ToolStrip();
            this._panel = new DrawingForm.DoubleBufferedPanel();
            this._nameChineseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._infoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            //this.shapeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this._toolStripButtonLine = new DrawingForm.ToolStripBindableButton();
            this._toolStripButtonRectangle = new DrawingForm.ToolStripBindableButton();
            this._toolStripButtonEllipse = new DrawingForm.ToolStripBindableButton();
            this._toolStripButtonIdle = new DrawingForm.ToolStripBindableButton();
            this._toolStripButtonSelect = new DrawingForm.ToolStripBindableButton();
            this._shapeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._menuStripTop.SuspendLayout();
            this._rightBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._modelInfo)).BeginInit();
            this._slideInfo.SuspendLayout();
            this._toolStripTop.SuspendLayout();
            //((System.ComponentModel.ISupportInitialize)(this.shapeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._shapeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _menuStripTop
            // 
            this._menuStripTop.Dock = System.Windows.Forms.DockStyle.None;
            this._menuStripTop.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuToolStripMenuItem});
            this._menuStripTop.Location = new System.Drawing.Point(0, 0);
            this._menuStripTop.Name = "_menuStripTop";
            this._menuStripTop.Padding = new System.Windows.Forms.Padding(5, 3, 0, 3);
            this._menuStripTop.Size = new System.Drawing.Size(62, 30);
            this._menuStripTop.TabIndex = 0;
            this._menuStripTop.Text = "menuStrip1";
            // 
            // _menuToolStripMenuItem
            // 
            this._menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._menuToolStripMenuItem.Name = "_menuToolStripMenuItem";
            this._menuToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this._menuToolStripMenuItem.Text = "選單";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(124, 26);
            this._aboutToolStripMenuItem.Text = "關於";
            // 
            // _rightBox
            // 
            this._rightBox.Controls.Add(this._shapeOption);
            this._rightBox.Controls.Add(this._buttonAdd);
            this._rightBox.Controls.Add(this._modelInfo);
            this._rightBox.Location = new System.Drawing.Point(1010, 58);
            this._rightBox.Name = "_rightBox";
            this._rightBox.Size = new System.Drawing.Size(496, 953);
            this._rightBox.TabIndex = 2;
            this._rightBox.TabStop = false;
            this._rightBox.Text = "資料顯示";
            // 
            // _shapeOption
            // 
            this._shapeOption.FormattingEnabled = true;
            this._shapeOption.Items.AddRange(new object[] {
            "線",
            "矩形",
            "橢圓"});
            this._shapeOption.Location = new System.Drawing.Point(261, 31);
            this._shapeOption.Name = "_shapeOption";
            this._shapeOption.Size = new System.Drawing.Size(121, 24);
            this._shapeOption.TabIndex = 4;
            // 
            // _buttonAdd
            // 
            this._buttonAdd.Location = new System.Drawing.Point(17, 25);
            this._buttonAdd.Name = "_buttonAdd";
            this._buttonAdd.Size = new System.Drawing.Size(79, 35);
            this._buttonAdd.TabIndex = 3;
            this._buttonAdd.Text = "新增";
            this._buttonAdd.UseVisualStyleBackColor = true;
            this._buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // _modelInfo
            // 
            this._modelInfo.AllowUserToAddRows = false;
            this._modelInfo.AllowUserToDeleteRows = false;
            this._modelInfo.AllowUserToResizeColumns = false;
            this._modelInfo.AllowUserToResizeRows = false;
            this._modelInfo.AutoGenerateColumns = false;
            this._modelInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._modelInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._nameChineseDataGridViewTextBoxColumn,
            this._infoDataGridViewTextBoxColumn});
            //this._modelInfo.DataSource = this.shapeBindingSource1;
            this._modelInfo.Location = new System.Drawing.Point(3, 76);
            this._modelInfo.Name = "_modelInfo";
            this._modelInfo.ReadOnly = true;
            this._modelInfo.RowHeadersVisible = false;
            this._modelInfo.RowHeadersWidth = 51;
            this._modelInfo.RowTemplate.Height = 24;
            this._modelInfo.Size = new System.Drawing.Size(466, 606);
            this._modelInfo.TabIndex = 0;
            // 
            // _slideInfo
            // 
            this._slideInfo.Controls.Add(this._slideButton);
            this._slideInfo.Location = new System.Drawing.Point(0, 58);
            this._slideInfo.Name = "_slideInfo";
            this._slideInfo.Size = new System.Drawing.Size(153, 923);
            this._slideInfo.TabIndex = 3;
            // 
            // _slidebutton
            // 
            this._slideButton.Location = new System.Drawing.Point(3, 3);
            this._slideButton.Name = "_slidebutton";
            this._slideButton.Size = new System.Drawing.Size(146, 146);
            this._slideButton.TabIndex = 0;
            this._slideButton.UseVisualStyleBackColor = true;
            // 
            // _toolStripTop
            // 
            this._toolStripTop.Dock = System.Windows.Forms.DockStyle.None;
            this._toolStripTop.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._toolStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripButtonLine,
            this._toolStripButtonRectangle,
            this._toolStripButtonEllipse,
            this._toolStripButtonIdle,
            this._toolStripButtonSelect});
            this._toolStripTop.Location = new System.Drawing.Point(0, 30);
            this._toolStripTop.Name = "_toolStripTop";
            this._toolStripTop.Size = new System.Drawing.Size(197, 31);
            this._toolStripTop.TabIndex = 1;
            this._toolStripTop.Text = "toolStrip1";
            // 
            // _toolStripButtonSelect
            // 
            this._toolStripButtonSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButtonSelect.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonSelect.Image")));
            this._toolStripButtonSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonSelect.Name = "_toolStripButtonSelect";
            this._toolStripButtonSelect.Size = new System.Drawing.Size(29, 28);
            this._toolStripButtonSelect.Text = "select";
            this._toolStripButtonSelect.Click += new System.EventHandler(this.ToolStripButtonSelectClick);
            // 
            // _panel
            // 
            this._panel.Location = new System.Drawing.Point(160, 58);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(800, 800);
            this._panel.TabIndex = 4;
            // 
            // nameChineseDataGridViewTextBoxColumn
            // 
            this._nameChineseDataGridViewTextBoxColumn.DataPropertyName = "NameChinese";
            this._nameChineseDataGridViewTextBoxColumn.HeaderText = "形狀";
            this._nameChineseDataGridViewTextBoxColumn.MinimumWidth = 6;
            this._nameChineseDataGridViewTextBoxColumn.Name = "nameChineseDataGridViewTextBoxColumn";
            this._nameChineseDataGridViewTextBoxColumn.ReadOnly = true;
            this._nameChineseDataGridViewTextBoxColumn.Width = 125;
            // 
            // infoDataGridViewTextBoxColumn
            // 
            this._infoDataGridViewTextBoxColumn.DataPropertyName = "Info";
            this._infoDataGridViewTextBoxColumn.HeaderText = "資訊";
            this._infoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this._infoDataGridViewTextBoxColumn.Name = "infoDataGridViewTextBoxColumn";
            this._infoDataGridViewTextBoxColumn.ReadOnly = true;
            this._infoDataGridViewTextBoxColumn.Width = 125;
            // 
            // shapeBindingSource1
            // 
            //this.shapeBindingSource1.DataSource = typeof(DrawingModel.Shape);
            // 
            // _toolStripButtonLine
            // 
            this._toolStripButtonLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButtonLine.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonLine.Image")));
            this._toolStripButtonLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonLine.Name = "_toolStripButtonLine";
            this._toolStripButtonLine.Size = new System.Drawing.Size(29, 28);
            this._toolStripButtonLine.Text = "➖";
            this._toolStripButtonLine.Click += new System.EventHandler(this.ToolStripButtonLine);
            // 
            // _toolStripButtonRectangle
            // 
            this._toolStripButtonRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButtonRectangle.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonRectangle.Image")));
            this._toolStripButtonRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonRectangle.Name = "_toolStripButtonRectangle";
            this._toolStripButtonRectangle.Size = new System.Drawing.Size(29, 28);
            this._toolStripButtonRectangle.Text = "🔲";
            this._toolStripButtonRectangle.Click += new System.EventHandler(this.ToolStripButtonRectangle);
            // 
            // _toolStripButtonEllipse
            // 
            this._toolStripButtonEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButtonEllipse.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonEllipse.Image")));
            this._toolStripButtonEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonEllipse.Name = "_toolStripButtonEllipse";
            this._toolStripButtonEllipse.Size = new System.Drawing.Size(29, 28);
            this._toolStripButtonEllipse.Text = "⭕";
            this._toolStripButtonEllipse.Click += new System.EventHandler(this.ToolStripButtonEllipse);
            // 
            // _toolStripButtonIdle
            // 
            this._toolStripButtonIdle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButtonIdle.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonIdle.Image")));
            this._toolStripButtonIdle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonIdle.Name = "_toolStripButtonIdle";
            this._toolStripButtonIdle.Size = new System.Drawing.Size(29, 28);
            this._toolStripButtonIdle.Text = "🖱️";
            this._toolStripButtonIdle.Click += new System.EventHandler(this.ToolStripButtonIdle);
            // 
            // shapeBindingSource
            // 
            this._shapeBindingSource.DataSource = typeof(DrawingModel.Shape);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this._panel);
            this.Controls.Add(this._slideInfo);
            this.Controls.Add(this._rightBox);
            this.Controls.Add(this._menuStripTop);
            this.Controls.Add(this._toolStripTop);
            this.MainMenuStrip = this._menuStripTop;
            this.Name = "Form1";
            this.Text = "Form1";
            this._menuStripTop.ResumeLayout(false);
            this._menuStripTop.PerformLayout();
            this._rightBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._modelInfo)).EndInit();
            this._slideInfo.ResumeLayout(false);
            this._toolStripTop.ResumeLayout(false);
            this._toolStripTop.PerformLayout();
            //((System.ComponentModel.ISupportInitialize)(this.shapeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._shapeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStripTop;
        private System.Windows.Forms.ToolStripMenuItem _menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox _rightBox;
        private System.Windows.Forms.DataGridView _modelInfo;
        private System.Windows.Forms.Button _buttonAdd;
        private System.Windows.Forms.ComboBox _shapeOption;
        private System.Windows.Forms.FlowLayoutPanel _slideInfo;
        private System.Windows.Forms.Button _slideButton;
        private System.Windows.Forms.BindingSource _shapeBindingSource;
        //private System.Windows.Forms.BindingSource shapeBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _nameChineseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _infoDataGridViewTextBoxColumn;
    }
}

