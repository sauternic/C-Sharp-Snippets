using System;
using System.IO;
using System.IO.Compression;

namespace xor_test
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs1 = File.OpenRead(@"C:\Ausgabe\K_V_Pad_Insekt.jpg");
            FileStream fs2 = File.OpenRead(@"C:\Ausgabe\Schl_Pad_Insekt.jpg");
            FileStream fs3 = File.OpenWrite(@"C:\Ausgabe\Insekt_W.jpg");

            int i, ii;

            while (true)
            {
                i = fs1.ReadByte();
                ii = fs2.ReadByte();
                if (ii == -1)
                    break;

                //xor und in den Stream
                fs3.WriteByte((byte)(i ^ ii));
            }

            fs3.Close();
            fs2.Close();
            fs1.Close();

            //Dekompression
            DeflateStream decomp = new DeflateStream(File.OpenRead(@"C:\Ausgabe\Insekt_W.jpg"), CompressionMode.Decompress);
            decomp.CopyTo(File.Create(@"C:\Ausgabe\Insekt_W_Dek.jpg"));

            decomp.Close();


        }
    }
}
