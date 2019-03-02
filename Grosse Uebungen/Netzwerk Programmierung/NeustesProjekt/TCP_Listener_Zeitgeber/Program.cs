using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace TCP_Listener_Zeitgeber
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] buffer = new Byte[1000];
            FileStream fileStream = null;
            Random random = new Random();

            //Ausserhalb Schleife!!!
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 80);
            server.Start();

            //Listener Endlosschleife
            while (true)
            {
                try
                {
                    //Hier wird gewartet bis Client Anklopft
                    TcpClient Tcpclient = server.AcceptTcpClient();
                    Stream client = Tcpclient.GetStream();

                    fileStream = new FileStream("C:/Ausgabe/Server/_" +
                    random.Next(2147483647).ToString() + "_" +
                    random.Next(2147483647).ToString() + ".mp4", FileMode.Create);

                    int i = 0;
                    //Einleseschleife
                    while ((i = client.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, i);
                    }

                    //Sonst kein Zugriff auf File!
                    fileStream.Close();
                    //Wie am Anfang der Schleife!
                    //Werden dort wieder neu Erzeugt wenn Verbindungswunsch kommt(AcceptTcpClient())
                    Tcpclient.Close();
                    client.Close();

                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
            }

        }

    }

}

