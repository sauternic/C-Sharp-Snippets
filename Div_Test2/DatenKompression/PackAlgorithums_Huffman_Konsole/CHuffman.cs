using System;
using System.Collections.Generic;
using System.IO;

namespace PackAlgorithums
{
    class CHuffman
    {
        //Fields
        private Stream Stream1;
        public List<int> iList_Auflistung = new List<int>();
        public List<int> iList_Sortiert = new List<int>();
        public List<BlaetterKnoten> List_BlaetterKnoten_Sortiert_Wertigkeit = new List<BlaetterKnoten>();
        public List<BlaetterKnoten> List_BlaetterKnoten = new List<BlaetterKnoten>();
        public BlaetterKnoten BinaererBaum = null;
        public List<string> strList = new List<string>();
        
        //Konstruktor
        public CHuffman(Stream Stream1)
        {
            this.Stream1 = Stream1;
            this.Einlesen();
            this.List_BlaetterKnoten.Sort();
            
            //Liste Kopieren bevor Zusammenfassen_Node
            foreach (BlaetterKnoten BK in List_BlaetterKnoten)
                List_BlaetterKnoten_Sortiert_Wertigkeit.Add(BK);
            
            Zusammenfassen_Node();
            if (List_BlaetterKnoten.Count == 1)
                this.BinaererBaum = this.List_BlaetterKnoten[0];

            //Rekursive Methode zum Codewege Auslesen!! ;)
            CodeAuslesen(BinaererBaum);
        
        }

        private void CodeAuslesen(BlaetterKnoten BK, string path = "")
        {
            if (!BK.Node)
            {
                strList.Add("Wertigkeit:" + BK.Wertigkeit + " " + BK.Symbol.ToString() + " " + BK.Zeichen.ToString() + ":" + path);
            }
            if (BK.Node)
            {
                //Rekursive Aufrufen! ;)
                CodeAuslesen(BK.BK_0_left, path + "0");
                CodeAuslesen(BK.BK_1_right, path + "1");
            }

        }
        
        
        private void Zusammenfassen_Node()
        {
            int Wertigkeit0, Wertigkeit1;

            while (true)
            {
                Wertigkeit0 = List_BlaetterKnoten[0].Wertigkeit;
                Wertigkeit1 = List_BlaetterKnoten[1].Wertigkeit;

                //Debug.print
                //foreach (BlaetterKnoten BK in this.List_BlaetterKnoten)
                //    Console.WriteLine(BK.Symbol + ":" + BK.Zeichen + ":" + BK.Wertigkeit);
                //Console.WriteLine("\n\n");

                //vor löschen Referenz darauf
                BlaetterKnoten BK1 = List_BlaetterKnoten[0];
                BlaetterKnoten BK2 = List_BlaetterKnoten[1];
                //Löschen 'letzte' beiden Einträge 
                for (int x = 0; x < 2; ++x)
                {
                    List_BlaetterKnoten.RemoveAt(0);
                }

                //Wir durchgeführt wenn alles Leer, Beachte den Vertausch von BK1 und BK2. (sonst zeigt letzter Knoten Verkehrt)
                if (List_BlaetterKnoten.Count < 1)
                    List_BlaetterKnoten.Add(new BlaetterKnoten(0, Wertigkeit0 + Wertigkeit1, true, BK2, BK1));
                else
                    List_BlaetterKnoten.Add(new BlaetterKnoten(0, Wertigkeit0 + Wertigkeit1, true, BK1, BK2));

                //Neu Sortieren!! ;)
                List_BlaetterKnoten.Sort();


                //Hier einer mehr bei Count weil ja oben wieder einer (add)! :/
                if (List_BlaetterKnoten.Count < 2)
                    break;
            }
        }
        
        
        
        private void Einlesen()
        {
            int zeichen = 0;

            while ((zeichen = this.Stream1.ReadByte()) != -1)
            {
                this.iList_Sortiert.Add(zeichen); 
            }

            //Kopieren bevor Sortiert.
            foreach (int i in iList_Sortiert)
                iList_Auflistung.Add(i);
            
            this.iList_Sortiert.Sort();
            Wertigkeit();
        }
        //Wird von Einlesen() gebraucht
        private void Wertigkeit()
        {
            int zahlen = 1;
            int x;
          
            
            for (x = 0; x < iList_Sortiert.Count - 1  ; ++x)
            {              
                if (iList_Sortiert[x] == iList_Sortiert[x + 1])
                {
                    ++zahlen;


                }
                else
                {
                    List_BlaetterKnoten.Add(new BlaetterKnoten(iList_Sortiert[x], zahlen, false));
                    zahlen = 1;
                }
            
            }
            //Für den letzten Durchgang! :)
            List_BlaetterKnoten.Add(new BlaetterKnoten(iList_Sortiert[x], zahlen, false));
            zahlen = 1;
        }
    }//ende Klasse

//######################## struct ##################################################################################################
    
    class BlaetterKnoten : IComparable
    {
        //Fields
        public readonly char Symbol;
        public readonly int Zeichen;
        public readonly int Wertigkeit;
        public readonly bool Node;
        public readonly BlaetterKnoten BK_0_left;
        public readonly BlaetterKnoten BK_1_right;
 
        //Konstruktor
        public BlaetterKnoten(int Zeichen, int Wertigkeit, bool Node, params object[] oZeichenWertigkeit)
        {
            this.Zeichen = Zeichen;
            if (Zeichen < 33 || Zeichen == 127)
                this.Symbol = (char)46;
            else
                this.Symbol = (char)Zeichen;
            this.Wertigkeit = Wertigkeit;
            this.Node = Node;
            if (oZeichenWertigkeit.Length > 1)
            {
                this.BK_0_left = (BlaetterKnoten)oZeichenWertigkeit[0];
                this.BK_1_right = (BlaetterKnoten)oZeichenWertigkeit[1];
            }
        }

        //IComparable-Implementation:
        public int CompareTo(object obj)
        {
            BlaetterKnoten ZW = (BlaetterKnoten)obj;
            if (this.Wertigkeit > ZW.Wertigkeit)
                return 1;
            if (this.Wertigkeit < ZW.Wertigkeit)
                return -1;
            else
                return 0;
        }
    }//Ende class
}
