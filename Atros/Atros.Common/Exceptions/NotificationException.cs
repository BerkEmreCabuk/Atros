using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Common.Exceptions
{
    public class NotificationException : Exception
    {
        public string Notification { get; set; }
        public string Subject { get; private set; } = "Uyarı";
        /// <param name="notification">Bilgilendirme Mesajı</param>
        /// <param name="subject">Konu</param>
        /// <returns></returns>
        public NotificationException(string notification, string subject = "Uyarı") : base(notification)
        {
            this.Notification = notification;
            Subject = subject;
        }

        public NotificationException(Exception innerException, string notification, params object[] args)
            : base(string.Format(notification, args), innerException)
        {
            Notification = notification;
        }
    }
}
