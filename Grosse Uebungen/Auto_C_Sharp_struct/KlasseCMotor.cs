using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auto_C_Sharp
{
    class CMotor
    {
        int ps;
        int max_Drehzahl;
        int opt_Drehzahl;
        CEinspritzung einspritzung;//Eingebettetes Objekt!	

        //Konstruktor
        public CMotor(int max_Drehzahl, int opt_Drehzahl, int ps, int bar)
        {
            this.ps = ps;
            this.max_Drehzahl = max_Drehzahl;
            this.opt_Drehzahl = opt_Drehzahl;
            this.einspritzung = new CEinspritzung(bar);
        }



        //propertis
        public int PS { get { return ps; } }
        public int Max_Drehzahl { get { return max_Drehzahl; } }
        public int Opt_Drehzahl { get { return opt_Drehzahl; } }
        public CEinspritzung Einspritzung { get { return einspritzung; } }

    }
}