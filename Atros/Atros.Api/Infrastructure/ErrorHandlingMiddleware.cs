using Atros.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Atros.Api.Infrastructure
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(
            RequestDelegate next
        )
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                if (ex is BaseException baseException)
                {
                    context.Response.StatusCode = baseException.StatusCode;
                    await context.Response.WriteAsync(JsonSerializer.Serialize(baseException.Message));
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync(JsonSerializer.Serialize("Beklenilmeyen bir hata oluştu"));
                }
            }
        }
    }
}
