using System;


namespace NBerechnungen
{
    class CMain
    {

        public static int Main()
        {

            while (true)//Programm immer wieder starten!
            {

                char x; //Lokale Deklaration ausserhalb try Block.

                Console.WriteLine("\n\tCopyright \u00A9 2009 Nicolas Sauter ");
                Console.WriteLine("\n\tTaste <Enter> Neustart!\n");
                Console.WriteLine("\tTaste <1> Kugel\n");
                Console.WriteLine("\tTaste <2> Quadratischer Würfel\n");
                Console.WriteLine("\tTaste <3> Ungleicher Würfel\n");
                Console.WriteLine("\tTaste <4> Bodensee-Rechnung\n");
                Console.Write("\tTaste <b> Beenden\t\t");

                try
                {    //Eingabe-Fehler werden sofort Abgefangen!!!
                    x = Convert.ToChar(Console.ReadLine());
                }
                catch (Exception) { Console.WriteLine("\n\n\tNur ein Zeichen Eingeben!\n\n"); continue; }

                switch (x)
                {
                    case '1': CFunktionen.KugelProgramm();
                        break;
                    case '2': CFunktionen.WuerfelProgramm();
                        break;
                    case '3': CFunktionen.WuerfelProgrammUngleich();
                        break;
                    case '4': CFunktionen.Bodensee();
                        break;
                    case 'b': return 0;
                    default: Console.Write("\n\n"); continue;
                }

            }//Ende while Schleife

        }//Ende int main

    }

}