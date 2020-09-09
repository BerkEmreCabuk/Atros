using System;
using System.Collections.Generic;
using System.Text;
using Atros.Common.Exceptions;

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
                throw new UnprocessableException("Sender Email boş olamaz.");
            if (string.IsNullOrEmpty(this.UserName))
                throw new UnprocessableException("Username boş olamaz.");
            if (string.IsNullOrEmpty(this.Password))
                throw new UnprocessableException("Password boş olamaz.");
            if (string.IsNullOrEmpty(this.Host))
                throw new UnprocessableException("Host boş olamaz.");
            if (this.Port <= 0)
                throw new UnprocessableException("Port 0(sıfır)'dan büyük olmalıdır.");
        }
    }
}
