using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PackAlgorithums
{

    // LZW Lempel Ziv Welch (1984) -> Grundgedanke von ZIP
    // Hier Komplett neu Aufbauen
    class CLZW_TextBasiert
    {
        //Fields
        private Stream stream;
        
        public string eingabe_str = "";
        public string ausgabe_str = "";
        
        public List<int> TestListe = new List<int>();
        public List<string> TestListeString =  new List<string>();
        
        
        public Dictionary<string, int> dictio_komp = new Dictionary<string, int>();
        public Dictionary<int, string> dictio_dekomp = new Dictionary<int, string>();

        //Konstruktor
        public CLZW_TextBasiert(Stream stream)
        {
            // Stream Versorgen
            this.stream = stream;
            Einlesen();
            
            //Dictionary Initalisieren:
            string str = ""; 
            for (int x = 0; x < 256; ++x)
            {
                str = "";
                str += (char)x;
                dictio_komp.Add(str, x);
            }
            //Dictionary Initalisieren:
            str = "";
            for (int x = 0; x < 256; ++x)
            {
                str = "";
                str += (char)x;
                dictio_dekomp.Add(x, str);
            } 
            Komp();
            DeKomp();
            TestListeFunktion();
        }

        private void Einlesen()
        {
            int i = 0;
            char c;

            while ((i = this.stream.ReadByte()) != -1)
            {
                c = (char)i;
                eingabe_str += c;
            }   
                
        }         
                                       
        private void Komp()
        {
            string strZeichen = "";
            string strFrase = "";
            
            int intKey = 0;

            for (int x = 0; x < eingabe_str.Length; ++x)
                {
                    strZeichen = this.eingabe_str.Substring(x, 1);
                    strFrase += strZeichen;  
                    //Algo-Logik! :/
                   
                    //Wenn Zeichenfolge Gefunden wird true
                    if(dictio_komp.ContainsKey(strFrase))
                    {
                        intKey = dictio_komp[strFrase];
                        continue;//Wird ja dann auch x immer Erhöht 
                        //das entprechend später wieder aus string Gelesen wird.               
                    }
                    else
                    {
                        //Neuer Eintrag mit der Zeichenfolge  
                        if(dictio_komp.Count < 4096)
                            dictio_komp.Add(strFrase, dictio_komp.Count);
                        //Ausgeben des Eintrag Index
                        TestListe.Add(intKey);
                        int laenge = strFrase.Length;
                        --x;//Geht so Genau auf! :)
                        strFrase = "";
                    }
                }
            //letztes Zeichen noch Eintragen
            TestListe.Add(intKey);
         }

        private void DeKomp()
        {
            string strLast = "";
            string strNext = "";
            int iNext = 0;
            bool flag = true;
            
            for (int x = 0; x < TestListe.Count - 1; ++x)
            {
                //Biblio_DeKomp muss ja erst aufgebaut werden! :/
                strLast = "";
                if (TestListe[x] < 256)
                    strLast += (char)TestListe[x];
                else
                    strLast = dictio_dekomp[TestListe[x]];

                //Zusatzbedingung fürs || unten
                iNext = TestListe[x + 1];

                strNext = "";
                if (TestListe[x + 1] < 256)
                    strNext += (char)TestListe[x + 1];
                else
                    //Wenn Muster noch nicht in Tabelle:
                    if (dictio_dekomp.ContainsKey(TestListe[x + 1]))
                        strNext = dictio_dekomp[TestListe[x + 1]];
                    else
                        strNext = dictio_dekomp[TestListe[x]] + (dictio_dekomp[TestListe[x]]).Substring(0, 1);
                
                if (flag)
                {
                    //Ausgabe Muster von last
                    this.ausgabe_str += strNext;
                }
                flag = false;
                
                //Grösse der Dekomp. Biblio. Begrenzen
                if (dictio_dekomp.Count < 4096)
                {
                    //Neu nur noch nach int Eintrag Suchen! :/
                    if (dictio_dekomp.ContainsKey(iNext))
                    {
                        dictio_dekomp.Add(dictio_dekomp.Count, strLast + strNext.Substring(0, 1));
                    }
                    else
                    {
                        dictio_dekomp.Add(dictio_dekomp.Count, strLast + strLast.Substring(0, 1));
                    }
                }
                //Ausgabe Muster von next
                this.ausgabe_str += strNext;
            }
        }    
    
        //Hilfsfunktionen
        private void TestListeFunktion()
        {
            string str = "";

            foreach (int i in TestListe)
            {
                if (i < 256)
                    str = Convert.ToString(Convert.ToChar(i));
                else
                {
                    str = Convert.ToString(i);
                }
                
                TestListeString.Add(str);
            }
        }
    
    
    } //Ende class     
}  
