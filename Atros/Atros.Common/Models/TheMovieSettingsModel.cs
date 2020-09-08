using System;
using System.Collections.Generic;
using System.Text;

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
                throw new Exception("Api Key boş olamaz.");
            if (string.IsNullOrEmpty(this.Url))
                throw new Exception("Url boş olamaz.");
            if (string.IsNullOrEmpty(this.Language))
                throw new Exception("Language boş olamaz.");
            if (this.MaxPageSize <= 0)
                throw new Exception("MaxPageSize 0(sıfır)'dan büyük olmalıdır.");
            if (this.MaxMovieCount <= 0)
                throw new Exception("MaxMovieCount 0(sıfır)'dan büyük olmalıdır.");
        }
    }
}
