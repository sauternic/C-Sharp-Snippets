*******************************************MainWindow.xaml.cs******************************************************

using System.ComponentModel;
using System.Windows;

// Beispiel:
// Property 'Name' als Dependency-Property Registrieren um 
// Änderungen im WPF-UI sichtbar zu machen.
// Eigene Klasse muss von 'DependencyObject' abgeleitet werden.


namespace WpfApp2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CMeine cMeine;

        public MainWindow()
        {
            InitializeComponent();
            cMeine = new CMeine();
            this.textblock1.DataContext = cMeine;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cMeine.Name = "geändert!!";
        }

    }


    // Property'Name' als Dependency-Property Registrieren :) 
    // Alternativ INotifyPropertyChanged implementieren
    public class CMeine : DependencyObject
    {
        public CMeine()
        {
            this.Name = "Sauter";
        }

        //Hier ist das Herz mit der Register() Methode! (Statt eines private field _Name)
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(CMeine));

   
        public string Name
        {
            get
            {
                return (string)GetValue(NameProperty);
            }
            set
            {
                SetValue(NameProperty, value);
            }

        }

    }

}

*******************************************************MainWindow.xaml***************************************************************

<Window x:Class="WpfApp2.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp2"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid Background="Aquamarine">
        <TextBlock Name="textblock1" Text="{Binding Path=Name}"  Background="White" HorizontalAlignment="Left" Height="22" Margin="166,120,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="387"/>
        <Button Content="Property Ändern" HorizontalAlignment="Left" Height="46" Margin="261,255,0,0" VerticalAlignment="Top" Width="208" Click="Button_Click"/>

    </Grid>
</Window>

