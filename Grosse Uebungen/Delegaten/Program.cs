using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegaten
{
    class CDemo
    {
        internal delegate void Ueberschrift();// Definition des Delegaten
        
        int feld1;
        int feld2;
        internal Ueberschrift Ueber; // Delegaten-Variable

        internal CDemo(int arg1, int arg2)
        {
            feld1 = arg1;
            feld2 = arg2;
        }
        
        internal void Ausgeben()
        {
            if (Ueber != null)
                Ueber();
            
            Console.WriteLine(" feld1: {0}",feld1);
            Console.WriteLine(" feld2: {0}",feld2);
        }
    }
 
    class Program
    {
        static void TitelAusgeben()
        {
            Console.WriteLine();
            Console.WriteLine("Felder des Objekts:\n");
        }
 
        static void Main()
        {
            CDemo obj1 = new CDemo(1, 100);
            obj1.Ausgeben();

            // Delegaten erzeugen
            obj1.Ueber = new CDemo.Ueberschrift(TitelAusgeben);
            obj1.Ausgeben();

            
            
            
            
            
        
       }
    }
}
