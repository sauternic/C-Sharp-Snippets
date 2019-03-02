using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace PackAlgorithums
{
    class CLZW_ByteBasiert
    {
        //Fields
        private Stream stream;
        
        public StringBuilder eingabe_sb = new StringBuilder(10000000);
        public StringBuilder ausgabe_sb = new StringBuilder(10000000);
        
        public List<int> liste_test = new List<int>();
        public byte[] ausbabe_byarr = null;
        
        public Dictionary<string, int> dictio_komp = new Dictionary<string, int>();
        public Dictionary<int, string> dictio_dekomp = new Dictionary<int, string>();

        //Konstruktor
        public CLZW_ByteBasiert(Stream stream)
        {
            
            // Stream Versorgen
            this.stream = stream;
            Einlesen();

            
            //Dictionary Initalisieren:
            for (int x = 0; x < 256; ++x)
            {
                dictio_komp.Add(intByte_Hex(x), x);
            }
            
            //Dictionary Initalisieren:
            for (int x = 0; x < 256; ++x)
            {
                dictio_dekomp.Add(x, intByte_Hex(x));
            } 
            
            Komp();  
            DeKomp(); 
            
            this.ausbabe_byarr = SB_Hex_byteArr(this.ausgabe_sb);
        }

        private void Einlesen()
        {
            int i;

            while ((i = this.stream.ReadByte()) != -1)
            {
                this.eingabe_sb.Append(intByte_Hex(i));
            }  
        }         
                                       
 //****************Hilfsfunktion**********************************************************************************    
        private string intByte_Hex(int i)
        {
            string str;

            str = Convert.ToString(i, 16);
            if (str.Length < 2)
                str = "0" + str;

            return str;
        }

        private byte[] SB_Hex_byteArr(StringBuilder SB_Hex)
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
        }

  //**************************************************************************************************         


        private void Komp()
        {
            StringBuilder zeichen = new StringBuilder();
            StringBuilder frase = new StringBuilder();

            int intKey = 0;

            for (int x = 0; x < (eingabe_sb.Length / 2); ++x)
            {
                //Zeichen löschen
                zeichen.Remove(0, zeichen.Length);

                zeichen.Append(eingabe_sb[x * 2]);
                zeichen.Append(eingabe_sb[(x * 2) + 1]);

                frase.Append(zeichen);
                //Algo-Logik! :/

                //Wenn Zeichenfolge Gefunden wird true
                if (dictio_komp.ContainsKey(frase.ToString()))
                {
                    intKey = dictio_komp[frase.ToString()];
                    continue;//Wird ja dann auch x immer Erhöht 
                    //das entprechend später wieder aus string Gelesen wird.               
                }
                else
                {
                    //Neuer Eintrag mit der Zeichenfolge  
                    if (dictio_komp.Count < 4096)
                        dictio_komp.Add(frase.ToString(), dictio_komp.Count);
                    //Ausgeben des Eintrag Index
                    liste_test.Add(intKey);
                    int laenge = frase.Length;
                    --x;//Geht so Genau auf! :)
                    //frase löschen
                    frase.Remove(0,frase.Length);
                }
            }
            //letztes Zeichen noch Eintragen
            liste_test.Add(intKey);
        }

        private void DeKomp()
        {
            StringBuilder sbLast = new StringBuilder();
            StringBuilder sbNext = new StringBuilder();    
            int iNext = 0;
            bool flag = true;

            for (int x = 0; x < liste_test.Count - 1; ++x)
            {
                //Biblio_DeKomp muss ja erst aufgebaut werden! :/
                sbLast.Remove(0, sbLast.Length);
                if (liste_test[x] < 256)
                    sbLast.Append(intByte_Hex(liste_test[x]));
                else
                    sbLast.Append(dictio_dekomp[liste_test[x]]);

                //Zusatzbedingung fürs || unten
                iNext = liste_test[x + 1];

                sbNext.Remove(0, sbNext.Length);
                if (liste_test[x + 1] < 256)
                    sbNext.Append(intByte_Hex(liste_test[x + 1]));
                else
                    //Wenn Muster noch nicht in Tabelle:
                    if (dictio_dekomp.ContainsKey(liste_test[x + 1]))
                        sbNext.Append(dictio_dekomp[liste_test[x + 1]]);
                    else
                        sbNext.Append(dictio_dekomp[liste_test[x]] + (dictio_dekomp[liste_test[x]]).Substring(0, 2));

                if (flag)
                {
                    //Ausgabe Muster von last
                    this.ausgabe_sb.Append(sbLast);
                }
                flag = false;

                //Grösse der Dekomp. Biblio. Begrenzen
                if (dictio_dekomp.Count < 4096)
                {
                    //Neu nur noch nach int Eintrag Suchen! :/
                    if (dictio_dekomp.ContainsKey(iNext))
                    {
                        //last + 1.Zeichen von next
                        dictio_dekomp.Add(dictio_dekomp.Count, sbLast.ToString() + sbNext.ToString().Substring(0, 2));
                    }
                    else
                    {
                        //last + 1.Zeichen von Last
                        dictio_dekomp.Add(dictio_dekomp.Count, sbLast.ToString() + sbLast.ToString().Substring(0, 2));
                    }
                }  
                //Ausgabe Muster von next
                this.ausgabe_sb.Append(sbNext);
                
            }        
        }    
    }
}
 //Messen
            //long lmesspunkt1 = DateTime.Now.Ticks;

            //this.strAusgabe = SB_Ausgabe.ToString();
            //Thread.Sleep(100);

            //long lmesspunkt2 = DateTime.Now.Ticks;

            //double dblZeitspanneTicks = lmesspunkt2 - lmesspunkt1;
            //double dblZeitspanneMili = dblZeitspanneTicks / 10000;

            //Console.WriteLine("Milisekunden: {0:#,0.#############}", dblZeitspanneMili);