using  System;

namespace Schachbrett
{
    class Program_Testen
    {
        static void Main()
        {
            CSchachbrett Obj = new CSchachbrett(4);


            Console.WriteLine("Im Feld Nr:{0} hats {1} Körner und\ninsgesamt liegen " +
            "schon {2} Körner auf dem Brett! :)",Obj.FeldNr,Obj.MengeImFeld,Obj.MengeGes);
            
            
   
            
            Console.Write(CSchachbrett.Autor + "\n\n\n");

        
        }
    }      
}
