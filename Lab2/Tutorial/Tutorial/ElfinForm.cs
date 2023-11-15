using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
namespace Tutorial
{
    class ElfinForm : Form
    {
        protected int WINDOW_WIDTH = 400;
        protected int WINDOW_HEIGHT = 400;
        protected int BALL_SIZE = 50;
        public ElfinForm()
        {
            SetClientSizeCore(WINDOW_WIDTH, WINDOW_HEIGHT);
            BackColor = Color.Black;
            Text = "Elfin";
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            // Three blue blocks 
            g.FillRectangle(Brushes.Blue, 0, 0, 150, 100);
            g.FillRectangle(Brushes.Blue, 0, 250, 150, 150);
            g.FillRectangle(Brushes.Blue, 300, 0, 100, 275);
            // The elfin 
            g.FillPie(Brushes.Yellow, 15, 115, 120, 120, 30.0f, 300.0f);
            g.FillEllipse(Brushes.Black, 75, 130, 20, 20);
            // Five balls 
            g.FillEllipse(Brushes.GreenYellow, 200, 25, BALL_SIZE, BALL_SIZE);
            g.FillEllipse(Brushes.GreenYellow, 200, 125, BALL_SIZE, BALL_SIZE);
            g.FillEllipse(Brushes.GreenYellow, 200, 225, BALL_SIZE, BALL_SIZE);
            g.FillEllipse(Brushes.GreenYellow, 200, 325, BALL_SIZE, BALL_SIZE);
            g.FillEllipse(Brushes.GreenYellow, 300, 325, BALL_SIZE, BALL_SIZE);
        }
    }
}