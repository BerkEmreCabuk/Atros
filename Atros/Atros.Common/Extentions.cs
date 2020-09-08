using Atros.Common.Services;
using Atros.Common.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Atros.Common
{
    public static class Extentions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddHttpClient<IMainHttpService, MainHttpService>(client =>
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
            services.AddScoped<IMailService, MailService>()
                .AddScoped(x => new Lazy<IMailService>(() => x.GetRequiredService<IMailService>()));

            return services;
        }
    }
}
