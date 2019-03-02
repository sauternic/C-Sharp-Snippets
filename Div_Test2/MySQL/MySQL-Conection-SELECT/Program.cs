using System;
using MySql.Data.MySqlClient;

namespace MySQL_Conection_SELECT
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3307;Database='meineDaten';Uid=root;Pwd='';");
            MySqlCommand myCommand = new MySqlCommand("SELECT * FROM neuetabelle;", connection);  // 1.Argument SQL Abfrage!! :/

            connection.Open();
                MySqlDataReader Reader = myCommand.ExecuteReader();//Nur ab hier anders als beim SELECT!
//----Feld-Namen---------------------------------------------------------------------------------------------------------------
                    string row = "";
                for (int i = 0; i < Reader.FieldCount; i++)
                    row += Reader.GetName(i).ToString() + " | ";
                    
                Console.WriteLine(row);
//----Datensätze----------------------------------------------------------------------------------------------------------------
                while (Reader.Read())
                {
                        row = "";    
                    for (int i = 0; i < Reader.FieldCount; i++)
                          row += Reader.GetValue(i).ToString() + " | ";

                    Console.WriteLine(row);
                }
//------------------------------------------------------------------------------------------------------------------------------
            connection.Close();
        } 
    }
}

            