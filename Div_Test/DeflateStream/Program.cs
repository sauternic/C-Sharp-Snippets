using System;
using System.IO;
using System.IO.Compression;

namespace DeflateStream_
{
    public class Program
    {

        public static void Main()
        {
            DeflateStream comp = new DeflateStream(File.Create(@"C:\Ausgabe\komp_test.txt"), CompressionMode.Compress);
            File.OpenRead(@"C:\Ausgabe\test.txt").CopyTo(comp);

            comp.Close();
        }
        public static void _Main()
        { 
            DeflateStream decomp = new DeflateStream(File.OpenRead(@"C:\Ausgabe\komp_test.txt"), CompressionMode.Decompress);      
            decomp.CopyTo(File.Create(@"C:\Ausgabe\test.txt"));

            decomp.Close();
        }
    }

}
