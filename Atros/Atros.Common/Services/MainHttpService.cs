using Atros.Common.Exceptions;
using Atros.Common.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Atros.Common.Services
{
    public class MainHttpService : IMainHttpService
    {
        private readonly HttpClient _client;

        public MainHttpService(
            HttpClient client)
        {
            _client = client;
        }
        public async Task<HttpResponseMessage> HttpRequest(string url, HttpMethod httpMethod)
        {
            return await HttpRequest(url, httpMethod, string.Empty);
        }

        public async Task<HttpResponseMessage> HttpRequest(string url, HttpMethod httpMethod, string contentJson)
        {
            using (var request = new HttpRequestMessage(httpMethod, url))
            {
                if (!String.IsNullOrEmpty(contentJson))
                {
                    var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                    request.Content = content;
                }

                var response = await _client.SendAsync(request);
                if ((int)response.StatusCode == 422)//UnprocessableEntity
                {
                    var result = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<string>>>(await response.Content.ReadAsStringAsync())?.FirstOrDefault();
                    if (result.HasValue)
                        throw new NotificationException(result.Value.Value.FirstOrDefault(), result.Value.Key);
                }
                return response;
            }
        }
    }
}
