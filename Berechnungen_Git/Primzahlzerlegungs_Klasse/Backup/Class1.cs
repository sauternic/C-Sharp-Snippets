using System;
using System.Collections.Generic;

namespace Primzahlzerlegungs_Klasse
{
    class CPrimzahlzerlegung //Tipp: Einfach mit Ersetzen Funk. double in double Umwandeln für grosse Zahlen! :)
    {
        // Felder
        public readonly List<double> Erge = new List<double>();
        private double ausstieg = 1;
        private double eingabe;
        public static string Autor = "Copyright © Nicolas Sauter";
        
        
        //Konstruktor
        public CPrimzahlzerlegung(double eingabe)
        {
            double eingabeUnveraendert;
            double eingabeGeteilt;

            this.eingabe = eingabe;
            eingabeUnveraendert = eingabe;
            if (this.eingabe < 2)
                return;

            eingabeGeteilt = eingabe / 2;


                double Pruefung;
                double Pruefung2;
            for (double Zaehler = 2; Zaehler <= eingabeGeteilt; ++Zaehler)
            {
              xxx:   
                Pruefung = eingabe / Zaehler;
                Pruefung2 = Pruefung - Math.Floor(Pruefung);

                
                if (Pruefung2 == 0)
                {
                    Erge.Add(Zaehler);

                   this.ausstieg *= Zaehler;

                   if (this.ausstieg == eingabeUnveraendert)
                        return;

                    eingabe /= Zaehler;

                    goto xxx;
                }
            }
            Erge.Add(eingabeUnveraendert);
        }
    }      
}