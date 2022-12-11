using System.Windows.Forms;
using WindowsFormsApp1.Entities;
using WindowsFormsApp1.Forms;
using WindowsFormsApp1.Forms.Students;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}