using System;

namespace RandomSerienDoubletten
{
    class CSerien
    {

        
        //Mit Auskommentieren für HP-Methode oder Random. :)
        static void ain(string[] args)
        {
            //Hier gewünschte Werte setzen! :)
            const int SERIE_VON = 255;
            const int SERIE_ANZAHL = 4;
            const long durchlaufe = 10000000000L;
            int zufall_1_3;
            int zaehlen = 0;
            bool bol = false;
            int[] iArr = new int[SERIE_ANZAHL - 1];
            
            Random Zufall = new Random(357575435);
            //CHP Zufall = new CHP();
            //Zufall.startwert = 1;
            //*******************************************************            
     
            for (long x = 0; x < durchlaufe; ++x)
            {
                // Progresspar
                if (x % 10000000 == 0)
                {

                    Console.WriteLine(((x * 100) / durchlaufe) + " %");
                }

                zufall_1_3 = Zufall.Next(0,256);
                //zufall_1_3 = (int)(Zufall.hpMethode() * 256);

                //%%%%%%%%%%%%%%%%%%%%%%%%%%%%% Serien Rausfiltern! :) %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

                if (zufall_1_3 == SERIE_VON)
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
                        iArr[zaehlen] = zufall_1_3;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Durchlauf: {0:#,0}\n{1} Serie von: {2}er", (x + 1), SERIE_ANZAHL, SERIE_VON);
                        Console.Read();
                        
                        Environment.Exit(0);
                    }
                    ++zaehlen;
                }

                //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%               

            }
        }
    }
}

