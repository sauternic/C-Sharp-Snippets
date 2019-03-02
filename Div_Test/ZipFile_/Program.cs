using System;
using System.IO;
using System.IO.Compression;

namespace Verschlüsseln_Klassen
{
    class Program
    {
        static void _Main(string[] args)
        {

            ZipFile.CreateFromDirectory(@"C:\Ausgabe\n", @"C:\Ausgabe\Doku.zip");

            ZipFile.ExtractToDirectory(@"C:\Ausgabe\Doku.zip", @"C:\Ausgabe\target");


        }
    }
}
