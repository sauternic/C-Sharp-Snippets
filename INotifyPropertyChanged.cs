************************************MainWindow.xaml.cs**********************************************************

// Interface 'INotifyPropertyChanged' ist um Änderungen im cs-Code im WPF-UI sichbar zu machen.

using System.ComponentModel;
using System.Windows;


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
            
			//DataContext:
			//Dann kann im XAML ganz einfach mit 'Text="{Binding Path=Name}"' zuggegriffen werden.
			this.textblock1.DataContext = cMeine;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cMeine.Name = "geändert!!";
        }

    }


    // Interface 'INotifyPropertyChanged' ist um Änderungen in WPF sichbar zu machen.
    // Alternativ 'Name' als Dependency-Property Registrieren :) 
    public class CMeine : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public CMeine()
        {
            this.Name = "Sauter";
        }

        //Private field
        private string _Name;
        //Property 'Name'
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }

        }

    }

}

*************************************MainWindow.xaml********************************************************************

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

