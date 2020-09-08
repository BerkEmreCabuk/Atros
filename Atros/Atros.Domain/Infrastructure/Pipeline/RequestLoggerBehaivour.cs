using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atros.Domain.Infrastructure.Pipeline
{
    public class RequestLoggerBehaivour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private static EventId _requestHandledEventId = new EventId(960202, "RequestLoggerBehaivour");
        private readonly ILogger<RequestLoggerBehaivour<TRequest, TResponse>> _logger;

        public RequestLoggerBehaivour(ILogger<RequestLoggerBehaivour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }


        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                var response = await next();

                var responseModel = request == null ? String.Empty : JsonConvert.SerializeObject(response);
                using (_logger.BeginScope("{ActionName}", typeof(TRequest).Name))
                using (_logger.BeginScope("{ResponseModel}", responseModel))
                {
                    _logger.LogInformation(_requestHandledEventId, "Handled request:{@request}.", typeof(TRequest).Name);
                }
                return response;
            }
            catch (Exception ex)
            {
                var requestModel = request == null ? String.Empty : JsonConvert.SerializeObject(request);
                using (_logger.BeginScope("{ActionName}", typeof(TRequest).Name))
                using (_logger.BeginScope("{RequestModel}", requestModel))
                {
                    _logger.LogError(_requestHandledEventId, ex, $"An error occurred while handling request:{typeof(TRequest).Name}.");
                }
                throw;
            }
        }
    }
}
