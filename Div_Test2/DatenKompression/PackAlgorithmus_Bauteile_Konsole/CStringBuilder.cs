using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackAlgorithmus_Bauteile_Konsole
{
    class CStringBuilder
    {
        static StringBuilder eingabe = new StringBuilder();
       

        static void ain()
        {

            eingabe.Append("HalloNicolas");

            eingabe.Remove(0, eingabe.Length);
           
            
            
            StringBuilder zeichen = new StringBuilder();
            StringBuilder frase = new StringBuilder();

            zeichen.Append(eingabe[0]);
            zeichen.Append(eingabe [1]);
        
        
        }
    
    
    }
}
