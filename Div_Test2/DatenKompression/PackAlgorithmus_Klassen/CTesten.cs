using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PackAlgorithmus_Klassen
{
    //Test File mit 9 Bit usw. Erzeugen
    class CTesten
    {
        //Fields
        public const int BITANZAHL = 20;
        public List<int> test_listint = new List<int>();
        //Byte Array zum Rausschreiben! :)
        public byte[] ergeb_bytearr = null;
        //Ergebnis.
        public List<int> ergeb_listint = new List<int>();
        //Hilfsnullen.
        string[] hilfsnullen_arr = new string[BITANZAHL];
        //Hilfsfunktionen.
        private StringBuilder sb_1 = new StringBuilder();
        private StringBuilder temp_sb = new StringBuilder();
        
        
        //Konstruktor
        public CTesten()
        {
            string strTemp = "";
            bool flag = false;
            
            test_listint.Add(4);
            test_listint.Add(50);
            test_listint.Add(133);
            test_listint.Add(0);
            test_listint.Add(255);
            test_listint.Add(154);
            
            // "" 0 00 000 usw. Array Erzeugen.
            for (int x = 0; x < BITANZAHL; ++x)
            {
                if (flag)
                    strTemp += "0";
                flag = true;
                hilfsnullen_arr[x] += strTemp;
            }

            Rausschreiben();
            Einlesen();
        }

        private void Rausschreiben()
        {
            StringBuilder sbKette = new StringBuilder();
            StringBuilder sbTemp = new StringBuilder();

            for (int x = 0; x < test_listint.Count; ++x)
            {
                //bit_kette_sb mit Tokenlänge -> BITANZAHL
                sbKette.Append(NullenEinfügenBITANZAHL( Convert.ToString(test_listint[x], 2)));
            }

            int laenge = (int)Math.Ceiling(sbKette.Length / 8.0);

            //Konvertieren zu Byte-Array (8 bit)
            ergeb_bytearr = new byte[laenge];
            for (int aussen = 0; aussen < laenge; ++aussen)
            {
                sbTemp.Remove(0, sbTemp.Length);

                try
                {
                    for (int innen = 0; innen < 8; ++innen)
                    {
                        //Je 8 Bit von bit_kette_sb nach sbTemp Übertragen.
                        sbTemp.Append(sbKette[(aussen * 8) + innen]);
                    }
                }
                catch (Exception) 
                {
                    //Mit Nullen am Schluss Füllen!! 
                    sbTemp = sbTemp.Append(hilfsnullen_arr[8 - sbTemp.Length]);
                }

                //Ergebnis Byte-Array (8 bit)
                ergeb_bytearr[aussen] = Convert.ToByte(sbTemp.ToString(), 2);
            }
            //Rausschreiben
            File.WriteAllBytes("C:\\Ausgabe\\Komprimieren.txt", ergeb_bytearr);
        }

        private void Einlesen()
        {
            StringBuilder sbVerketten = new StringBuilder(10000000);
            StringBuilder sbTemp = new StringBuilder();
            byte[] byTemp = null;
            int iAbtastrate = 0;

            //Einlesen und nach ByteArray
            byTemp = File.ReadAllBytes("C:\\Ausgabe\\Komprimieren.txt");
            
            
            //Mit 8 bit Einlesen und Verketten
            for (int x = 0; x < byTemp.Length; ++x)
            {
                sbVerketten.Append(ByteToBitToken(byTemp[x]));
            }

            iAbtastrate = (int)Math.Ceiling(sbVerketten.Length / ((double)BITANZAHL));

            //Mit BITANZAHL Abtasten und ToInt32
            for (int aussen = 0; aussen < iAbtastrate; ++aussen)
            {
                sbTemp.Remove(0, sbTemp.Length);

                try
                {
                    for (int innen = 0; innen < BITANZAHL; ++innen)
                    {
                        //Je BITANZAHL Bit von bit_kette_sb nach sbTemp übertragen.
                        sbTemp.Append(sbVerketten[(aussen * BITANZAHL) + innen]);
                    }
                
                    //Ergebnis
                    ergeb_listint.Add(Convert.ToInt32(sbTemp.ToString(), 2));
                }
                catch (Exception) { }   
            }
        }

        private StringBuilder ByteToBitToken(byte by)
        {
            // 2 mal leeren.
            sb_1.Remove(0,sb_1.Length);
            temp_sb.Remove(0, temp_sb.Length);
            //BitFolge die by Entspricht
            sb_1.Append(Convert.ToString(by, 2));
            //Führende Nullen Einfügen insgesamt 8 Bit! :)
            temp_sb.Append(hilfsnullen_arr[8 - sb_1.Length] + sb_1);
            return temp_sb;
        }
        private string NullenEinfügenBITANZAHL(string str)
        {
            //Führende Nullen Einfügen BITANZAHL Bit! :)
            str = hilfsnullen_arr[BITANZAHL - str.Length] + str;
            return str;
        }
    }
}
