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
            string host =  "www.google.ch";
    
            string result = SocketSendReceive(host, 80);
            File.WriteAllText(@"C:\Ausgabe\WebSeiteText.txt", result);
        }
 
        // Initialisiert die Socketverbindung und gibt diese zurück
        private static Socket ConnectSocket(string server, int port)
        {
            Socket sock = null;
            IPHostEntry hostEntry = null;
 
            hostEntry = Dns.GetHostEntry(server);
 
            // Nutze die Eigenschaft AddressFamily von IPEndPoint um Konflikte zwischen
            // IPv4 und IPv6zu vermeiden. Gehe dazu die Adressliste mit einer Schleife durch.
            foreach (IPAddress address in hostEntry.AddressList) {
                IPEndPoint ipo = new IPEndPoint(address, port);
                Socket tempSocket = new Socket(ipo.AddressFamily,
                                               SocketType.Stream,
                                               ProtocolType.Tcp);
 
                tempSocket.Connect(ipo);
 
                if (tempSocket.Connected) {
                    sock = tempSocket;
                    break;
                } else {
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
            Byte[] bytesReceived = new Byte[4096];
 
            // Instanziere ein gültiges Socket Objekt mit den übergebenen Argumenten
            sock = ConnectSocket(server, port);
 
            if (sock == null)
                return ("Connection failed!");
 
            // Sende den HTTP-Request
            sock.Send(bytesSent, bytesSent.Length, SocketFlags.None);
 
            int bytes = 0;
            string page = "Default HTML page on " + server + ":\r\n";
 
            // Empfange die Daten und konvertiere sie
            do {
                bytes = sock.Receive(bytesReceived, bytesReceived.Length, SocketFlags.None);
                // kovertiere die Byte Daten in einen string
                page = page + Encoding.ASCII.GetString(bytesReceived, 0, bytes);
            } while (bytes > 0);
 
            // Unterbinde alle weiteren Send() und Receive() Aktivitäten am Socket
            sock.Shutdown(SocketShutdown.Both);
            sock.Close();
 
            return page;
        }
    }
}