using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atros.Common.Services.Interfaces
{
    public interface IMailService
    {
        Task SendMail(string toEmail, string subject);
    }
}
