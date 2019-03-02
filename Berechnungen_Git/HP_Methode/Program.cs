using System;

namespace HP_Methode
{
    public class CHP_Methode
    {
        const int STELLEN = 7;
        
        public static double startwert;
        
        
        
        static void ain(string[] args)
		{	
		    bool flag = true;
		    double vergleich;
		    double vergleich_Wert1_behalten = 0.0;
		    int proz;
		    double Wert1;
		    double Wert2;
		    long durchlauf = 10000000000L;// 00000000L;// Zehn-Miliarden

            //Initalisieren mit Systemzeit und Ticks Priorisieren
            DateTime now = DateTime.Now;
            long l = now.Ticks;
            String str = Convert.ToString(l);
            str = "0." + str;
            startwert = Convert.ToDouble(str);
            for (int x = 0; x < 1451; ++x)
            {
                CHP.hpMethode();
            }

		    for (long x = 1; x <= durchlauf; ++x)
		    {
			    // Progresspar
			    if (x % 10000000 == 0)
			    {
				    proz = (int) (x * 100 / durchlauf);
				    Console.WriteLine(proz + " %");

			    }
	
				
			    vergleich = CHP.hpMethode();
				

			    // Schauen ob sich der Logarithmus wiederholt?? :/
			    if (flag == true)
			    {
				    vergleich_Wert1_behalten = vergleich;
			    }

			    if (flag == false)
			    {
                    Wert1 = Math.Round(vergleich_Wert1_behalten, STELLEN);
                    Wert2 = Math.Round(vergleich, STELLEN);
				
				
				    if (Wert1 == Wert2)
				    {
                        Console.WriteLine("Durchlauf: {0:#,0.###########################}\nStellen hinter Komma: {1}\n{2:#,0.###########################}\n{3:#,0.###########################}", x, STELLEN, vergleich_Wert1_behalten, vergleich);

					    Environment.Exit(0);
				    }
					
			    }
			    flag = false;
		    }//Ende for
	    }//Ende Methode Main
    }//Ende class
}


