using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP282A2
{
    internal static class Program
    {
     
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //try { Application.Run(new MainWindow()); }
            //catch (Exception e) { MessageBox.Show(e.Message); }
            Application.Run(new MainWindow());

        }
    }
}
