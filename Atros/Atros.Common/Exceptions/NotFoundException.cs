using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Common.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException() : base()
        {
            this.Message = "Kayıt Bulunamadı";
            this.StatusCode = StatusCodes.Status404NotFound;
        }
        public NotFoundException(string message) : base(message)
        {
            this.Message = message;
            this.StatusCode = StatusCodes.Status404NotFound;
        }

        public NotFoundException(Exception innerException, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            this.Message = message;
            this.StatusCode = StatusCodes.Status404NotFound;
        }
    }
}
