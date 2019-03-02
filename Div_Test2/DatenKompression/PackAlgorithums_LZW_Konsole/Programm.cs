using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PackAlgorithums
{
    class Programm
    {

        //public static void Main()
        //{

        //    FileStream FileStream1 = new FileStream("C:\\Ausgabe\\Anleitung.pdf", FileMode.Open);
        //    CLZW_ByteBasiert LZW = new CLZW_ByteBasiert(FileStream1);

        //    File.WriteAllBytes("C:\\Ausgabe\\Erg_Anleitung.pdf", LZW.ausbabe_byarr);
        
        //}

        public static void Main()
        {

            FileStream FileStream1 = new FileStream("C:\\Ausgabe\\LZW_Lang.txt", FileMode.Open);
            CLZW_TextBasiert LZW = new CLZW_TextBasiert(FileStream1);

            File.WriteAllText("C:\\Ausgabe\\Erg_LZW_Text.txt", LZW.ausgabe_str);

            
            
            
            
            
            //Debuggen
            StreamWriter SW = new StreamWriter("C:\\Ausgabe\\Debuggen.txt");

            foreach (KeyValuePair<string, int> entry in LZW.dictio_komp)
                SW.WriteLine(entry.Value + "   " + entry.Key);

            SW.Close();
            
        }
    
    }
}
