using System;

namespace NBerechnungen
{
    static class CFunktionen
    {

        public static void KugelProgramm()
        {
            double x = 0;
            double y = 0;
            double kk = 0;
            double rr = 0;

            try
            {
                Console.Write("\n Bitte Radius der Kugel in Meter Eingeben: ");
                x = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                Console.Write(" Bitte Dichte des Materials in kg/m3 Eingeben: ");
                y = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.Write(" Separate Berechnung:\n\n Bitte Gewicht der Kugel X in kg Eingeben: ");
                kk = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                Console.Write(" Bitte Radius der Kugel X in Meter Eingeben: ");
                rr = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
            catch (Exception) { Console.WriteLine("\n\nFehler!\n\n"); }


            //Instanzieren!!
            CKugel oKugel = new CKugel(x, y);


            Console.WriteLine("\tVolumen in m3: " + oKugel.volumen());
            Console.WriteLine();
            Console.WriteLine("\tVolumen in km3: " + oKugel.volumen("km3"));
            Console.WriteLine();
            Console.WriteLine("\tOberfläche in m2: " + oKugel.oberflaeche());
            Console.WriteLine();
            Console.WriteLine("\tOberfläche in km2: " + oKugel.oberflaeche("km2"));
            Console.WriteLine();
            Console.WriteLine("\tGewicht in kg: " + oKugel.gewicht());
            Console.WriteLine();
            Console.WriteLine("\tGewicht in Tonnen: " + oKugel.gewicht("tonnen"));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\tSeparat: Dichte von X in kg/m3: " + oKugel.dichteRetour(kk, rr));
            Console.WriteLine();
            Console.WriteLine("\tSeparat: Dichte von X in kg/cm3: " + oKugel.dichteRetour(kk, rr, "cm3"));
            Console.WriteLine();
            Console.ReadLine();
        }

        //Erklärung---Kugel-Klasse------------------------

        //Radius in m, Dichte in kg/m3
        //Kugel(double, double)

        //Gewicht in kg, radius in Meter
        //static dichteRetour(double, double)
        //static dichteRetour(double, double, String)in kg/cm3

        //Kugel volumen() in m3  
        //Kugel volumen("km3") in km3  

        //Kugel oberflaeche() in m2  
        //Kugel oberflaeche("km2") in m2  

        //Kugel gewicht() in kg
        //Kugel gewicht("tonnen") in tonnen


        //------------------------------------------------


        
        public static void Bodensee()
        {
            double a = 0;
            double b = 0;
            double c = 0;
            double x = 0;

            Console.Write("\n\n Radius der Kugel in Meter Eingeben: ");
            c = Convert.ToDouble(Console.ReadLine());

            Console.Write("\n\n Segment-Strecke in Meter Eingeben: ");
            a = Convert.ToDouble(Console.ReadLine());

            a = a / 2;

            b = Math.Sqrt(c * c - a * a);
            x = c - b;

            Console.WriteLine("\n Die Eintauchtiefe der Geraden ist {0}Meter", x);
            Console.WriteLine(" Die Eintauchtiefe der Geraden ist {0}cm", x * 100);
            Console.WriteLine(" Die Eintauchtiefe der Geraden ist {0}mm", x * 1000);

            Console.ReadLine();
        }


        
        public static void WuerfelProgrammUngleich()
        {
            double x = 0;
            double y = 0;
            double z = 0;
            double d = 0;
            try
            {
                Console.Write("\n Bitte Breite Eingeben: ");
                x = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                Console.Write("\n Bitte Länge Eingeben: ");
                y = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                Console.Write("\n Bitte Höhe Eingeben: ");
                z = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                Console.Write(" Bitte Gewicht des Materials in kg/m3 Eigeben: ");
                d = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception) { Console.WriteLine("\n\nFehler!\n\n"); }


            //Instanzieren, nur lokal in methode gültig!
            CWuerfel oWuerfel = new CWuerfel(x, y, z, d);


            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("\tvolumen in cm3: " + oWuerfel.volumen("cm3"));
            Console.WriteLine();
            Console.WriteLine("\tvolumen in dm3: " + oWuerfel.volumen("dm3"));
            Console.WriteLine();
            Console.WriteLine("\tvolumen in m3: " + oWuerfel.volumen());
            Console.WriteLine();
            Console.WriteLine("\tgewicht in g: " + oWuerfel.gewicht("g"));
            Console.WriteLine();
            Console.WriteLine("\tgewicht in kg: " + oWuerfel.gewicht());
            Console.WriteLine();
            Console.WriteLine("\tgewicht in Tonnen: " + oWuerfel.gewicht("t"));
            Console.ReadLine();
        }


        //Erklärung---Wuerfel-Klasse---------------------

        //Länge(en) in m, Dichte in kg/m3
        //Würfel obj(a,dichte)
        //Würfel obj(x,y,z,dichte)

        //volumen() in m3
        //volumen("dm3") in dm3
        //volumen("cm3") in cm3

        //gewicht() in kg
        //gewicht("g") in g
        //gewicht("t") in tonnen
        //-----------------------------------------------


       
        public static void WuerfelProgramm()
        {
            double x = 0;
            double y = 0;
            try
            {
                Console.Write("\n Bitte Seitenlänge in Meter eines quadratischen Würfels Eingeben: ");
                x = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                Console.Write(" Bitte Gewicht des Materials in kg/m3 Eigeben: ");
                y = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception) { Console.WriteLine("\n\nFehler!\n\n"); }



            CWuerfel oWuerfel = new CWuerfel(x, y);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("\tvolumen in cm3: " + oWuerfel.volumen("cm3"));
            Console.WriteLine();
            Console.WriteLine("\tvolumen in dm3: " + oWuerfel.volumen("dm3"));
            Console.WriteLine();
            Console.WriteLine("\tvolumen in m3: " + oWuerfel.volumen());
            Console.WriteLine();
            Console.WriteLine("\tgewicht in g: " + oWuerfel.gewicht("g"));
            Console.WriteLine();
            Console.WriteLine("\tgewicht in kg: " + oWuerfel.gewicht());
            Console.WriteLine();
            Console.WriteLine("\tgewicht in Tonnen: " + oWuerfel.gewicht("t"));
            Console.ReadLine();
        }

        //Erklärung---Wuerfel-Klasse---------------------

        //Länge(en) in m, Dichte in kg/m3
        //Würfel obj(a,dichte)
        //Würfel obj(x,y,z,dichte)

        //volumen() in m3
        //volumen("dm3") in dm3
        //volumen("cm3") in cm3

        //gewicht() in kg
        //gewicht("g") in g
        //gewicht("t") in tonnen
        //-----------------------------------------------


    }


}

