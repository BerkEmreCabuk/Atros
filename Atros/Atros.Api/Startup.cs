using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Atros.Api.Infrastructure;
using Atros.Common;
using Atros.Common.Models;
using Atros.Domain;
using Atros.Domain.Infrastructure.Pipeline;
using Atros.Domain.MovieEvaluations.Validators;
using Atros.Domain.Movies.Queries;
using Atros.HostedService;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Atros.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(validationConfig => validationConfig.RegisterValidatorsFromAssemblyContaining<PostMovieEvaluationValidator>());
            services.AddMemoryCache();
            services.AddCustomSettings(Configuration);
            services.AddCustomAuthentication(Configuration);
            services.AddCustomAutoMapper();
            services.AddCustomDbContext();
            services.AddCustomServices();
            services.AddMediatR();
            services.AddCustomHostedService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAll");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseErrorHandlingMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public static class StartUpExtensions
    {
        public static IServiceCollection AddCustomSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TheMovieSettingsModel>(configuration.GetSection("TheMovieSettings"));
            services.Configure<JWTSettingsModel>(configuration.GetSection("JWTSettings"));
            services.Configure<EmailSettingsModel>(configuration.GetSection("EmailSettings"));
            return services;
        }

        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddMediatR(typeof(GetPagedMovieModelQueryHandler).GetTypeInfo().Assembly);
            return services;
        }

        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JWTSettingsModel();
            configuration.GetSection("JWTSettings").Bind(jwtSettings);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecretKey)),
                        ValidateIssuer = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwtSettings.Audience,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        RequireExpirationTime = true,
                    };
                });

            return services;
        }

        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
