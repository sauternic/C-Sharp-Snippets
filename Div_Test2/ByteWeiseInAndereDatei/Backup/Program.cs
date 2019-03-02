using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ByteWeiseInAndereDatei
{
    class Program
    {
        static void Main(string[] args)
        {
            byte byt = 0;
            long laenge;
             
            // C:\\Ordner\\Text.txt
            //C:\\Laufwerk-D\\Grosse Downloads\\mthttm\\TestGeschnitten.mp4"
            
            FileStream datei = new FileStream("C:\\Ordner\\Test.wmv", FileMode.Open);
            FileStream dateiZiel = new FileStream("C:\\Ordner\\TestGeschnitten.wmv", FileMode.Create);
            
            BinaryReader r = new BinaryReader(datei);
            BinaryWriter wZiel = new BinaryWriter(dateiZiel);

            laenge = datei.Length;
            for (int i = 0; i < laenge; ++i)
            {
                byt = r.ReadByte();
                if (i > 250000000 && i < 149490000) byt = 1;// Beachte, am Schluss werden wieder die Orginalbytes Gesetzt! ;)
                //if (i > 850000000 && i < 993000000) byt = 1;// Ausschneiden2
                wZiel.Write(byt);
            }
            
            //Alles Schliessen! ;)
            r.Close();
            wZiel.Close();
            datei.Close();
            dateiZiel.Close();
        }
    }
}