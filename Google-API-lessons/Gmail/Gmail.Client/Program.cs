using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Gmail.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get credentials
            Console.Write("Enter your email address:");
            var email = Console.ReadLine();
            Console.Write("Enter your name:");
            var name = Console.ReadLine();
            Console.Write("Enter your password:");
            var fromPassword = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Sending a test email from Gmail");
            var fromAddress = new MailAddress(email, name);
            var toAddress = new MailAddress(email, name);
            const string subject = "This is a test";
            const string body = "Yeah!";

            Console.WriteLine("Sending email...");
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
            Console.WriteLine("Done!");
            Console.Read();
        }
    }
}
