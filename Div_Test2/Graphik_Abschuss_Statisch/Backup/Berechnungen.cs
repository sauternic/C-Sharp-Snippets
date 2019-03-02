using System;
using System.Drawing;
using System.Windows.Forms;

using System.Threading;

namespace Graphik_Abschuss
{
    //Nur 2 statische Methoden:
    static class CSimu
    {
        static double a; 
        static double Ges;
        static double V2 = 0;
        static double s = 0;
        static double diff = 0; 
        
        public static void Simu()
        {    
            try
            {
                a = Convert.ToDouble(Program.OForm1.textBox1.Text);
                Ges = Convert.ToDouble(Program.OForm1.textBox2.Text);         
            
                berechnen();
            
            } catch (Exception) {}
        }

        public static void berechnen()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            
            Program.OForm1.button1.Enabled = false;//Berechnen
            for (double t = 0.01; t < 50000; t += 0.01)
            {
                V2 = a * t; //Berechnung in m/s
                s = (a * t * t) / 2; //Berechnung von Strecke
                diff = Ges - (V2 * 3.6);
                if (diff < 0) { diff = 0; }

                Cabfuellen.abfuellen(string.Format("{0:#,0.00}", t), string.Format("{0:#,0.00}", s), string.Format("{0:#,0}", V2 * 3.6));
                 
                //Console.WriteLine(" Sek:    Km/h: {1:#,0.00}   Km/h: {2:#,0.00}      Meter: {3:#,0.00}", x, V2 * 3.6, diff, s);
                if (diff == 0) break;
            }
            
            Program.OForm1.button2.Enabled = true;//Start
        }
    }
}