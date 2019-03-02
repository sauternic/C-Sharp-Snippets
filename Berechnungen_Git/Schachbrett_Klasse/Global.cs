using System;
using System.Collections.Generic;

namespace Schachbrett
{
    class CSchachbrett
    { 
        //Felder
    public readonly Int32 FeldNr;
    public readonly decimal MengeImFeld;
    public readonly decimal MengeGes = 1;
    public static string Autor = "Copyright © Nicolas Sauter";   
        
        //Konstruktor
        public CSchachbrett(Int32 FeldNr)
        {
            this.FeldNr = FeldNr;
            this.MengeImFeld = 1;
          
            for (Int32 z = 1; z < FeldNr ; ++z)  
            {      
                    MengeImFeld *= 2;
                    MengeGes += MengeImFeld;
            }      
        }
    }
}