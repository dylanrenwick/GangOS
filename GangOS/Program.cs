using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using GangOS.Common;

namespace GangOS
{
    static class Program
    {
        private static Form mainForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GangOSClient.CheckDebug();

            GangOSClient.Initialize();

            Application.Run(mainForm = new MainWindow());
        }
    }
}
