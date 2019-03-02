using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PackAlgorithmus_Bauteile_Konsole
{
    class CBinaereOperationen
    {
    //Fields
        private Stream Stream1 = null;
        public String strBin = "";


        //Konstruktor  
        public CBinaereOperationen(Stream Stream1)
        {
            this.Stream1 = Stream1;
            Bin_Str();
        
        
        }

        public static void Main(string[] args)
        {
      //*********************************************************      
            //12Bit! :)
            //Nullen Array aus Strings
            string[] strArr = new string[12];
            string temp = "";
            bool flag = false;

            for(int x = 0; x < strArr.Length; ++x)
            {
                if(flag)
                    temp += "0";
                flag = true;
                strArr[x] += temp ;
            }
      //*********************************************************           
            

            int by = Convert.ToInt32("101", 2);
            string str = Convert.ToString(by, 2);
            
            //Führende Nullen Einfügen 12 Bit! :)
            str = strArr[12 - str.Length] + str;
            int iii = str.Length;
        
        }

        
        //Nicht überall nötig siehe oben Converter Klasse!!! :)
        //Um zu Schauen welche Bits gesetzt sind:
        private void Bin_Str()
        {
            int by = 0;
            byte Maske = 0x80;
            
            while ((by = Stream1.ReadByte()) != -1)
            {  
                Maske = 0x80;
                for(int x = 1; x <= 8; ++x)
                {
                    if ((by & Maske) == Maske)
                        strBin += 1;
                    else
                        strBin += 0;
                    Maske /= 2; 
       
                }
                strBin += " ";
            
            }
        }
        // Umgekehrt! :)
        //int by = Convert.ToInt32("100000000000", 2);   
        // Umgekehrt!(by) :)
        //string str = Convert.ToString(by, 2);
    }
 
}
