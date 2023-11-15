
namespace PowerPoint
{
				partial class Form1
				{
								/// <summary>
								/// 設計工具所需的變數。
								/// </summary>
								private System.ComponentModel.IContainer components = null;

								/// <summary>
								/// 清除任何使用中的資源。
								/// </summary>
								/// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
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
								/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
								/// 這個方法的內容。
								/// </summary>
								private void InitializeComponent()
								{
												this._menuStrip1 = new System.Windows.Forms.MenuStrip();
												this._toolStripMenuItem00 = new System.Windows.Forms.ToolStripMenuItem();
												this._toolStripMenuItem01 = new System.Windows.Forms.ToolStripMenuItem();
												this._buttonAdd = new System.Windows.Forms.Button();
												this._shapeOption = new System.Windows.Forms.ComboBox();
												this._slideInfo = new System.Windows.Forms.DataGridView();
												this._modelInfo = new System.Windows.Forms.DataGridView();
												this._groupBox1 = new System.Windows.Forms.GroupBox();
												this._slideColumn = new System.Windows.Forms.DataGridViewButtonColumn();
												this._menuStrip1.SuspendLayout();
												((System.ComponentModel.ISupportInitialize)(this._slideInfo)).BeginInit();
												((System.ComponentModel.ISupportInitialize)(this._modelInfo)).BeginInit();
												this._groupBox1.SuspendLayout();
												this.SuspendLayout();
												// 
												// _menuStrip1
												// 
												this._menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
												this._menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuItem00});
												this._menuStrip1.Location = new System.Drawing.Point(0, 0);
												this._menuStrip1.Name = "_menuStrip1";
												this._menuStrip1.Padding = new System.Windows.Forms.Padding(5, 3, 0, 3);
												this._menuStrip1.Size = new System.Drawing.Size(1595, 29);
												this._menuStrip1.TabIndex = 3;
												this._menuStrip1.Text = "menuStrip1";
												// 
												// _toolStripMenuItem00
												// 
												this._toolStripMenuItem00.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuItem01});
												this._toolStripMenuItem00.Name = "_toolStripMenuItem00";
												this._toolStripMenuItem00.Size = new System.Drawing.Size(53, 23);
												this._toolStripMenuItem00.Text = "選單";
												// 
												// _toolStripMenuItem01
												// 
												this._toolStripMenuItem01.Name = "_toolStripMenuItem01";
												this._toolStripMenuItem01.Size = new System.Drawing.Size(122, 26);
												this._toolStripMenuItem01.Text = "關於";
												// 
												// _buttonAdd
												// 
												this._buttonAdd.Location = new System.Drawing.Point(7, 4);
												this._buttonAdd.Name = "_buttonAdd";
												this._buttonAdd.Size = new System.Drawing.Size(117, 45);
												this._buttonAdd.TabIndex = 4;
												this._buttonAdd.Text = "新增";
												this._buttonAdd.UseVisualStyleBackColor = true;
												this._buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
												// 
												// _shapeOption
												// 
												this._shapeOption.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
												this._shapeOption.FormattingEnabled = true;
												this._shapeOption.Items.AddRange(new object[] {
            "線",
            "矩形"});
												this._shapeOption.Location = new System.Drawing.Point(279, 11);
												this._shapeOption.Name = "_shapeOption";
												this._shapeOption.Size = new System.Drawing.Size(137, 28);
												this._shapeOption.TabIndex = 5;
												// 
												// _slideInfo
												// 
												this._slideInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
												this._slideInfo.ColumnHeadersVisible = false;
												this._slideInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._slideColumn});
												this._slideInfo.Location = new System.Drawing.Point(0, 35);
												this._slideInfo.Name = "_slideInfo";
												this._slideInfo.RowHeadersVisible = false;
												this._slideInfo.RowHeadersWidth = 51;
												this._slideInfo.RowTemplate.Height = 24;
												this._slideInfo.Size = new System.Drawing.Size(144, 800);
												this._slideInfo.TabIndex = 6;
												// 
												// _modelInfo
												// 
												this._modelInfo.AllowUserToAddRows = false;
												this._modelInfo.AllowUserToDeleteRows = false;
												this._modelInfo.AllowUserToResizeColumns = false;
												this._modelInfo.AllowUserToResizeRows = false;
												this._modelInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
												this._modelInfo.Location = new System.Drawing.Point(7, 60);
												this._modelInfo.Name = "_modelInfo";
												this._modelInfo.ReadOnly = true;
												this._modelInfo.RowHeadersVisible = false;
												this._modelInfo.RowHeadersWidth = 51;
												this._modelInfo.RowTemplate.Height = 24;
												this._modelInfo.Size = new System.Drawing.Size(400, 800);
												this._modelInfo.TabIndex = 0;
												this._modelInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ModelInfoCellDeleteClick);
												// 
												// _groupBox1
												// 
												this._groupBox1.Controls.Add(this._buttonAdd);
												this._groupBox1.Controls.Add(this._shapeOption);
												this._groupBox1.Controls.Add(this._modelInfo);
												this._groupBox1.Location = new System.Drawing.Point(1163, 35);
												this._groupBox1.Margin = new System.Windows.Forms.Padding(4);
												this._groupBox1.Name = "_groupBox1";
												this._groupBox1.Padding = new System.Windows.Forms.Padding(4);
												this._groupBox1.Size = new System.Drawing.Size(432, 819);
												this._groupBox1.TabIndex = 7;
												this._groupBox1.TabStop = false;
												// 
												// _slideColumn
												// 
												this._slideColumn.HeaderText = "Column1";
												this._slideColumn.MinimumWidth = 10;
												this._slideColumn.Name = "_slideColumn";
												this._slideColumn.Width = 125;
												// 
												// Form1
												// 
												this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
												this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
												this.ClientSize = new System.Drawing.Size(1595, 849);
												this.Controls.Add(this._groupBox1);
												this.Controls.Add(this._slideInfo);
												this.Controls.Add(this._menuStrip1);
												this.MainMenuStrip = this._menuStrip1;
												this.Name = "Form1";
												this.Text = "PowerPoint";
												this._menuStrip1.ResumeLayout(false);
												this._menuStrip1.PerformLayout();
												((System.ComponentModel.ISupportInitialize)(this._slideInfo)).EndInit();
												((System.ComponentModel.ISupportInitialize)(this._modelInfo)).EndInit();
												this._groupBox1.ResumeLayout(false);
												this.ResumeLayout(false);
												this.PerformLayout();

								}

								#endregion
								private System.Windows.Forms.MenuStrip _menuStrip1;
								private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItem00;
								private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItem01;
								private System.Windows.Forms.Button _buttonAdd;
								private System.Windows.Forms.ComboBox _shapeOption;
								private System.Windows.Forms.DataGridView _slideInfo;
								private System.Windows.Forms.DataGridView _modelInfo;
								private System.Windows.Forms.GroupBox _groupBox1;
								private System.Windows.Forms.DataGridViewButtonColumn _slideColumn;
				}
}

