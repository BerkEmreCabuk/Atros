using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Atros.Common.Services.Interfaces
{
    public interface IMainHttpService
    {
        Task<HttpResponseMessage> HttpRequest(string url, HttpMethod httpMethod);
        Task<HttpResponseMessage> HttpRequest(string url, HttpMethod httpMethod, string contentJson);
    }
}
