using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SLeek
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SleekInstance instance = new SleekInstance(true);
            Application.Run(instance.MainForm);
            instance = null;
        }
    }
}