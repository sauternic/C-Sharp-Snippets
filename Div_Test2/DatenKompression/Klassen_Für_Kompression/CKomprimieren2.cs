using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Klassen_Für_Kompression
{
    partial class CKomprimieren
    {

        // Statische Haubtmethode! :-)
        public static  byte[] Compress_LZW(Stream stream)
        {
            _stream = stream;
            
            Einlesen1();
            
            //Dictionary Initalisieren:
            for (int x = 0; x < 256; ++x)
            {
                _dictioKomp.Add(intByte_Hex(x), x);
            }

            Komp();
            IntListe_ByteArray();

            // Seeeeeeeeeeeeeeehr wichtig
            // Ergebnis Ausliefern! :-)
            return _ergebByteArr;
        }


        // 1. Überladung für byte[] Argument. (Statische Haubtmethode! :-)  )
        public static byte[] Compress_LZW(byte[] byArr_Eingabe)
        {
            FelderNullen();
            
            _byArr_eingabe = byArr_Eingabe;
            
            Einlesen2();

            //Dictionary Initalisieren:
            for (int x = 0; x < 256; ++x)
            {
                _dictioKomp.Add(intByte_Hex(x), x);
            }

            //Dictionary Initalisieren:
            for (int x = 0; x < 256; ++x)
            {
                _dictioDekomp.Add(x, intByte_Hex(x));
            }

            Komp();
            IntListe_ByteArray();

            // Seeeeeeeeeeeeeeehr wichtig
            // Ergebnis Ausliefern! :-)
            return _ergebByteArr;
        }
        
        
        #region Hilfsfunktionen
        private static void Einlesen1()
        {
            int i;

            while ((i = _stream.ReadByte()) != -1)
            {
                _eingabeSB.Append(intByte_Hex(i));
            }
        }

        private static void Einlesen2()
        {
            foreach (int i in _byArr_eingabe)
            {
                _eingabeSB.Append(intByte_Hex(i));
            }
        }
        
        
        private static void Komp()
        {
            StringBuilder zeichen = new StringBuilder();
            StringBuilder frase = new StringBuilder();

            int intKey = 0;

            for (int x = 0; x < (_eingabeSB.Length / 2); ++x)
            {
                //Zeichen löschen
                zeichen.Remove(0, zeichen.Length);

                zeichen.Append(_eingabeSB[x * 2]);
                zeichen.Append(_eingabeSB[(x * 2) + 1]);

                frase.Append(zeichen);
                //Algo-Logik! :/

                //Wenn Zeichenfolge Gefunden wird true
                if (_dictioKomp.ContainsKey(frase.ToString()))
                {
                    intKey = _dictioKomp[frase.ToString()];
                    continue;//Wird ja dann auch x immer Erhöht 
                    //das entprechend später wieder aus string Gelesen wird.               
                }
                else
                {
                    //Neuer Eintrag mit der Zeichenfolge  
                    if (_dictioKomp.Count < 4096)
                        _dictioKomp.Add(frase.ToString(), _dictioKomp.Count);
                    //Ausgeben des Eintrag Index
                    _kompInt.Add(intKey);
                    int laenge = frase.Length;
                    --x;//Geht so Genau auf! :)
                    //frase löschen
                    frase.Remove(0, frase.Length);
                }
            }
            //letztes Zeichen noch Eintragen
            _kompInt.Add(intKey);
        }
       
       
        
        //****************Hilfsfunktion**********************************************************************************    
        private static string intByte_Hex(int i)
        {
            string str;

            str = Convert.ToString(i, 16);
            if (str.Length < 2)
                str = "0" + str;

            return str;
        }

        private static byte[] SB_Hex_byteArr(StringBuilder SB_Hex)
        {
            byte[] byArr = new byte[(SB_Hex.Length / 2)];
            StringBuilder temp = new StringBuilder();

            for (int x = 0; x < (SB_Hex.Length / 2); ++x)
            {
                temp.Remove(0, temp.Length);
                temp.Append(SB_Hex[x * 2]);
                temp.Append(SB_Hex[(x * 2) + 1]);


                byArr[x] = Convert.ToByte(temp.ToString(), 16);
            }
            return byArr;
            //**************************************************************************************************         
        }

    }
        #endregion
}
