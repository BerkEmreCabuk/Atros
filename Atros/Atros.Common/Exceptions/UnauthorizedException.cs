using System;
using Microsoft.AspNetCore.Http;

namespace Atros.Common.Exceptions
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException() : base()
        {
            this.Message = "Authorization bilgisi bulunamamaktadır";
            this.StatusCode = StatusCodes.Status408RequestTimeout;
        }
        public UnauthorizedException(string message) : base(message)
        {
            this.Message = message;
            this.StatusCode = StatusCodes.Status408RequestTimeout;
        }

        public UnauthorizedException(Exception innerException, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            this.Message = message;
            this.StatusCode = StatusCodes.Status408RequestTimeout;
        }
    }
}