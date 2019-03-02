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


namespace Netzwerk
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

//        private void Buttton_Ausloesen(object sender, RoutedEventArgs e)
//        {

//            //Vorarbeit!! :)
//            IPEndPoint IP_EP = new IPEndPoint(IP_Parse("62.178.17.143"), 80);
//            Socket Sock = new Socket(IP_EP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

//            //Textdatei Einlesen
//            string str_Erge = System.IO.File.ReadAllText("C:\\Ausgabe\\request.txt");
            
//            byte[] by_Erge = Encoding.ASCII.GetBytes(str_Erge);
//;            
            
//            //Verbindungs Arbeit! :)
//            //Client :)
//            Sock.Connect(IP_EP);

//            // Verbindung Prüfen! :)
//            if (Sock.Connected)
//            {
               
//                Sock.Send(by_Erge);
//                TextBlock_Info.Text = "Gesendet! :)";
//            }

//            //Runterfahren! :/
//            Sock.Shutdown(SocketShutdown.Both);
//            Sock.Close();
//        }

//        #region Hilsmethoden ###############################################################################
//        private IPAddress IP_A(string strURL)
//        {
//            IPAddress[] IP_A_Arr = Dns.GetHostAddresses(strURL);
//            return IP_A_Arr[0];
//        }

//        private IPAddress IP_Parse(string strIP)
//        {
//            IPAddress IP_Parse = IPAddress.Parse(strIP);
//            return IP_Parse;
//        }
//        #endregion Ende Hilsmethoden ###############################################################################
    }
}
