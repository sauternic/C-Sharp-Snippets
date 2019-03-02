using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Klassen_Für_Kompression
{
    partial class CKomprimieren
    {

        public static void Decompress_LZW()
        {

            //Dictionary Initalisieren:
            for (int x = 0; x < 256; ++x)
            {
                _dictioDekomp.Add(x, intByte_Hex(x));
            }
        
        
        }

    }
}
