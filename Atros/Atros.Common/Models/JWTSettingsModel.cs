using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Common.Models
{
    public class JWTSettingsModel
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
