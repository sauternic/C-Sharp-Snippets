using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Klassen_Für_Kompression
{
    // Klasse auf 7 Dateien Verteilt.
    partial class CKomprimieren
    {
        // Static Fields, wird von div. Methoden aus den verschieden partial Dateien gebraucht:
        private static Stream _stream = null;
        private static byte[] _byArr_eingabe = null;

        private static StringBuilder _eingabeSB = new StringBuilder(10000000);
        private static StringBuilder _ausgabeSB = new StringBuilder(10000000);

        private static Dictionary<string, int> _dictioKomp = new Dictionary<string, int>();
        private static Dictionary<int, string> _dictioDekomp = new Dictionary<int, string>();

        // Komprimierte int Liste
        private static List<int> _kompInt = new List<int>();
        // Token:
        // Byte Array zum in eine Datei Rausschreiben! :)
        private static byte[] _ergebByteArr = null;
       

        // Wird nur von Hilfsfunktionen gebraucht.
        private static StringBuilder __SB = new StringBuilder();
        private static StringBuilder _tempSB = new StringBuilder();
        private static int _bitanzahl = 9;
        private static string[] _hilfsnullenArr = new string[_bitanzahl];
        
        private static void FelderNullen()
        {
            _stream = null;
            _byArr_eingabe = null;

            _eingabeSB = new StringBuilder(10000000);
            _ausgabeSB = new StringBuilder(10000000);

            _dictioKomp = new Dictionary<string, int>();
            _dictioDekomp = new Dictionary<int, string>();

            _kompInt = new List<int>();
            _ergebByteArr = null;
       
            // Wird nur von Hilfsfunktionen gebraucht.
            __SB = new StringBuilder();
            _tempSB = new StringBuilder();
            //_bitanzahl = 9;
            _hilfsnullenArr = new string[_bitanzahl];   
        }
       

        // Wird von div. Methoden gebraucht
        // um Int-Liste in ein Byte-Array ab 9 Token grösse zu Erzeugen.
        #region Token
        private static void IntListe_ByteArray()
        {
            string strTemp = "";
            bool flag = false;

            // "" 0 00 000 usw. Array Erzeugen.
            for (int x = 0; x < _bitanzahl; ++x)
            {
                if (flag)
                    strTemp += "0";
                flag = true;
                _hilfsnullenArr[x] += strTemp;
            }

            Rausschreiben();
        
        }
        
        
        private static void Rausschreiben()
        {
            StringBuilder sbKette = new StringBuilder(10000000);
            StringBuilder sbTemp = new StringBuilder();
            List<int> ergebByteListe = new List<int>(10000000);
            
            
            for (int x = 0; x < _kompInt.Count; ++x)
            {
                //bit_kette_sb mit Tokenlänge -> BITANZAHL
                sbKette.Append(NullenEinfügenBITANZAHL(Convert.ToString(_kompInt[x], 2)));
            }

           

            //Konvertieren zu Byte-Array (8 bit)
            try
            {
                int aussen = 0;
                while(true)
                {
                    // Bei jedem Durchgang die "Bits" Nullen
                    sbTemp.Remove(0, sbTemp.Length);

                    
                    // Wenns Aufgeht das nicht noch ein Leeres Byte Angehängt wird! :(
                    if (1 + (aussen * 8) > sbKette.Length)
                        break;
               
                        
                    for (int innen = 0; innen < 8; ++innen)
                    {
                        //Je 8 Bit von bit_kette_sb nach sbTemp Übertragen.
                        sbTemp.Append(sbKette[(aussen * 8) + innen]);
                    }
                    //Ergebnis Byte-Array (8 bit)
                    ergebByteListe.Add(Convert.ToByte(sbTemp.ToString(), 2));

                    ++aussen;
            
                 }// Ende while
            }
            catch (Exception)
            {
                //Mit Nullen am Schluss Füllen!! 
                sbTemp = sbTemp.Append(_hilfsnullenArr[8 - sbTemp.Length]);

                //Ergebnis Byte-Array (8 bit)
                ergebByteListe.Add(Convert.ToByte(sbTemp.ToString(), 2));
            }
           
            
            // ergebByteListe nach _ausgabeByArr Übertragen! :-)
           _ergebByteArr = new byte[ergebByteListe.Count];
           for (int x = 0; x < ergebByteListe.Count; x++)
           {
               _ergebByteArr[x] = (byte)ergebByteListe[x];
           }
 
        }// Ende Rausschreiben()

        
        private static StringBuilder ByteToBitToken(byte by)
        {
            
            
            // 2 mal leeren.
            __SB.Remove(0, __SB.Length);
            _tempSB.Remove(0, _tempSB.Length);
            //BitFolge die by Entspricht
            __SB.Append(Convert.ToString(by, 2));
            //Führende Nullen Einfügen insgesamt 8 Bit! :)
            _tempSB.Append(_hilfsnullenArr[8 - __SB.Length] + __SB);
            return _tempSB;
        }
        private static string NullenEinfügenBITANZAHL(string str)
        {
            //Führende Nullen Einfügen BITANZAHL Bit! :)
            if (str.Length == 10)
               _bitanzahl = 10;
            if (str.Length == 11)
                _bitanzahl = 11;
            if (str.Length == 12)
                _bitanzahl = 12;
            
            str = _hilfsnullenArr[_bitanzahl - str.Length] + str;
            return str;
        }
        #endregion

    }
}
