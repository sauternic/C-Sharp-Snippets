**************************************MainWindow.xaml.cs************************************************************

using System.ComponentModel;
using System.Windows;
using System;

// Static Variante von 'INotifyPropertyChanged':
// Event 'StaticPropertyChanged' ist um Änderungen im cs-Code im WPF-UI sichbar zu machen.

namespace WpfApp2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            //Keine Zuweisung zum DataContext möglich

            //Einbindung der statischen Klasse 'CMeine' mit Member 'Name' über xaml:
            //Text="{Binding Path=(local:CMeine.Name)}"

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CMeine.Name = "geändert!!";
        }

    }


    // Event fild 'StaticPropertyChanged' ist um Änderungen im cs-Code im WPF-UI sichbar zu machen.
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

********************************MainWindow.xaml**************************************************************************

<Window x:Class="WpfApp2.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp2"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid Background="Aquamarine">
        <TextBlock Name="textblock1" Text="{Binding Path=(local:CMeine.Name)}"  Background="White" HorizontalAlignment="Left" Height="22" Margin="166,120,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="387"/>
        <Button Content="Property Ändern" HorizontalAlignment="Left" Height="46" Margin="261,255,0,0" VerticalAlignment="Top" Width="208" Click="Button_Click"/>

    </Grid>
 </Window>

