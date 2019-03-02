using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace TCP_Listener_Zeitgeber_Grundgerüst
{
    class Program
    {
        static void _Main(string[] args)
        {
            byte[] buffer = new Byte[1100];

            try
            {
                TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 80);
                server.Start();

                //Listener Endlosschleife
                while (true)
                {
                    //Hier wird gewartet bis Client Anklopft
                    TcpClient client = server.AcceptTcpClient();
                    Stream stream = client.GetStream();

                    int i = 0;
                    //Einleseschleife
                    while ((i = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        //Hier war der Fehler das nicht richtig Eingelesen wurde 3.Arg!!!
                        Console.Write(Encoding.UTF8.GetString(buffer, 0, i));
                    }

                    //Wie am Anfang der Schleife!
                    //Werden dort wieder neu Erzeugt
                    client.Close();
                    stream.Close();
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            Console.Read();

        }

    }

}

