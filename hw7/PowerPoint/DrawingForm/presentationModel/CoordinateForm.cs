using System;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class CoordinateForm : Form
    {
        private Label _label1;
        private Label _label2;
        private Label _label3;
        private Label _label4;
        private TextBox _textBox1;
        private TextBox _textBox2;
        private TextBox _textBox3;
        private TextBox _textBox4;
        private Button _okBtn;
        private Button _cancelBtn;

        public string Input1
        {
            get 
            {
                return _textBox1.Text;
            }
        }

        public string Input2
        {
            get
            {
                return _textBox2.Text;
            }
        }

        public string Input3
        {
            get 
            {
                return _textBox3.Text;
            }
        }

        public string Input4
        {
            get
            {
                return _textBox4.Text;
            }
        }

        public CoordinateForm()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoordinateForm));
            this._textBox1 = new System.Windows.Forms.TextBox();
            this._textBox2 = new System.Windows.Forms.TextBox();
            this._textBox3 = new System.Windows.Forms.TextBox();
            this._textBox4 = new System.Windows.Forms.TextBox();
            this._label1 = new System.Windows.Forms.Label();
            this._label2 = new System.Windows.Forms.Label();
            this._label3 = new System.Windows.Forms.Label();
            this._label4 = new System.Windows.Forms.Label();
            this._okBtn = new System.Windows.Forms.Button();
            this._cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _textBox1
            // 
            this._textBox1.Location = new System.Drawing.Point(71, 84);
            this._textBox1.Name = "_textBox1";
            this._textBox1.Size = new System.Drawing.Size(100, 22);
            this._textBox1.TabIndex = 0;
            // 
            // _textBox2
            // 
            this._textBox2.Location = new System.Drawing.Point(248, 84);
            this._textBox2.Name = "_textBox2";
            this._textBox2.Size = new System.Drawing.Size(100, 22);
            this._textBox2.TabIndex = 1;
            // 
            // _textBox3
            // 
            this._textBox3.Location = new System.Drawing.Point(71, 154);
            this._textBox3.Name = "_textBox3";
            this._textBox3.Size = new System.Drawing.Size(100, 22);
            this._textBox3.TabIndex = 2;
            // 
            // _textBox4
            // 
            this._textBox4.Location = new System.Drawing.Point(248, 154);
            this._textBox4.Name = "_textBox4";
            this._textBox4.Size = new System.Drawing.Size(100, 22);
            this._textBox4.TabIndex = 3;
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.Location = new System.Drawing.Point(68, 65);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(90, 16);
            this._label1.TabIndex = 4;
            this._label1.Text = "左上角座標X";
            // 
            // _label2
            // 
            this._label2.AutoSize = true;
            this._label2.Location = new System.Drawing.Point(245, 65);
            this._label2.Name = "_label2";
            this._label2.Size = new System.Drawing.Size(91, 16);
            this._label2.TabIndex = 5;
            this._label2.Text = "左上角座標Y";
            // 
            // _label3
            // 
            this._label3.AutoSize = true;
            this._label3.Location = new System.Drawing.Point(68, 135);
            this._label3.Name = "_label3";
            this._label3.Size = new System.Drawing.Size(90, 16);
            this._label3.TabIndex = 6;
            this._label3.Text = "右下角座標X";
            // 
            // _label4
            // 
            this._label4.AutoSize = true;
            this._label4.Location = new System.Drawing.Point(245, 135);
            this._label4.Name = "_label4";
            this._label4.Size = new System.Drawing.Size(91, 16);
            this._label4.TabIndex = 7;
            this._label4.Text = "右下角座標Y";
            // 
            // _okBtn
            // 
            this._okBtn.Location = new System.Drawing.Point(71, 205);
            this._okBtn.Name = "_okBtn";
            this._okBtn.Size = new System.Drawing.Size(100, 37);
            this._okBtn.TabIndex = 8;
            this._okBtn.Text = "Ok";
            this._okBtn.UseVisualStyleBackColor = true;
            this._okBtn.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // _cancelBtn
            // 
            this._cancelBtn.Location = new System.Drawing.Point(248, 205);
            this._cancelBtn.Name = "_cancelBtn";
            this._cancelBtn.Size = new System.Drawing.Size(100, 37);
            this._cancelBtn.TabIndex = 9;
            this._cancelBtn.Text = "Cancel";
            this._cancelBtn.UseVisualStyleBackColor = true;
            this._cancelBtn.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CoordinateForm
            // 
            this.ClientSize = new System.Drawing.Size(418, 282);
            this.Controls.Add(this._cancelBtn);
            this.Controls.Add(this._okBtn);
            this.Controls.Add(this._label4);
            this.Controls.Add(this._label3);
            this.Controls.Add(this._label2);
            this.Controls.Add(this._label1);
            this.Controls.Add(this._textBox4);
            this.Controls.Add(this._textBox3);
            this.Controls.Add(this._textBox2);
            this.Controls.Add(this._textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CoordinateForm";
            this.Text = "Specify Coordinates";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
