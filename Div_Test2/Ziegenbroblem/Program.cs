using System;

namespace Ziegenbroblem
{
    class Program
    {
        static void Main(string[] args)
        {

            int x = 0;
            int Auto = 0;
            int Auswahl = 0;
            int getroffen = 0;

            Class1 zufall1 = new Class1();
            zufall1.startwert = 0.5;
            Class1 zufall2 = new Class1();
            zufall2.startwert = 0.7;
            
            
            for (; x < 10000000; ++x)
            {
                Auto = (int)(zufall1.hpMethode() * 3) + 1;

                Auswahl = (int)(zufall2.hpMethode() * 3) + 1;

                //Ohne Wechseln
                if (Auswahl == Auto)
                    ++getroffen;
    
            
            }
            Console.WriteLine("Durchläufe: {0:#,0}\nGetroffen: {1:#,0}", x, getroffen);


            Console.ReadLine();
        
        
        }   
    }
}
