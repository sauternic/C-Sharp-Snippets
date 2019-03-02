using System;
using System.Security.Cryptography;

namespace Random_Serien_und_Doubletten
{
    class Debuggen
    {
        static void ain(string[] args)
        {

            RNGCryptoServiceProvider RNG = new RNGCryptoServiceProvider();

            Byte[] by = new Byte[1000];

            
            RNG.GetBytes(by);

            foreach (int i in by)
                Console.WriteLine(i);
        }

    
    }
}
