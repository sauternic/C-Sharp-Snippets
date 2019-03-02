using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Netzwerk
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        delegate void MeinDele(string strEmpf);
        Thread tr = null;
        
        
        private void Buttton_Ausloesen(object sender, RoutedEventArgs e)
        {
            this.tr = new Thread(new ThreadStart(HintergrundThread));
            tr.Start();
        }

        private void Button_Stoppen(object sender, RoutedEventArgs e)
        {
            tr.Abort();
        }


        private void HintergrundThread()
        {
            //Vorarbeit!! :)
            //string strEmpf = "";
            byte[] puffer_Senden = new byte[100000];
            byte[] puffer_Empfangen = new byte[100000];
            int iEmpfByt_Senden = 0;
            int iEmpfByt_Empfangen = 0;
            
            Socket Sock_Server = null;
            Socket Sock_Ziel = null;
            Socket Sock_Local = null;
            IPEndPoint IP_EP_PC = null;
            IPEndPoint IP_EP_Internet = null;
            
            IP_EP_PC = new IPEndPoint(IP_Parse("127.0.0.1"), 80);
            IP_EP_Internet = new IPEndPoint(IP_Parse("62.178.17.143"), 80);

            Sock_Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Sock_Ziel = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

  
            try
            {
                Sock_Server.Bind(IP_EP_PC);
                Sock_Server.Listen(5);
            }
            catch (Exception) { }
            
           
            //Wartet auf Anfrage von Localhost! :)  
            Sock_Local = Sock_Server.Accept();

           
            //Mit Ziel Verbindung Aufnehmen
            if (!Sock_Ziel.Connected)
                Sock_Ziel.Connect(IP_EP_Internet);
            if (!Sock_Ziel.Connected)
                MessageBox.Show("Keine Verbindung zum Ziel im Internet");

            // Hier ist Empfangen und Senden!!               
            do
            {
                //Zum Ziel Senden
                if (Sock_Local.Available > 0)
                {
                    iEmpfByt_Senden = Sock_Local.Receive(puffer_Senden);
                    try
                    {
                        if (Sock_Ziel.Connected)
                            Sock_Ziel.Send(puffer_Senden, 0, iEmpfByt_Senden, 0);
                    }
                    catch (Exception e) { MessageBox.Show("Exception Sock_Ziel\n" + e.Message); }
                }


                //Vom Ziel Empfangen
                if (Sock_Ziel.Available > 0)
                {
                    iEmpfByt_Empfangen = Sock_Ziel.Receive(puffer_Empfangen);
                    try
                    {
                        if (Sock_Local.Connected)
                            Sock_Local.Send(puffer_Empfangen, 0, iEmpfByt_Empfangen, 0);
                    }
                    catch (Exception e) { MessageBox.Show("Exception Sock_Local\n" + e.Message); }
                }
                    
            }//Ende Do
            while (iEmpfByt_Senden > 0 || iEmpfByt_Empfangen > 0);
            Sock_Local.Close();

            Sock_Server.Shutdown(SocketShutdown.Both);
            Sock_Ziel.Shutdown(SocketShutdown.Both);
            Sock_Local.Shutdown(SocketShutdown.Both);
        
        
        }

        #region Hilsmethoden ###############################################################################
        private IPAddress IP_Parse(string strIP)
        {
            IPAddress IP_Parse = IPAddress.Parse(strIP);
            return IP_Parse;
        }
        #endregion Ende Hilsmethoden ###############################################################################
    }
}
