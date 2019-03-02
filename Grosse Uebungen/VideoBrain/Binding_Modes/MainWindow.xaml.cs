using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Binding_Modes
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _message;
        
        public string Message 
        {
            get { return _message; }     
            set 
            {
                _message = value;
                EventAufruf();
            } 
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Message = "Es geeeeeht! :@";
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void EventAufruf()
        {
            PropertyChanged(this, new PropertyChangedEventArgs("Message"));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = _message;
        }
    
    
    }
}
