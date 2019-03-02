using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleApplication2
{
    //Client
    class Program
    {
        static void Main(string[] args)
        {
            //Erstellen des Sockets beim Client und Server genau gleich! :)
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Client spezifisch
            sock.Connect("localhost", 80);


            //Senden
            for (int i = 0; i < 3; i++)
            {
                sock.Send(Encoding.UTF8.GetBytes("Hallo Nicolas\n"));
                Thread.Sleep(1);
            }

            //Antwort vom Server Empfangen
            byte[] buffer = new byte[1];
            //Solange Lesen wie Daten vorhanden, bei 0 fertig
            while (sock.Receive(buffer) > 0)
            {
                //Mach was mit den Bytes im buffer
                Console.Write(Encoding.UTF8.GetString(buffer));
            }
            
            
            //Ohne Close gibts beim Server eine Exception
            sock.Close();

            

        }

    }

}
