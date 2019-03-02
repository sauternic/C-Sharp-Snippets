using System;


namespace OnTimePad
{
    class CHP_Testen
    {
        private static double startwert = 0;


        static void Main(string[] args)
        {
            Console.Write("Startwert Eingeben: ");
            startwert = Convert.ToDouble(Console.ReadLine());


            for (int x = 0; x < 20; x++)
            {
                Console.WriteLine(HP_Metode());
            }
            Console.Read();
        
        }

        //HP-Methode! :)
        private static double HP_Metode()
        {

            startwert += Math.PI;
            startwert = Math.Pow(startwert, 8);
            startwert -= Math.Floor(startwert);
            return startwert;
        }
    }
}
