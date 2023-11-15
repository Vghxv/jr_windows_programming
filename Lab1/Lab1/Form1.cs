using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            studentDataGridView.Rows.Add("12", "studentname");
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Action";
            buttonColumn.Text = "Click Me";
            buttonColumn.UseColumnTextForButtonValue = true;

            // Add the button column to the DataGridView
            studentDataGridView.Columns.Add(buttonColumn);

            // Add some sample data to the DataGridView
            studentDataGridView.Rows.Add("Row 1", "Data 1", "Data 2");
            studentDataGridView.Rows.Add("Row 2", "Data 3", "Data 4");

            // Handle the button click event
            studentDataGridView.CellContentClick += DataGridView1_CellContentClick;
        }

								private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
								{
												throw new NotImplementedException();
								}

								private void addstudent_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello, " + id.Text + " " + name.Text);
            if(id.Text == "")
            {
                MessageBox.Show("please enter ID.");
            }
            else if(name.Text == "")
            {
                MessageBox.Show("please enter Name.");
            }
            else
            {
                studentDataGridView.Rows.Add(id.Text, name.Text);
            }

        }

								private void Form1_Load(object sender, EventArgs e)
								{

								}
				}
}
