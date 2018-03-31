using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Library_Auto.Modules;
using Library_Auto.Crystal_Reports;


namespace Library_Auto
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
            Application.Run(new Login_02());
        }
    }
}