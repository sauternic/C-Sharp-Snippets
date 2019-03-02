using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;

namespace Mail_Versenden_SMTP3
{
    class Program
    {
        static void Main(string[] args)
        {
            SmtpClient client = new SmtpClient("smtpauth.bluewin.ch", 587);
            try
            {
                client.Credentials = new NetworkCredential("xxxxxxxxx@bluewin.ch", "xxxxxxxxxxxxxxxxxxxx");
                client.Send("xxxxxxxxx@bluewin.ch", "xxxxxxxxx@bluewin.ch", "Betreff: Grüsse","Hallo vom der einfachsten Variante");
                Console.WriteLine("Mail Gesendet! :)))");
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                client.Dispose();
                Console.ReadKey();
            }
        }
    }
}
