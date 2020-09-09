using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Common.Exceptions
{
    public class NotAcceptableException : BaseException
    {
        public NotAcceptableException() : base()
        {
            this.Message = "İstek Uygun formatta değildir.";
            this.StatusCode = StatusCodes.Status406NotAcceptable;
        }
        public NotAcceptableException(string message) : base(message)
        {
            this.StatusCode = StatusCodes.Status406NotAcceptable;
        }

        public NotAcceptableException(Exception innerException, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            this.StatusCode = StatusCodes.Status406NotAcceptable;
        }
    }
}
