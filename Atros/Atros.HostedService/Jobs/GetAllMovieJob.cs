using Atros.Domain.Movies.Commands;
using Atros.Domain.Movies.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atros.HostedService.Jobs
{
    [DisallowConcurrentExecution]
    public class GetAllMovieJob : IJob
    {
        private readonly ILogger<GetAllMovieJob> _logger;
        private readonly IServiceProvider _provider;
        private bool isExecute = false;
        public GetAllMovieJob(
            ILogger<GetAllMovieJob> logger,
            IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                if (isExecute)
                    return;
                isExecute = true;
                using (var scope = _provider.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetService<IMediator>();
                    var movies = await mediator.Send(new GetAllMoviesFromSiteQuery());
                    if (!movies.Any())
                    {
                        _logger.LogWarning("Kaynak siteden herhangi bir film alınamadı.");
                        return;
                    }
                    await mediator.Send(new BulkSynchronizeCommand() { MovieModels=movies});
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
