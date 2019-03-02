using System;
using System.Collections.Generic;
using System.IO;

namespace PackAlgorithums
{
    class Program
    {


        public static void ain()
        {
            Stream fs = new FileStream("C:\\Ausgabe\\StreamDatei.txt", FileMode.Open);

            CHuffman LZ = new CHuffman(fs);      
        }
    }
}
