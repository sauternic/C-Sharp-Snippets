using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auto_C_Sharp
{
    class CAuto
    {
        int raeder;
        int tueren;
        int verbrauch;
        CMotor motor;//Eingebettetes Objekt!

        //Konstruktor
        public CAuto(int raeder, int tueren, int verbrauch, int maxDrehzahl, int opt_Drehzahl, int PS, int bar)
        {
            this.raeder = raeder;
            this.tueren = tueren;
            this.verbrauch = verbrauch;
            this.motor = new CMotor(maxDrehzahl, opt_Drehzahl, PS, bar);
        }




        //propertis
        public int Raeder { get { return raeder; } }
        public int Tueren { get { return tueren; } set { tueren = value; } }//Nur bei VBA kommt Tueren 2 mal vor!       
        public int Verbrauch { get { return verbrauch; } }
        public CMotor Motor { get { return motor; } }


    }
}