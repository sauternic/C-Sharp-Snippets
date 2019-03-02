using System;
using System.Collections.Generic;
using System.Text;

namespace RandomSerienDoubletten
{
    class CMainAufruf
    {
        public static void ain()
        {
            byte[] iArr = CDoubletten.NSAlgorithmus(10000);

            foreach (byte by in iArr)
            {
                Console.WriteLine(by);

            }
            Console.Read();
        }
    }
}
