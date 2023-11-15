using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {

        private const string DELETE = "刪除";
        private const string SHAPE = "形狀";
        private const string INFO = "資訊";
        private const string MESSAGE = "請選擇形狀";
        private const int SLIDE_BUTTON_SIZE = 100;
        Model _model;

        public Form1(Model model)
        {
            _model = model;
            InitializeComponent();
            InitializeModelInfo();
            InitializeSlideInfo();
        }

        //	private void InitializeSildeInfo()
        private void InitializeSlideInfo()
        {
            DataGridViewRow slideButton = new DataGridViewRow();
            slideButton.Cells.Add(new DataGridViewButtonCell());
            _slideInfo.Rows.Add(slideButton);
            _slideInfo.Rows[0].Height = SLIDE_BUTTON_SIZE;
            _slideInfo.Rows[1].Height = SLIDE_BUTTON_SIZE;
        }

        // private void _buttonAdd_Click(object sender, EventArgs e)
        private void InitializeModelInfo()
        {
            DataGridViewButtonColumn modelButton = new DataGridViewButtonColumn();
            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            modelButton.HeaderText = DELETE;
            modelButton.Name = DELETE;
            modelButton.UseColumnTextForButtonValue = true;
            modelButton.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column1.HeaderText = SHAPE;
            column1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column2.HeaderText = INFO;
            _modelInfo.Columns.Add(modelButton);
            _modelInfo.Columns.Add(column1);
            _modelInfo.Columns.Add(column2);
        }

        // private void _buttonAdd_Click(object sender, EventArgs e)
        private void AddRowToDataGridView(string name, string nameChinese, string info)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.Cells.Add(new DataGridViewButtonCell());
            row.Cells.Add(new DataGridViewTextBoxCell
            {
                            Value = nameChinese
            });
            row.Cells.Add(new DataGridViewTextBoxCell
            {
                            Value = info
            });
            row.Cells[0].Value = DELETE;
            row.Cells[1].Tag = name;
            _modelInfo.Rows.Add(row);
        }

        // private void _buttonAdd_Click(object sender, EventArgs e)
        private void ModelInfoCellDeleteClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == _modelInfo.Columns[DELETE].Index && e.RowIndex >= 0)
            {
                _modelInfo.Rows.Remove(_modelInfo.Rows[e.RowIndex]);
            }
        }

        // private void _buttonAdd_Click(object sender, EventArgs e)
        private void ButtonAddClick(object sender, EventArgs e)
        {
            if (_shapeOption.Text == "")
            {
                MessageBox.Show(MESSAGE);
                return;
            }

            _model.AddShape(_shapeOption.Text);
            Shape shape = _model.GetLastShape();
            AddRowToDataGridView(shape.GetShapeName(), shape.GetShapeNameChinese(), shape.GetInfo());
        }
    }
}
