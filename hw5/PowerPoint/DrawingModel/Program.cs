using System;
using System.Windows.Forms;

namespace DrawingModel
{
    static class Program
    {
        /// <summary>
        /// application main entry point
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormModel());
        }
    }
}
