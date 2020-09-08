using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Common.Models
{
    public class EmailSettingsModel
    {
        public string SenderEmail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public void CheckModel()
        {
            if (string.IsNullOrEmpty(this.SenderEmail))
                throw new Exception("Sender Email boş olamaz.");
            if (string.IsNullOrEmpty(this.UserName))
                throw new Exception("Username boş olamaz.");
            if (string.IsNullOrEmpty(this.Password))
                throw new Exception("Password boş olamaz.");
            if (string.IsNullOrEmpty(this.Host))
                throw new Exception("Host boş olamaz.");
            if (this.Port <= 0)
                throw new Exception("Port 0(sıfır)'dan büyük olmalıdır.");
        }
    }
}
