using System;
using System.Collections.Generic;
using System.Text;
using Atros.Common.Exceptions;

namespace Atros.Common.Models
{
    public class TheMovieSettingsModel
    {
        public string Url { get; set; }
        public string ApiKey { get; set; }
        public string Language { get; set; }
        public int MaxPageSize { get; set; }
        public int MaxMovieCount { get; set; }
        public void CheckModel()
        {
            if (string.IsNullOrEmpty(this.ApiKey))
                throw new UnprocessableException("Api Key boş olamaz.");
            if (string.IsNullOrEmpty(this.Url))
                throw new UnprocessableException("Url boş olamaz.");
            if (string.IsNullOrEmpty(this.Language))
                throw new UnprocessableException("Language boş olamaz.");
            if (this.MaxPageSize <= 0)
                throw new UnprocessableException("MaxPageSize 0(sıfır)'dan büyük olmalıdır.");
            if (this.MaxMovieCount <= 0)
                throw new UnprocessableException("MaxMovieCount 0(sıfır)'dan büyük olmalıdır.");
        }
    }
}
