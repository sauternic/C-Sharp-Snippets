using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;

public class TimeClient
{
    public static void ain()
  {
      // Verbindung zum Server aufbauen
      TcpClient c = new TcpClient("localhost", 4711);
      
      // Stream zum lesen holen
      StreamReader inStream = new StreamReader(c.GetStream());
      bool loop = true;
      
      while (loop)
      {
          try
          {
              // Hole nächsten Zeitstring vom Server
              String time = inStream.ReadLine();
              
              // Setze das Schleifen-Flag zurück
              // wenn der Server aufgehört hat zu senden
              loop = !time.Equals("");
              
              // Gib die Zeit auf der Console aus
              Console.WriteLine(time);
          }
          catch (Exception)
          {
              // Setze das Schleifen-Flag zurück
              // wenn ein Fehler in der Kommunikation aufgetreten ist
              loop = false;
          }
      }
      
      // Schließe die Verbindung zum Server
      c.Close();
  }
}

class ServerThread
{
    // Stop-Flag
    public bool stop = false;

    // Flag für "Thread läuft"
    public bool running = false;

    // Die Verbindung zum Client
    private TcpClient connection = null;

    // Speichert die Verbindung zum Client und startet den Thread
    public ServerThread(TcpClient connection)
    {
        // Speichert die Verbindung zu Client,
        // um sie später schließen zu können
        this.connection = connection;

        // Initialisiert und startet den Thread
        new Thread(new ThreadStart(Run)).Start();
    }
    // Der eigentliche Thread
    public void Run()
    {
        // Setze Flag für "Thread läuft"
        this.running = true;

        // Hole den Stream für's schreiben
        Stream outStream = this.connection.GetStream();
        String buf = null;
        bool loop = true;

        while (loop)
        {
            try
            {
                // Hole die aktuelle Zeit als String
                String time = DateTime.Now.ToString();

                // Sende Zeit nur wenn sie sich von der vorherigen unterscheidet
                if (!time.Equals(buf))
                {
                    // Wandele den Zeitstring in ein Byte-Array um
                    // Es wird noch ein Carriage-Return-Linefeed angefügt
                    // so daß das Lesen auf Client-Seite einfacher wird
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(time + "\r\n");
                    // Sende die Bytes zum Client
                    outStream.Write(sendBytes, 0, sendBytes.Length);
                    // Merke die Zeit
                    buf = time;
                }

                // Wiederhole die Schleife so lange bis von außen der Stopwunsch kommt
                loop = !this.stop;
            }
            catch (Exception)
            {
                // oder bis ein Fehler aufgetreten ist
                loop = false;
            }
        }

        // Schließe die Verbindung zum Client
        this.connection.Close();

        // Setze das Flag "Thread läuft" zurück
        this.running = false;
    }
}