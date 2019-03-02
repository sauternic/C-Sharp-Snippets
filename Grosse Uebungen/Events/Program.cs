using System;

namespace Events
{
    // Delegat für Ereignis
    public delegate void GeoffnetEventHandler();
    
    class CLaden
    {
        public event GeoffnetEventHandler Geoeffnet;
        
        private bool offen = false;
        public bool Offen
        {
            get
            {
                return offen;
            }
            set
            {
                offen = value;
                OnGeoffnet(); //Ereignis Auslösen(Ausgelagert)
            }
        }
        
        //Löst Ereignis aus und bearbeitet es
        public void OnGeoffnet()
        {
            if (Offen == true)
            {
                Console.WriteLine("\n Laden wurde geöffnet\n");

                if (Geoeffnet != null)
                    Geoeffnet();
            }
            else
                Console.WriteLine("\n Laden wurde geschlossen\n");
        }
    }

    class CSean
    {
        CLaden laden;
        
        public CSean(CLaden l)
        {
            laden = l;

            //Ereignis abonnieren
            laden.Geoeffnet += new GeoffnetEventHandler(LadenGeoeffnet);
        }
        
        // Bei Eintritt des Ereignisses ausführen
        private void LadenGeoeffnet()
        {
            Console.WriteLine("\t Yippieh!");
        } 
    }
    
    class CMaria
    { 
         CLaden laden;
        
        public CMaria(CLaden l)
        {
            laden = l;

            //Ereignis abonnieren
            laden.Geoeffnet += new GeoffnetEventHandler(LadenGeoeffnet);
        }
        
        // Bei Eintritt des Ereignisses ausführen
        private void LadenGeoeffnet()
        {
            Console.WriteLine("\t Hurra!");
        } 
    }

    class Program
    {
        static void Main(string[] args)
        {
            CLaden oBuchladen = new CLaden();
            CSean oSean = new CSean(oBuchladen);
            CMaria oMaria = new CMaria(oBuchladen);
        
            oBuchladen.Offen = !oBuchladen.Offen;
            oBuchladen.Offen = !oBuchladen.Offen;
            oBuchladen.Offen = !oBuchladen.Offen;
        }
    }
}
