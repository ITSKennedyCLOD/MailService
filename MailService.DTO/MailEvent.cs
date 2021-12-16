using System;

namespace MailService.DTO
{
    public class MailEvent
    {
        public String To { get; set; }
        public String Cc { get; set; }
        public String Ccn { get; set; }
        public String Subject { get; set; }
        public String Body { get; set; }
    }
}
