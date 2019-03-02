using System;

namespace Primzahlzerlegungs_Klasse
{
    class Program_Testen
    {
        static void Main(string[] args)
        {
            CPrimzahlzerlegung obj = new CPrimzahlzerlegung(100);

            foreach (double ausg in obj.Erge)
                Console.WriteLine(ausg);

            Console.WriteLine("\n" + CPrimzahlzerlegung.Autor);


            //134525683
            //100000000000367
            //13452568341

            Console.Read();
        }
    }
}
