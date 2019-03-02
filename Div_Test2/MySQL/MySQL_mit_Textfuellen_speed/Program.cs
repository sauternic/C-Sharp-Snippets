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
            string strDir = ("C:/Users/Nicolas/Documents/Visual Studio 2008/Projects/C Sharp/Kleine Uebungen/MySQL_mit_Textfuellen_speed/bin/Debug/tempdatei.txt"); ;

            MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3307;Database='zufall_buchstaben_testen';Uid=root;Pwd='';");
            MySqlCommand myCommand = new MySqlCommand("", connection);
            //StreamWriter streamObj = new StreamWriter("tempdatei.txt", false, Encoding.ASCII);//appending false!!
            
            connection.Open();

            Random zufall = new Random();

            string str = "";
            for (int x = 0; x < 30030030; ++x)//Wieviel die Textdatei neu Geschrieben wird, multipliziert mit 'pro Textdatei' gibt die Gesamtzahl!! :  )  3003003
            {
                xxx:
                try
                {
                    str = "";
                    for (int y = 0; y < 333; ++y)//Pro Textdatei-Menge der Sätze  333
                    {
                        for (int z = 0; z < 10; ++z)//Zehn Buchstaben 
                        {
                            str += ((char)(zufall.Next(97, 122)));
                        }
                        str += "\n"; //Zeilenumbruch   
                    }
                    File.WriteAllText(strDir,str);
 
                    //Hier auf die Datenbank
                    //--------------------------------------------------------------------------------------------------------------------------------------------------------
                    myCommand.CommandText = "LOAD DATA   INFILE '" + strDir + "' INTO TABLE tbzufall;";
                    //SQL-Senden!!! :  )
                    myCommand.ExecuteNonQuery();
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
