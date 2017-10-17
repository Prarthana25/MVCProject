using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Concrete
{
    public class EmailSetting
    {
        public string MailToAddress = "prarthana@gmail.com";
        public string MailFromAddress = "prarthana@gmail.com";
        public bool UseSsl = true;
        public string Username = "prarthana@gmail.com";
        public string Password = ""; 
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
    }
}
