using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingForm
{
    static class Program
    {
        
        /// <summary>
        /// this is the main entry point for the application
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Model model = new Model();
            FormPresentationModel presentationModel = new FormPresentationModel(model);
            Application.Run(new MainForm(presentationModel));
        }
    }
}
