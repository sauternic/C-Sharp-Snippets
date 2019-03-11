*********************************************MainWindow.xaml.cs***************************************************************

using System;
using System.Diagnostics;
using System.Windows;

// Beispiel Funtionale-Programmierung mit Rückgabe ohne return

namespace WpfApp1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Aufruf! Alles in Parameter des Aufrufers!
            Zeitmessung(() =>
            {
                // Hier der zu messende Code, wird in 'body' reingereicht:
                for (int x = 0; x < 1000000000; x++) ;
            },
            // 2.Parameter 'erg' zum Empfangen
            (ms)=> MessageBox.Show(ms + "ms"));

            
        }


        void Zeitmessung(Action body, Action<long> erg)
        {
            Stopwatch uhr = new Stopwatch();
            uhr.Start();

            //Der zu messende Code wird über den parameter 'body' reingereicht:
            body();

            uhr.Stop();

            //Vesenden des Ergebnisses über Parameter 'erg'!
            //Ist eigentlich ein normaler Funktionsaufruf der über den Parameter 'erg' rausgeht!!
            //Siehe als Beispiel ganz unten Methode 'void erg(long ms)'
            erg(uhr.ElapsedMilliseconds);
        }
        
        //void erg(long ms)
        //{
        //    MessageBox.Show(ms + "ms");
        //}

    }
}

***************************************************MainWindow.xaml*****************************************************************

<Window x:Class="WpfApp1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp1"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800" Background="Aquamarine">
    <Canvas>
        <Button Content="Button" Height="64" Canvas.Left="299" Canvas.Top="254" Width="158" Click="Button_Click"/>
        <TextBlock Name="textblock1" Height="95" Canvas.Left="223" TextWrapping="Wrap" Canvas.Top="73" Width="309" FontSize="48" Background="White"/>
        <ContentControl Content="ContentControl" Canvas.Left="1055" Canvas.Top="258"/>

    </Canvas>
</Window>
