using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace CodePlanet.Articles.ProgrammingSockets
{
    /// <summary>
    /// Das folgende Kommandozeilenprogramm illustriert wie Sockets
    /// dazu verwendet werden können Daten zu empfangen und zu senden.
    /// </summary>
    public partial class HTTPGet
    {
        public static void Main(string[] args)
        {
            //Endresultat
            string result = SocketSendReceive("www.google.ch", 80);
            
            File.WriteAllText(@"C:\Ausgabe\WebSeiteText.txt", result);
        }

        // Initialisiert die Socketverbindung und gibt diese zurück
        private static Socket ConnectSocket(string server, int port)
        {
            Socket sock = null;
            IPAddress[] ipAdresses;
            
            //DNS Server Dienst!!! :)))
            //Auflösung von Domain Name in IP Adresse(n)
            ipAdresses = Dns.GetHostAddresses(server);
            foreach (IPAddress address in ipAdresses)
            {
                //ipo für 2 Dinge gut! -AddressFamily -Connect()
                IPEndPoint ipo = new IPEndPoint(address, port);
                
                Socket tempSocket = new Socket(ipo.AddressFamily,
                                               SocketType.Stream,
                                               ProtocolType.Tcp);
                //Verbindung
                tempSocket.Connect(ipo);

                if (tempSocket.Connected)
                {
                    sock = tempSocket;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return sock;
        }

        // Die Methode sendet eine HTTP GET 1.1 Anfrage an den Server und
        // empfängt die Daten
        private static string SocketSendReceive(string server, int port)
        {
            Socket sock = null;

            // Die zu sendenden Daten
            string request = "GET / HTTP/1.1\r\n" +
                             "Host: " + server + "\r\n" +
                             "Connection: Close\r\n\r\n";
            // Kodiere den string in Bytes
            Byte[] bytesSent = Encoding.ASCII.GetBytes(request);
            // Lege ein Byte Array an für die zu emfangenden Daten
            Byte[] bytesReceived = new Byte[1];

            // Instanziere ein gültiges Socket Objekt mit den übergebenen Argumenten
            sock = ConnectSocket(server, port);

            if (sock == null)
                return ("Connection failed!");

            // Sende den HTTP-Request
            sock.Send(bytesSent);

            int bytes = 0;
            string page = "";
            // Empfange die Daten und konvertiere sie
            do
            {
                //Empfangen:
                bytes = sock.Receive(bytesReceived);
                page += Encoding.ASCII.GetString(bytesReceived);
            } while (bytes > 0);

            // Unterbinde alle weiteren Send() und Receive() Aktivitäten am Socket
            sock.Shutdown(SocketShutdown.Both);
            sock.Close();

            return page;
        }
    }
}