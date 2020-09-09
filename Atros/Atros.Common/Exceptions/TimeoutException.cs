using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Common.Exceptions
{
    public class TimeoutException : BaseException
    {
        public TimeoutException() : base()
        {
            this.Message = "İstek zaman aşımına uğramıştır";
            this.StatusCode = StatusCodes.Status408RequestTimeout;
        }
        public TimeoutException(string message) : base(message)
        {
            this.Message = message;
            this.StatusCode = StatusCodes.Status408RequestTimeout;
        }

        public TimeoutException(Exception innerException, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            this.Message = message;
            this.StatusCode = StatusCodes.Status408RequestTimeout;
        }
    }
}
