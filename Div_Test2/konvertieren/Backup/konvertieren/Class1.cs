using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Konvertieren
{
   static class Konvertieren
    {

        public static string strDezInDiv(UInt64 iEingabe, UInt64 basis)
        {
            UInt64 iRest;
            string str = "";

            while (iEingabe > 0)
            {
                iRest = iEingabe % basis; //Modulo Rest der Division
                str += Convert.ToString(ZeichenAnalyse(iRest));//String Füllen
                iEingabe /= basis; //Ganzzahldivision
            }

            char[] strArr = str.ToCharArray();//String in ein Char Array Abfüllen
            str = ""; // String Nullen um wieder zu Verwenden

            for (int x = strArr.Length - 1; x >= 0; --x)
            {
                str += Convert.ToString(strArr[x]);//Umkehren des Strings
            }
            return str;
        }

        private static char ZeichenAnalyse(UInt64 i)
        {
            char[] chrZ = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            return chrZ[i];
        }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    }
}
