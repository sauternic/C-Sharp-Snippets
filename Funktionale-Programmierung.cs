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

        // Kleines Beispiel angewandter funktionaler Programmierung wie im Video von Rainer Sropek:
        // https://www.youtube.com/watch?v=8vQ15jddRBM

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Zeitmessung(async (dk) =>
            {
                //Alles hier wir quasi in die 'Zeitmessung()' Methode beim body Aufruf reingereicht! :/
                cts = new CancellationTokenSource();

                
                //3. Token Mitgeben
                var erg1 = dk.LadeSpekaersAsync(cts.Token, new Progress<int>());
                var erg2 = dk.LadeSessionsAsync();

                listview1.ItemsSource = await erg1;
                listview2.ItemsSource = await erg2;
            });
        }

        // 'Func<DatenKlasse, Task>': ist nichts anderes als ein vordefinierter Delegate der
        // eine Methode kapselst die einen 'Task' zurückgibt und einen Parameter vom Typ 'DatenKlasse' definiert.

        async Task Zeitmessung(Func<DatenKlasse,Task> body)//<- Das ist entscheidend für das Verhalten der Lamda oben! :/
        {
            var uhr = new Stopwatch();
            {
                uhr.Start();

                // Das hier um zu zeigen wie man es in 'body()' bringt(Als Parameter 'dk')
                var dk = new DatenKlasse();

                //Hier kommen die Codezeilen von der Lamdaexpression in den geschweiften Klammern {...}
                await body(dk);

                uhr.Stop();
                MessageBox.Show(uhr.ElapsedMilliseconds + "ms");
            }
        }

        CancellationTokenSource cts;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
         
            if (cts != null)
                cts.Cancel();
        }
    }
}
