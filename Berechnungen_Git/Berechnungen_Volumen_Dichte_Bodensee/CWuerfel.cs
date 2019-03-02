using System;

namespace NBerechnungen
{

    class CWuerfel
    {
        private double x;
        private double y;
        private double z;
        private double dichte;


        public CWuerfel(double x, double y, double z, double dichte)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.dichte = dichte;
        }

        public CWuerfel(double a, double dichte)
        {
            this.x = a;
            this.y = a;
            this.z = a;
            this.dichte = dichte;
        }

        public double volumen()
        {
            return x * y * z;
        }

        public double volumen(String dm)
        {
            if ("dm3" == dm)
                return x * y * z * 1000;
            else
                return x * y * z * 1000000;
        }

        public double gewicht()
        {
            return x * y * z * dichte;
        }

        public double gewicht(String ge)
        {
            if ("g" == ge)
                return x * y * z * dichte * 1000;
            else
                return x * y * z * dichte / 1000;
        }

    }
}

//Erklärung---Wuerfel-Klasse---------------------

//Länge(en) in m, Dichte in kg/m3
//Würfel obj(double, double)
//Würfel obj(double, double, double, double)

//volumen() in m3
//volumen("dm3") in dm3
//volumen("cm3") in cm3

//gewicht() in kg
//gewicht("g") in g
//gewicht("t") in tonnen
//-----------------------------------------------