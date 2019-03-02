using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Graphik_Abschuss
{
    static class Program
    {
        public static Form1 OForm1; //Deklaration
        
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
    }
}
