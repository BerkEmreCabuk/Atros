using Atros.Common.Models;
using Atros.Common.Services.Interfaces;
using Atros.Domain.Movies.Models;
using MediatR;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atros.Domain.Movies.Queries
{
    public class GetAllMoviesFromSiteQueryHandler : IRequestHandler<GetAllMoviesFromSiteQuery, List<MovieModel>>
    {
        private readonly IOptions<TheMovieSettingsModel> _options;
        private readonly IMainHttpService _mainHttpService;
        public GetAllMoviesFromSiteQueryHandler(
            IOptions<TheMovieSettingsModel> options,
            IMainHttpService mainHttpService
            )
        {
            _options = options;
            _mainHttpService = mainHttpService;
        }

        public async Task<List<MovieModel>> Handle(GetAllMoviesFromSiteQuery request, CancellationToken cancellationToken)
        {
            _options.Value.CheckModel();
            var resultMovies = new List<MovieModel>();

            for (int page = 1; page <= _options.Value?.MaxPageSize; page++)
            {
                string url = $"{_options.Value.Url}?api_key={_options.Value.ApiKey}&language={_options.Value.Language}&page={page}";
                var response = await _mainHttpService.HttpRequest(url, HttpMethod.Get);
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.RequestTimeout)
                        throw new TimeoutException();
                    throw new Exception($"{_options.Value.Url} servis bağlantı hatası, Hata:  {await response.Content.ReadAsStringAsync()} Status Kodu: {response.StatusCode}");
                }

                var returnJson = await response.Content.ReadAsStringAsync();
                var movieResponseModel = JsonConvert.DeserializeObject<MovieResponseModel>(returnJson);
                if (movieResponseModel.Results.Any() && resultMovies.Count < _options.Value.MaxMovieCount)
                {
                    resultMovies.AddRange(movieResponseModel.Results);
                }
                else
                    break;
            }
            return resultMovies;
        }
    }
}
