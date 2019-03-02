using System;
using System.Drawing;
using System.Windows.Forms;

using System.Threading;

namespace Graphik_Abschuss
{
    class CSimu
    {
        double a;
        double V2;
        double s;
        double Ges;
        double diff;

        Button But1;
        TextBox Box1;//Verzögerung m/s2
        TextBox Box2;//Geschwindigkeit
        
        TextBox Box3;//Laufende Zeit
        TextBox Box4;//Höhe
        TextBox Box5;//Geschwindigkeit

        //Konstruktor
        public CSimu(TextBox Box1, TextBox Box2, TextBox Box3, TextBox Box4, TextBox Box5, Button But1)
        {
            this.But1 = But1;
            this.Box1 = Box1;
            this.Box2 = Box2;
            
            this.Box3 = Box3;
            this.Box4 = Box4;
            this.Box5 = Box5;
            
            try
            {
                a = Convert.ToDouble(Box1.Text);
                Ges = Convert.ToDouble(Box2.Text);
            }
            catch (Exception) { }

            Thread OThr1 = new Thread(new ThreadStart(Thread1));
            OThr1.Start();
            But1.Enabled = true;//Button wieder Aktivieren! :)
        }
        
        private void Thread1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            But1.Enabled = false;//Button Deaktivieren. :/
            

            for (double t = 0.01; t < 50000; t += 0.01)
            {

                Thread.Sleep(10);

                V2 = a * t; //Berechnung in m/s
                s = (a * t * t) / 2; //Berechnung von Strecke
                diff = Ges - (V2 * 3.6);
                if (diff < 0) { diff = 0; }
                
                Box3.Text = string.Format("{0:#,0.00}",t);       //Laufende-Zeit
                Box4.Text = string.Format("{0:#,0.00}",s);       //Höhe(Strecke)
                Box5.Text = string.Format("{0:#,0}",V2 * 3.6);//Speed 

                //Console.WriteLine(" Sek:    Km/h: {1:#,0.00}   Km/h: {2:#,0.00}      Meter: {3:#,0.00}", x, V2 * 3.6, diff, s);
                if (diff == 0) break;
            }
            But1.Enabled = true;//Button Deaktivieren. :/
        }
    }
}

//public static void Simulation()
//        {
//            double a;	
//            double V2;
//            double s;
//            double Ges;
//            double diff;
    		
//            Console.Write("\n\n Beschleunigung in m/s2 Eingeben: ");
//                 a = Convert.ToDouble(Console.ReadLine());
//            Console.Write("\n\n Geschwindigkeit Eingeben in Km/h: ");
//                 Ges = Convert.ToDouble(Console.ReadLine());
    		
//                 Console.WriteLine("\n\tBeschleunigt/Gebremst - bis/aus {0} Km/h \n",Ges );
//        for(double x = 0.2; x < 50000; x = x + 0.2)
//        {		
//            Thread.Sleep(200);		
    		
//            V2 = a * x; //Berechnung in m/s
//            s = (a * x * x)/2; //Berechnung von Strecke
//            diff = Ges - (V2*3.6);
//            if (diff < 0){diff = 0;}
//            Console.WriteLine(" Sek: {0:#,0.0}   Km/h: {1:#,0.00}   Km/h: {2:#,0.00}      Meter: {3:#,0.00}",x,V2*3.6,diff,s);		
//            if(diff == 0)break;
//        }
//        Console.ReadLine();   
//        }
