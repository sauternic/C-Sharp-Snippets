using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace WpfApp2
{
    public class BastaManager
    {
        public Task<List<string>> LoadSpeakersAsync(CancellationToken token = default(CancellationToken),
            IProgress<int> progress = null)
        {
            return Task.Run(() =>
            {
                var list = new List<string>();
                for (int x = 1; x <= 10; x++)
                {
                    Thread.Sleep(500);

                    if (progress != null)
                    {
                        progress.Report(x * 10);
                    }
                    if (token.IsCancellationRequested)
                        return list;

                    list.Add("Nicolas " + x.ToString());
                }
                return list;
            });

        }

        public Task<List<string>> LoadSeesionsAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(3000);
                var list = new List<string>();
                for (int x = 1; x <= 10; x++)
                {
                    list.Add("Session " + x.ToString());
                }
                return list;
            });
        }
    }
}
