using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Threading;

//Hier werden nur die Grundsätze Erklärt: (Wird nicht fürs Programm gebraucht)
namespace NetworkingMitCSharp_Konsole
{
    class Program
    {
        static void ain(string[] args)
        {
            // Listener initialisieren
            TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 4711);
            
            // Listener starten
            listener.Start();
            
            // Warten bis ein Client die Verbindung wünscht
            TcpClient c = listener.AcceptTcpClient();
            
            // An dieser Stelle ist der Listener wieder bereit, 
            // einen neuen Verbindungswunsch zu akzeptieren
            
            // Stream für lesen und schreiben holen
            Stream inOut = c.GetStream();
            
            // Hier kann in den Stream geschrieben werden
            // oder aus dem Stream gelesen werden
            
            // Verbindung schließen
            c.Close();
            
            // Listener beenden
            listener.Stop();
        }

        static void Client()
        {
            // Client initialisieren und mit dem Server verbinden
            TcpClient c = new TcpClient("localhost", 4711);
            
            // Stream für lesen und schreiben holen
            Stream inOut = c.GetStream();
            
            // Hier kann in den Stream geschrieben werden
            // oder aus dem Stream gelesen werden
            
            // Verbindung schließen
            c.Close();
        }
    }
}
