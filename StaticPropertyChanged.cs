using System.ComponentModel;
using System.Windows;
using System;

// Static Variante von 'INotifyPropertyChanged':
// Event 'StaticPropertyChanged' ist um �nderungen im cs-Code im WPF-UI sichbar zu machen.

namespace WpfApp2
{
    /// <summary>
    /// Interaktionslogik f�r MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            //Keine Zuweisung zum DataContext m�glich

            //Einbindung der statischen Klasse 'CMeine' mit Member 'Name' �ber xaml:
            //Text="{Binding Path=(local:CMeine.Name)}"

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CMeine.Name = "ge�ndert!!";
        }

    }


    // Interface 'INotifyPropertyChanged' ist um �nderungen in WPF sichbar zu machen.
    // Alternativ 'Name' als Dependency-Property Registrieren :) 
    public static class CMeine
    {

        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;

        static CMeine()
        {
            CMeine.Name = "Sauter";
        }

        //Private field
        private static string _Name;
        //Property 'Name'
        public static string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs("Name"));
            }

        }

    }

}
