﻿using MarkTracker.testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkTracker {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new markTrackerForm());

            /* Test the database */
            //DBTester dbtester = new DBTester();
            //dbtester.Run();
        }
    }
}
