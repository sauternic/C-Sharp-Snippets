using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace Graphik_Abschuss
{
    static class Program
    {
      
        public static Form1 OForm1; //Deklaration(field)

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
//********************Haubteinstieg!!*****************************************************        
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            OForm1 = new Form1();

            Application.Run(OForm1);
        }
//********************Ende_Haubteinstieg!!************************************************       
    }
}
