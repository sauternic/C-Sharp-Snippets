using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Methode
{
    
    //Mit HP-Methode siehe Random_Serien_und_Doubletten und dort CDoubletten.cs
    public class CHP_Methode
    {
        //Fields
        //static double startwert = 0;
        static Random rnd = new Random();
        const int STELLEN = 9;
            
        
        
        //Random-Methode
        static void Main(string[] args)
        {
            bool flag = true;
            double vergleich = 0.0;
            double vergleich_Wert1_behalten = 0.0;
            int proz = 0;
            double Wert1 = 0;
            double Wert2 = 0;
            long durchlauf = 10000000000L;//
            //               1'0'000'000'000

            #region
            // Initalisieren mit Systemzeit und Milisekunden Priorisieren
            //Date d = new Date();
            //String str = String.valueOf(d.getTime());
            //str = "0." + str.substring(2, str.length());
            //startwert = Double.valueOf(str);
            //// Zusätliche Sicherheit, 10mal durch HP-Verfahren lassen!
            //for (int x = 0; x < 11; ++x)
            //{	
            //    CHP.hpMethode();
            //}
            #endregion

           
            for (long x = 1; x <= durchlauf; ++x)
            {
                // Progresspar
                if (x % 10000000 == 0)
                {
                    proz = (int)(x * 100 / durchlauf);
                    Console.WriteLine(proz + " %");

                }


                vergleich = rnd.NextDouble();
               


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
                        Console.WriteLine("Durchlauf: {0:#,0.###########################}\nStellen hinter Komma: {1}\n{2:#,0.###########################}\n{3:#,0.###########################}",x, STELLEN, vergleich_Wert1_behalten, vergleich);
                        Console.Read();
       
                        Environment.Exit(0);
                    }

                }
                flag = false;
            }//Ende for
        }//Ende Methode Main
    }//Ende class
}


