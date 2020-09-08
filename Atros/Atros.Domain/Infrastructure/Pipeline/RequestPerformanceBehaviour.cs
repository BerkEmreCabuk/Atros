using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atros.Domain.Infrastructure.Pipeline
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private static EventId _requestPerformaceCounterEventId = new EventId(960200, "RequestPerformanceBehaviour");
        private readonly Stopwatch _timer;
        private readonly ILogger<RequestPerformanceBehaviour<TRequest, TResponse>> _logger;

        public RequestPerformanceBehaviour(ILogger<RequestPerformanceBehaviour<TRequest, TResponse>> logger)
        {
            _timer = new Stopwatch();
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();
            var response = await next();
            _timer.Stop();

            // Performans takibi için 1000ms uzun süren işlemleri logla.
            if (_timer.ElapsedMilliseconds > 1000)
            {
                var requestModel = request == null ? String.Empty : JsonConvert.SerializeObject(request, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

                using (_logger.BeginScope("{ActionName}", typeof(TRequest).Name))
                using (_logger.BeginScope("{ResponseModel}", requestModel))
                {
                    _logger.LogWarning(_requestPerformaceCounterEventId, "Long Running Request:{@name} {@milliseconds} milliseconds.", typeof(TRequest).Name, _timer.ElapsedMilliseconds);
                }
            }

            return response;
        }
    }
}
