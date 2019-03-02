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

//namespace Netzwerk
//{
//    /// <summary>
//    /// Interaktionslogik für MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        delegate void MeinDele(string strEmpf);
        
        
//        private void Buttton_Ausloesen(object sender, RoutedEventArgs e)
//        {
//            Thread tr = new Thread(new ThreadStart(HintergrundThread));
//            tr.Start();
//        }

//        private void HintergrundThread()
//        {
//            //Vorarbeit!! :)
//            string strEmpf = "";
//            byte[] puffer = new byte[256];
//            IPEndPoint IP_EP = new IPEndPoint(IP_Parse("127.0.0.1"), 81);
//            Socket Sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//            int iEmpfByt = 0;
            
//            //Arbeit! :)
//            Sock.Bind(IP_EP);
//            Sock.Listen(5);

//            //Wartet auf Anfrage! :)  
//            Socket Sock_Neu = Sock.Accept();


//            //Empfangene Daten Auslesen.
//            do
//            {
//                iEmpfByt = Sock_Neu.Receive(puffer);
//                strEmpf += Encoding.ASCII.GetString(puffer, 0, iEmpfByt);
//            }
//            while (iEmpfByt > 0);
            
//            Sock_Neu.Shutdown(SocketShutdown.Both);
//            Sock_Neu.Close();
           
//            this.Dispatcher.Invoke(new MeinDele(vordergrund), strEmpf);
//            //Runterfahren! :/
//        }
        
//        #region Hilsmethoden ###############################################################################
//        private void vordergrund(string strEmpf)
//        {
//            //TextBox Füllen im UI Thread
//            TextBox_Ausgabe.Text = strEmpf;   
//        }

//        private IPAddress IP_Parse(string strIP)
//        {
//            IPAddress IP_Parse = IPAddress.Parse(strIP);
//            return IP_Parse;
//        }
//        #endregion Ende Hilsmethoden ###############################################################################
//    }
//}
