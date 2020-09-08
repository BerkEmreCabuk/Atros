using Atros.HostedService.Jobs;
using Atros.HostedService.Models;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.HostedService
{
    public static class Extensions
    {
        public static IServiceCollection AddCustomHostedService(this IServiceCollection services)
        {
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            services.AddSingleton<GetAllMovieJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(GetAllMovieJob),
                cronExpression: "0 0/1 * 1/1 * ? *")); // Every twelve hours
            services.AddHostedService<QuartzHostedService>();

            return services;
        }
    }
}
