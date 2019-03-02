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
        public MainWindow()
        {
            InitializeComponent();
        }

       
        

        //private void Buttton_Ausloesen(object sender, RoutedEventArgs e)
        //{

        //    Vorarbeit!! :)
        //    IPEndPoint IP_EP = new IPEndPoint(IP_A("www.google.ch"), 80);
        //    Socket Sock = new Socket(IP_EP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);


            
        //    Verbindungs Arbeit! :)
        //    Client :)
        //    Sock.Connect(IP_EP);

        //     Verbindung Prüfen! :)
        //    if (Sock.Connected)
        //    {
        //        TextBlock_Info.Text = "Verbunden! :)";
        //    }


            
            
            
        //    Runterfahren! :/
        //    Sock.Shutdown(SocketShutdown.Both);  
        
        //}

        //#region Hilsmethoden ###############################################################################
        //private IPAddress IP_A(string strURL)
        //{
        //    IPAddress[] IPAArr = Dns.GetHostAddresses(strURL);
        //    return IPAArr[0];
        //}

        //private IPAddress IP_A(string strIP)
        //{
        //    IPAddress IPA = IPAddress.Parse(strIP);
        //    return IPA;
        //}
        //#endregion
    }
}
