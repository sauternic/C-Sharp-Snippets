using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Methode
{
    class CDebuggen
    {

        static void Main(string[] args)
        {
            //Initalisieren mit Systemzeit und Ticks Priorisieren
            //DateTime now = DateTime.Now;
            //long l = now.Ticks;
            //String str = Convert.ToString(l);
            //str = "0." + str;

            CHP cp = new CHP();
            cp.startwert = 1;

            for (int x = 0; x < 11; ++x)
            {	
               Console.WriteLine(cp.hpMethode());
            }
            Console.Read();
        
        }
    
    
    }
}
