﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MultiControl
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createNew;
            using (System.Threading.Mutex m = new System.Threading.Mutex(true, Application.ProductName, out createNew))
            {
                if (createNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainWindow());
                }
                else
                {
                    MessageBox.Show("该程序己启动");
                }
            }
        }
    }
}
