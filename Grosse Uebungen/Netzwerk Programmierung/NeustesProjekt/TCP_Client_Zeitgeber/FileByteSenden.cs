using System.Text;
using System.Net.Sockets;
using System.IO;

namespace TCP_Client_FileByteSenden
{
    class Program
    {
        static void _Main(string[] args)
        {
            TcpClient client = new TcpClient("localhost", 81);
            Stream stream = client.GetStream();

            //byte[] daten = File.ReadAllBytes("C:/Ausgabe/Client/Insekt.jpg");
            byte[] daten = File.ReadAllBytes("G:/Eigene Videos/Uetliberg.mp4");

            stream.Write(daten, 0, daten.Length);

            client.Close();
            stream.Close();
        }

    }
}
