using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackAlgorithums
{
    class CBibliothek
    {
        static void ain(string[] args)
        {

            //Bibliothek(struct) Erzeugen und Initialisieren! :)
            SBibliothek[] Arr_SBiblio = new SBibliothek[4096];
            for (int x = 0; x < Arr_SBiblio.Length; ++x)
            {  
                if (x < 256)
                    Arr_SBiblio[x].str += (char)x;
                else
                    Arr_SBiblio[x].str = "";

                Arr_SBiblio[x].wert = x;
            }

            //TestEinträge:
            Arr_SBiblio[256].str = "\u0004\tb";
            Arr_SBiblio[257].str = "bc";
            Arr_SBiblio[258].str = "de";
            
            
            
            //suchen in Bibliothek
            int i = 255;//n Aus Binärem 12bit Code extrahiert!! ;)
            string str = Arr_SBiblio[i].str;
        
        
            //suchen nach Zeichenfolgen
            // Z.B. beim Komprimieren
            int index = 0;
            for (index = 256; index < Arr_SBiblio.Length; ++index)
            {
                if (Arr_SBiblio[index].str.Equals("\u0004\tb"))
                    break;
            }

            int Ergebnis = index;
        
        
        
        
        }


        struct SBibliothek
        {
            public string str { get; set; }
            public int wert { get; set; }
        }  
    
    
    }
    
    
}
