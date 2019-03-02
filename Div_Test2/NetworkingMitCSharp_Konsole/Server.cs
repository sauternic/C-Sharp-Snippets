using System;
using System.Text;
using System.Collections;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using System.Net;

public class TimeServer
{
    // Der Listener
    private static TcpListener listener = null;
    
    // Die Liste der laufenden Server-Threads
    private static ArrayList threads = new ArrayList();
    
    // Die Hauptfunktion des Servers
    public static void Main()
    {
        // Listener initialisieren und starten
        listener = new TcpListener(IPAddress.Parse("127.0.0.1"),4711);
        listener.Start();
        
        // Haupt-Server-Thread initialisieren und starten
        Thread th = new Thread(new ThreadStart(Run));
        th.Start();
        
        // Benutzerbefehle entgegennehmen
        String cmd = "";
        while (!cmd.ToLower().Equals("stop"))
        {
            cmd = Console.ReadLine();//Hier wird Blockiert bis eine Benutzereingabe kommt! :/
            if (!cmd.ToLower().Equals("stop"))
                Console.WriteLine("Unbekannter Befehl: " + cmd);
        }
        
        // Haupt-Server-Thread stoppen
        th.Abort();
        
        // Alle Server-Threads stoppen
        //for (IEnumerator e = threads.GetEnumerator(); e.MoveNext(); )
        //{
        //    // Nächsten Server-Thread holen
        //    ServerThread st = (ServerThread)e.Current;
        //    // und stoppen
        //    st.stop = true;
        //    while (st.running)
        //        Thread.Sleep(1000);
        //}
        //Mein Versuch mit foreach
        foreach (ServerThread st in threads)
        {
            st.stop = true;
            while (st.running)
                Thread.Sleep(1000);
        }

        
        // Listener stoppen
        listener.Stop();
    }
    
    // Hauptthread des Servers
    // Nimmt die Verbindungswünsche von Clients entgegen
    // und startet die Server-Threads für die Clients
    public static void Run()
    {
        while (true)
        {
            // Wartet auf eingehenden Verbindungswunsch
            TcpClient c = listener.AcceptTcpClient();
            
            // Initialisiert und startet einen Server-Thread
            // und fügt ihn zur Liste der Server-Threads hinzu
            threads.Add(new ServerThread(c));
        }
    }
}

