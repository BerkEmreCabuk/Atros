using Atros.Data;
using Atros.Data.Repository;
using Atros.Domain.Infrastructure.Mapper;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Domain
{
    public static class Extensions
    {
        public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services)
        {
            services
            .AddDbContext<AtrosDbContext>(opt => opt.UseSqlite("Data Source = atros.db"), ServiceLifetime.Singleton, ServiceLifetime.Singleton);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>)).AddScoped(typeof(Lazy<>), typeof(Lazier<>));
            return services;
        }
        internal class Lazier<T> : Lazy<T> where T : class
        {
            public Lazier(IServiceProvider provider) : base(() => provider.GetRequiredService<T>()) { }
        }
    }
}
