﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Dziennik_nauczyciela_obiektowy
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //dodalem komentarz
            //specjalnie nowy komentarz do nowego projektu
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fStart());
        }
    }
}
