using System;
using System.Windows;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

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
        }

        CancellationTokenSource _cts;

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var watch = new Stopwatch();
            _cts = new CancellationTokenSource();

            watch.Start();
            var basta = new BastaManager();

            //Beide Laufen jetzt Parallel asynchron!
            var er1 = basta.LoadSpeakersAsync(_cts.Token,
                new Progress<int>((result) => progressbar1.Value = result));

            var er2 = basta.LoadSeesionsAsync();


            listViewSpeakers.ItemsSource = await er1;
            listViewSessions.ItemsSource = await er2;

            watch.Stop();

            MessageBox.Show((watch.ElapsedMilliseconds) + "ms");

        }

        private void cancelbutton1_Click(object sender, RoutedEventArgs e)
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
            }
        }
    }
}
