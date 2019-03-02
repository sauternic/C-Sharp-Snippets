using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ByteWeiseInAndereDatei
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryReader binaryReader = new BinaryReader
                (new FileStream("C:\\Ausgabe\\uben.wmv", FileMode.Open));
            BinaryWriter binaryWriter = new BinaryWriter
                (new FileStream("C:\\Ausgabe\\Copy_uben.wmv", FileMode.Create));

            try
            {
                while (true)
                {
                    binaryWriter.Write(binaryReader.ReadByte());
                }
            }
            catch (Exception)
            {
                //Alles Schliessen! ;)
                binaryReader.Close();
                binaryWriter.Close();
            
            }

          
        
        
        }
    }
}