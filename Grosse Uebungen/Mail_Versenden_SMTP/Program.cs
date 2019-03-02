using System;
using System.Net;
using System.Net.Mail;

namespace Mail_Versenden_SMTP1
{
    class Program
    {
        static void _Main(string[] args)
        {
            MailMessage mail = new MailMessage("xxxxxxxxx@bluewin.ch", "xxxxxxxxx@bluewin.ch", "Betreff", "Hallo");
/*
            https://msdn.microsoft.com/de-de/library/system.net.mail.smtpclient.enablessl(v=vs.110).aspx


            Eine alternative Verbindungsmethode ist, in dem vorab eine SSL-Sitzung vor jedem Protokoll
            eingerichtet wird gesendet werden.Diese Verbindungsmethode wird manchmal als SMTP/ SSL, SMTP 
            oder SMTPS und standardmäßig Port 465 verwendet.Diese alternative Verbindungsmethode mit SSL 
            wird derzeit nicht unterstützt.

*/
           SmtpClient client = new SmtpClient("smtpauths.bluewin.ch", 465)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential("xxxxxxxxx@bluewin.ch", "xxxxxxxxxxxxxxxxxxxxxx"),
            };
            
            try
            {
                client.Send(mail);
                Console.WriteLine("Mail Gesendet! :)))");
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally 
            {
                Console.ReadKey();
            }


            
        
        }
    }
}
