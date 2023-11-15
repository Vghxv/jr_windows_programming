using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form : System.Windows.Forms.Form
    {
        Model _model;
        public Form()
        {
            InitializeComponent();
            _model = new Model();
        }

        // called when clear button is clocked
        private void ClickClearButton(object sender, EventArgs e)
        {
            _model.Clear();
            _bufferBox.Text = _model.GetBuffer();
        }

        // called when clear entry button is clicked 
        private void ClickClearEntryButton(object sender, EventArgs e)
        {
            _model.ClearEntry();
            _bufferBox.Text = _model.GetBuffer();
        }

        // called when any number button is clicked
        private void ClickNumberButton(object sender, EventArgs e)
        {
            _model.ClearEntryByDelay();
            _model.ClickNumber(sender.ToString()[sender.ToString().Length - 1]);
            _bufferBox.Text = _model.GetBuffer();
            _model.SetDelay(false);
        }
        
        //  called when equal button is clicked
        private void ClickEqualButton(object sender, EventArgs e)
        {
            _model.ClickEqual();
            _bufferBox.Text = _model.GetResult();
        }

        // called when operation button is clicked
        private void ClickOperationButton(object sender, EventArgs e)
        {
            _model.ClickOperator(sender.ToString()[sender.ToString().Length - 1]);
            _bufferBox.Text = _model.GetResult();
        }

        // click dot button
								private void ClickDotButton(object sender, EventArgs e)
								{
            _model.ClickDotButton();
            _bufferBox.Text = _model.GetBuffer();
								}
				}
}
