using System;
using System.Collections.Generic;
using System.Threading;


namespace Graphik_Abschuss
{
    //4 static Methoden
    static class Cabfuellen
    {
        public static string hoehe;//field, muss nach Simulation wieder genullt werden!! :/
        
        //Arrays Erzeugen
        static List<string> ZeitA = new List<string>();
        static List<string> hoeheA = new List<string>();
        static List<string> speedA = new List<string>();
        
        public static void abfuellen(string Zeit, string hoehe, string speed)
        { 
            //Abfüllen
            ZeitA.Add(Zeit);
            hoeheA.Add(hoehe);
            speedA.Add(speed);
        }

        public static void ausgeben_()
        {
            Thread ThrAusgeben = new Thread(new ThreadStart(ausgeben));
            ThrAusgeben.Start();
            
            CGraphik_Anzeige.thrad_start();
        }
        
        
        //Ausgeben    
        private static void ausgeben()//Wird als Thread gestartet!!! :)
        {
            Program.OForm1.button2.Enabled = false;
            Program.OForm1.button6.Enabled = true;     
            
            //Mit 0 Beginnen! :/
            Program.OForm1.textBox3.Text = "0"; //Laufende-Zeit
            Program.OForm1.textBox4.Text = "0"; //Höhe(Strecke)
            Program.OForm1.textBox5.Text = "0"; //Speed  
            
            for (int x = 0; x < ZeitA.Count; x++)
            {
                try
                {
                    //Feinabstimmung:
                    int schleife = Convert.ToInt32(Program.OForm1.textBox7.Text);
                    for (int zaehlen = 0; zaehlen < schleife; zaehlen++) ;

                    Program.OForm1.textBox3.Text = ZeitA[x];    //Laufende-Zeit
                    hoehe = hoeheA[x];
                    Program.OForm1.textBox4.Text = hoeheA[x];   //Höhe(Strecke)
                    Program.OForm1.textBox5.Text = speedA[x];   //Speed 
                }
                catch (Exception) { }
            }

            

            Program.OForm1.button2.Enabled = true;
            Program.OForm1.button6.Enabled = false;

            CGraphik_Anzeige.flag = false;
            
        }
   
         public static void neuBerechnen()//von Button 3 Aufgerufen
         {
             //List Array wieder löschen! :/
             ZeitA.Clear();
             hoeheA.Clear();
             speedA.Clear();

             Program.OForm1.button1.Enabled = true;
             Program.OForm1.button2.Enabled = false;         
         }
    
    
    
    
    
    }
}
