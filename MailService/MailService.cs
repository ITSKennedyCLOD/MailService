using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailService
{
    public class MailService
    {
        public String To { get; set; }
        public String Cc { get; set; }
        public String Ccn { get; set; }
        public String Subject { get; set; }
        public String Body { get; set; }
    }
}
