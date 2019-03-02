using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auto_C_Sharp
{
    class Program
    {
        static void Main()
        {
            CAuto Porsche = new CAuto(4, 3, 10, 7000, 3500, 220, 1300);


            Console.WriteLine("Tueren: {0}", Porsche.Tueren);
            Porsche.Tueren = 5;
            Console.WriteLine("Tueren: {0}", Porsche.Tueren);
            Console.WriteLine("Bar von Einspritzung: {0}", Porsche.Motor.Einspritzung.Bar);
            Console.WriteLine("Raeder: {0}", Porsche.Raeder);
            Console.WriteLine("PS: {0}", Porsche.Motor.PS);
            Console.WriteLine("Max Drehzahl: {0}", Porsche.Motor.Max_Drehzahl);
            Console.WriteLine("Opt Drehzahl: {0}", Porsche.Motor.Opt_Drehzahl);


            Console.ReadLine();
        }
    }
}
