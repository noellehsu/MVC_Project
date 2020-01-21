using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace MailConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //利用Gmail SMTP發信
            //gmail要改成兩步驟驗證
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new System.Net.NetworkCredential("ohyanana2@gmail.com", "jxdfyrwolkriwjka"),
                EnableSsl = true
            };
            client.Send("ohyanana2@gmail.com", "ohyanana2@gmail.com", "test", "testbody");
            Console.WriteLine("Sent");
            Console.ReadLine();
        }
    }
}
