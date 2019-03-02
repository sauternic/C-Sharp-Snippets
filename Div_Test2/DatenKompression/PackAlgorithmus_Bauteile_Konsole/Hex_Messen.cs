using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PackAlgorithmus_Bauteile_Konsole
{
    class Hex_Messen
    {
        static void ain()
        {
            byte[] by = Hex_byteArr("ffee34220a");
           

        }



        private static byte[] Hex_byteArr(string strHex)
        {
            byte[] byArr = new byte[(strHex.Length / 2)];
            string strTemp = "";

            for (int x = 0; x < (strHex.Length/2); ++x)
            {
                strTemp = strHex.Substring((x*2), 2);
                byArr[x] = Convert.ToByte(strTemp, 16);
            }
            return byArr;
        }

        private static void Messen()
        {
            //Messen
            long lmesspunkt1 = DateTime.Now.Ticks;

            Thread.Sleep(100);

            long lmesspunkt2 = DateTime.Now.Ticks;

            double dblZeitspanneTicks = lmesspunkt2 - lmesspunkt1;
            double dblZeitspanneMili = dblZeitspanneTicks / 10000;

            Console.WriteLine("Milisekunden: {0:#,0.#############}", dblZeitspanneMili);

        }

       
        
        private static string IntByte_Hex(int i)
        { 
            string str;
            
            if (i > 255)
                throw new System.ArgumentException("Byte Wert zu gross!: " + i);
            if (i < 0)
                throw new System.ArgumentException("Byte Wert kleiner als 0!: " + i);
            
            str = Convert.ToString(i, 16);
            if (str.Length < 2)
             str = "0" + str;
            
            return str;
        }
    }
}
