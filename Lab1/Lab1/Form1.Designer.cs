
namespace Lab1
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
												this.id = new System.Windows.Forms.TextBox();
												this.label_stu_id = new System.Windows.Forms.Label();
												this.label1 = new System.Windows.Forms.Label();
												this.name = new System.Windows.Forms.TextBox();
												this.addstudent = new System.Windows.Forms.Button();
												this.studentDataGridView = new System.Windows.Forms.DataGridView();
												this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
												this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
												((System.ComponentModel.ISupportInitialize)(this.studentDataGridView)).BeginInit();
												this.SuspendLayout();
												// 
												// id
												// 
												this.id.Location = new System.Drawing.Point(121, 58);
												this.id.Name = "id";
												this.id.Size = new System.Drawing.Size(100, 22);
												this.id.TabIndex = 0;
												// 
												// label_stu_id
												// 
												this.label_stu_id.AutoSize = true;
												this.label_stu_id.Location = new System.Drawing.Point(121, 13);
												this.label_stu_id.Name = "label_stu_id";
												this.label_stu_id.Size = new System.Drawing.Size(74, 17);
												this.label_stu_id.TabIndex = 1;
												this.label_stu_id.Text = "Student ID";
												// 
												// label1
												// 
												this.label1.AutoSize = true;
												this.label1.Location = new System.Drawing.Point(121, 130);
												this.label1.Name = "label1";
												this.label1.Size = new System.Drawing.Size(98, 17);
												this.label1.TabIndex = 3;
												this.label1.Text = "Student Name";
												// 
												// name
												// 
												this.name.Location = new System.Drawing.Point(121, 175);
												this.name.Name = "name";
												this.name.Size = new System.Drawing.Size(100, 22);
												this.name.TabIndex = 2;
												// 
												// addstudent
												// 
												this.addstudent.Location = new System.Drawing.Point(121, 232);
												this.addstudent.Name = "addstudent";
												this.addstudent.Size = new System.Drawing.Size(172, 105);
												this.addstudent.TabIndex = 4;
												this.addstudent.Text = "Add Student";
												this.addstudent.UseVisualStyleBackColor = true;
												this.addstudent.Click += new System.EventHandler(this.addstudent_Click);
												// 
												// studentDataGridView
												// 
												this.studentDataGridView.AllowUserToAddRows = false;
												this.studentDataGridView.AllowUserToDeleteRows = false;
												this.studentDataGridView.AllowUserToResizeColumns = false;
												this.studentDataGridView.AllowUserToResizeRows = false;
												this.studentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
												this.studentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.NameColumn});
												this.studentDataGridView.Location = new System.Drawing.Point(404, 72);
												this.studentDataGridView.Name = "studentDataGridView";
												this.studentDataGridView.RowHeadersWidth = 51;
												this.studentDataGridView.RowTemplate.Height = 24;
												this.studentDataGridView.Size = new System.Drawing.Size(384, 242);
												this.studentDataGridView.TabIndex = 5;
												// 
												// IDColumn
												// 
												this.IDColumn.HeaderText = "ID";
												this.IDColumn.MinimumWidth = 6;
												this.IDColumn.Name = "IDColumn";
												this.IDColumn.Width = 125;
												// 
												// NameColumn
												// 
												this.NameColumn.HeaderText = "Name";
												this.NameColumn.MinimumWidth = 6;
												this.NameColumn.Name = "NameColumn";
												this.NameColumn.Width = 125;
												// 
												// Form1
												// 
												this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
												this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
												this.ClientSize = new System.Drawing.Size(800, 450);
												this.Controls.Add(this.studentDataGridView);
												this.Controls.Add(this.addstudent);
												this.Controls.Add(this.label1);
												this.Controls.Add(this.name);
												this.Controls.Add(this.label_stu_id);
												this.Controls.Add(this.id);
												this.Name = "Form1";
												this.Text = "Hello World";
												this.Load += new System.EventHandler(this.Form1_Load);
												((System.ComponentModel.ISupportInitialize)(this.studentDataGridView)).EndInit();
												this.ResumeLayout(false);
												this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label_stu_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Button addstudent;
        private System.Windows.Forms.DataGridView studentDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
    }
}

