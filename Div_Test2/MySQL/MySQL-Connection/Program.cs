using System;
using MySql.Data.MySqlClient;

//Bibliothek Runterladen: von MySQL 'www.mysql.com/downloads/connector/' oder Google: "mysql connector"

//Wähle dort:  Connector/NET  'ADO.NET Driver for MySQL'
//Wähle dort: .NET & Mono
//Entzipen.
//Ordner V2 mit mysql.data.dll
//Nur noch einen Verweis auf die Bibliothek(.dll) machen!!! : )

class Program
{
    static void Main(string[] args)
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3307;Database='meineDaten';Uid=root;Pwd='';");
        MySqlCommand myCommand = new MySqlCommand("INSERT INTO neuetabelle (pid, name, vorname) VALUES ('16','Müller','Patrick');", connection);
        
        //connection.Open();
        connection.Open();
            myCommand.ExecuteNonQuery();
        connection.Close();
    } 
}
         
        //INSERT INTO neuetabelle (pid, name, vorname) VALUES ('15','Müller','Patrick')  Neuer-Datensatz!!
        //UPDATE neuetabelle n SET Name = 'Sauter' where pid=8;                          Neuer-Datensatz!!
        
      