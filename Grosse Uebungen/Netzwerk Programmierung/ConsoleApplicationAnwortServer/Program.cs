using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApplicationAnwortServer
{
    class Program
    {
        //Server:
        static void Main(string[] args)
        {
            //Erstellen des Sockets beim Client und Server genau gleich! :)            
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Server spezifisch
            //Muss doch Port wissen auf dem geListet wird
            sock.Bind(new IPEndPoint(IPAddress.Any, 1000));
            sock.Listen(5);


            byte[] buffer = new byte[1];
            //Endlos Schleife
            while (true)
            {
                Socket client = null;
                try
                {
                    //Hier wird Blockiert(g ewartet)
                    //Und immer ein neuer Socket Erstellt!
                    client = sock.Accept();
                    Console.WriteLine("Handling client at " + client.RemoteEndPoint);
                    
                    //Empfangen
                    //Solange Lesen wie Daten vorhanden, bei 0 fertig
                    while (client.Receive(buffer) > 0)
                    {
                        //Zurück Senden
                        client.Send(buffer);
                        //Gesendetes auf Konsole Ausgeben
                        Console.Write(Encoding.UTF8.GetString(buffer));
                    }
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }
                catch (Exception e)
                {
                   Console.WriteLine(e.Message);
                    client.Close();
                }

            }

        }

    }

}
