using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Common.Exceptions
{
    public class UnprocessableException : BaseException
    {
        public UnprocessableException() : base()
        {
            this.Message = "Hatalı Model";
            this.StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
        public UnprocessableException(string message) : base(message)
        {
            this.Message = message;
            this.StatusCode = StatusCodes.Status422UnprocessableEntity;
        }

        public UnprocessableException(Exception innerException, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            this.Message = message;
            this.StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
    }
}
