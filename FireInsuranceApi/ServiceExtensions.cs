﻿using Domain.Interfaces;
using FireInsuranceApi;
using persistence;
using Persistence.Implementetaion;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;


namespace BimehApi.API
{
    public static class ServiceExtensions
    {

        public static void ConfigureLogging(this IServiceCollection service, IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .WriteTo.Debug()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, hostEnvironment.EnvironmentName))
                .Enrich.WithProperty("Environment", hostEnvironment.EnvironmentName)
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            service.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
        }

        private static ElasticsearchSinkOptions ConfigureElasticSink(IConfiguration configuration, string environmentName)
        {
            return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
            {
                AutoRegisterTemplate = true,
                IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name?.ToLower().Replace(".", "-")}-{environmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
            };
        }

        public static IServiceCollection AddFireServices(this IServiceCollection services,
             IConfiguration configuration)
        {
            services.Configure<FireInsuranceOptions>(configuration.GetSection(FireInsuranceOptions.SectionName));
            services.AddScoped<IFireInsuranceService, FireInsuranceService>();
            services.AddScoped<IFireInsuranceRepository, FireInsuranceRepository>();
            services.AddScoped<BaseLog>();
            return services;
        }

        //public static void StartBackgroundTasks(IServiceCollection services, IConfiguration configuration)
        //{
        //    var JobOptions = configuration.GetSection(TokenBackgroundJobOption.SectionName).Get<TokenBackgroundJobOption>();
        //    RecurringJob.AddOrUpdate<ISportInsuranceRepository>(x => x.GetSportToken(), JobOptions.CronExpression);
        //}
    }
}