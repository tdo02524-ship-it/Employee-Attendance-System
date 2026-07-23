using System;
using System.Windows.Forms;

namespace ChamCongRFID
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());

            //Application.Run(new FormDashboard());
        }
    }
}