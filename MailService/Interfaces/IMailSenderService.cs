using MailService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailService.Interfaces
{
    public interface IMailSenderService
    {
        public void SendMail(MailEvent mail);
    }
}
