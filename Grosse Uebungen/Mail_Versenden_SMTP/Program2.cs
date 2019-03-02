using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;

namespace Mail_Versenden_SMTP2
{
    class Program
    {
        static void _Main(string[] args)
        {
            MailMessage mail = new MailMessage("xxxxxxxxx@bluewin.ch", "xxxxxxxxx@bluewin.ch", "Nachfrage :/", "Hallo wie geht so :)\nGrüsse Nicolas");

            SmtpClient client = new SmtpClient("smtpauth.bluewin.ch", 587);

            try
            {
                client.Credentials = new NetworkCredential("xxxxxxxxx@bluewin.ch", "xxxxxxxxxxxxxxxxxxxxxxx");
                client.Send(mail);
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
