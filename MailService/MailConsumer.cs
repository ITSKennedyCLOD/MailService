using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailService.DTO;
using MailService.Interfaces;
using MassTransit;


namespace MailService
{
    public class MailConsumer : IConsumer<MailEvent>
    {
        private readonly IMailSenderService _mailService;

        public MailConsumer(IMailSenderService mailService)
        {
            _mailService = mailService;
        }

        public Task Consume(ConsumeContext<MailEvent> context)
        {
            _mailService.SendMail(context.Message);

            return Task.CompletedTask;
        }
    }
}
