using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Klassen_Für_Kompression
{
    class Program
    {
        static void Main(string[] args)
        { 
            byte[] byArrErg = null;
            
            
            using (FileStream File_Stream = new FileStream("C:\\Ausgabe\\LZW_Kurz.txt", FileMode.Open))
            {
                byArrErg = CKomprimieren.Compress_LZW(File_Stream);
            }
        
             
            using (FileStream dateiStream = new FileStream("C:\\Ausgabe\\LZW_Kurz_Vers.txt", FileMode.Create))
            {
                // In den Datei-Stream Schreiben.
                dateiStream.Write(byArrErg, 0, byArrErg.Length);
            }    
        }
    }
}
