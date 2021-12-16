using MailService.DTO;
using MailService.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailService.Services
{
    public class MailSenderService : IMailSenderService
    {
        private readonly string From;
        private readonly string Server;


        public MailSenderService(IConfiguration configuration)
        {
            From = configuration.GetSection("Mail")["From"];
            Server = configuration.GetSection("Mail")["Server"];

        }

        public void SendMail(MailEvent mail)
        {
            
            MailMessage message = new MailMessage(From, mail.To);
            
            message.Subject = mail.Subject;
            
            message.Body = mail.Body;
            
            SmtpClient client = new SmtpClient(Server);


            client.UseDefaultCredentials = true;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
            }
        }
    }
}
