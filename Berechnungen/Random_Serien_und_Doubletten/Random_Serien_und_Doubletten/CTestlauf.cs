using System;


namespace RandomSerienDoubletten
{
    class CTestlauf
    {
        

        static void ain(string[] args)
        {
            //Zufallsgenerator Random Instanzieren
            //Random CHP1 = new Random(357575435);
            CHP CHP1 = new CHP();
            CHP1.startwert = 0.500000000000001; //15Stellen hinter Komma
           

            //for (long l = 0; l < 1213350440; l++)
            //{
            //    CHP1.Next(0, 256);
            //}

            Console.WriteLine("Startwert: " + CHP1.startwert);
            
            for (int x = 1; x <= 60; x++)
            {

                CHP1.hpMethode();
                Console.WriteLine("Iteration: " + x + "  " + CHP1.startwert);
               
            }

            Console.Read();
        
        }
    
    
    }
}
