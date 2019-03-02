using System;
using System.Security.Cryptography;

namespace RandomSerienDoubletten
{
    class CSerien2
    { 
        //Mit Auskommentieren für HP-Methode oder Random. :)
        public static void ain()
        {
            //Hier gewünschte Werte setzen! :)
            const int SERIE_VON = 0;
            const int SERIE_ANZAHL = 3;
            const long durchlaufe = 100000000L;//1Milliarde! :'@
            long durchlauf_Progress = 0;
            int zaehlen = 0;
            bool bol = false;
            int[] iArr = new int[SERIE_ANZAHL - 1];



            //##################  RNG #############################################
            //RNGCryptoServiceProvider RNG = new RNGCryptoServiceProvider();
            
            Console.WriteLine("Etwas Geduld bis ByteArray befüllt ist! :)");
            Byte[] by = CDoubletten.NSAlgorithmus(durchlaufe);
            
            
            //Byte[] by = new Byte[durchlaufe];
            //Console.WriteLine("Etwas Geduld bis ByteArray befüllt ist! :)");
           
            //RNG.GetBytes(by);
            //################## Ende  RNG #############################################



            durchlauf_Progress = durchlaufe / 1000;
            for (long x = 1; x <= durchlaufe; ++x)
            {
                // Progresspar
                if (x % durchlauf_Progress == 0)
                {
                    Console.WriteLine("Durchläufe: " + x.ToString("#,#"));
                }

               
              
                //%%%%%%%%%%%%%%%%%%%%%%%%%%%%% Serien Rausfiltern! :) %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

                if (by[x - 1] == SERIE_VON)
                {
                    bol = true;
                }
                else
                {
                    bol = false;
                    for (int y = 0; y < iArr.Length; ++y)
                    {
                        iArr[y] = 0;
                    }
                    zaehlen = 0;

                }
                if (bol)
                {
                    try
                    {
                        iArr[zaehlen] = by[x];
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Durchlauf: {0:#,0}\n{1} Serie von: {2}er", (x + 1), SERIE_ANZAHL, SERIE_VON);
                        Console.Read();

                        break;
                      
                    }
                    ++zaehlen;
                }
            }
            Console.Read();
        }
    }
}

