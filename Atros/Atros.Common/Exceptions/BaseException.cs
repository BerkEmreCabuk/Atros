using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Common.Exceptions
{
    public class BaseException : Exception
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public BaseException() : base()
        {
        }
        public BaseException(string message) : base(message)
        {
            this.Message = message;
        }

        public BaseException(string message, Exception innerException, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            this.Message = message;
        }
    }
}
