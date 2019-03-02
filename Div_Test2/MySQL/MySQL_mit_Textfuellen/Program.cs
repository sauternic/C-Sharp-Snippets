using System;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;

//Achtung immer mit Debugger ablaufen lassen!!! :/

namespace MySQL_mit_Textfuellen
{ 
    class Program
    {
        static void Main(string[] args)
        {
            string strDir = ("C:/Users/Nicolas/Documents/Visual Studio 2008/Projects/C Sharp/Kleine Uebungen/MySQL_mit_Textfuellen/bin/Debug/tempdatei.txt"); ;
  
            MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3307;Database='zufall_buchstaben';Uid=root;Pwd='';");
            MySqlCommand myCommand = new MySqlCommand("", connection);

            connection.Open();

            Random zufall = new Random();
            
            string str = "";
            for (int x = 0; x < 30030030; ++x)//Wieviel die Textdatei neu Geschrieben wird, multipliziert mit 'pro Textdatei' gibt die Gesamtzahl!! :  )  3003003
            {
                xxx:
                try
                {
                    StreamWriter streamObj = new StreamWriter("tempdatei.txt", false, Encoding.ASCII);//appending false!!
                    
                    str = "";
                    for (int y = 0; y < 333; ++y)//Pro Textdatei-Menge der Sätze  333
                    {
                        for (int z = 0; z < 10; ++z)//Zehn Buchstaben 
                        {
                            str += ((char)(zufall.Next(97, 122)));  
                        }
                        str += "\n"; //Zeilenumbruch   
                    }
                    streamObj.Write(str);
                    streamObj.Close();//Hier war der Hund Begraben!!! :/
                    
                    //Hier auf die Datenbank
    //--------------------------------------------------------------------------------------------------------------------------------------------------------
                    myCommand.CommandText = "LOAD DATA   INFILE '" + strDir + "' INTO TABLE tbzufall;";
                    //SQL-Senden!!! :  )
                    myCommand.ExecuteNonQuery(); 

                    //fileObj.Delete();//eine Methode um Files zu löschen, siehe auch Oben FileInfo-Klasse
                    streamObj = null;//Objekt löschen!!
                    //ev. hier noch Carbage Collector!!
                    }
                catch
                {
                    GC.Collect();
                    goto xxx;
                }
//--------------------------------------------------------------------------------------------------------------------------------------------------------      
            
            }
            connection.Close(); 
        }
    }
}
