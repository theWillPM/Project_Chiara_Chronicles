using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChiaraChronicles
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        internal static string CurrentScreen = "Main Menu";
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show intro BEFORE the message loop starts
            using (var intro = new IntroForm())
            {
                intro.ShowDialog();   // blocks until intro closes
            }

            // Now start the real application loop on MainMenu
            Application.Run(new MainMenu());
        }
    }
}
