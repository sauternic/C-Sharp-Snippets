using System;

namespace NBerechnungen
{

    class CKugel
    {
        private double r;
        private double dichte;

        public CKugel(double r, double dichte)
        {
            this.r = r;
            this.dichte = dichte;
        }

        public double dichteRetour(double gew, double r)
        {
            return gew / (4 * Math.PI * Math.Pow(r, 3) / 3);
        }

        public double dichteRetour(double gew, double r, String cm)
        {
            return (gew / (4 * Math.PI * Math.Pow(r, 3) / 3)) / 1000000;
        }

        public double volumen()
        {
            return 4 * Math.PI * Math.Pow(r, 3) / 3;
        }

        public double volumen(String km)
        {
            return (4 * Math.PI * Math.Pow(r, 3) / 3) / 1000000000;
        }

        public double oberflaeche()
        {
            return 4 * Math.PI * Math.Pow(r, 2);
        }

        public double oberflaeche(String km)
        {
            return (4 * Math.PI * Math.Pow(r, 2)) / 1000000;
        }

        public double gewicht()
        {
            return 4 * Math.PI * Math.Pow(r, 3) / 3 * dichte;
        }

        public double gewicht(String to)
        {
            return (4 * Math.PI * Math.Pow(r, 3) / 3 * dichte) / 1000;
        }

    }

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