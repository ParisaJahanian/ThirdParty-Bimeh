using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;


namespace Bimeh.Infratructure.Extension
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
        //public static void StartBackgroundTasks(IServiceCollection services, IConfiguration configuration)
        //{
        //    var JobOptions = configuration.GetSection(BackgroundJobOption.SectionName).Get<BackgroundJobOption>();
        //    var login = new LoginReqDTO
        //    {
        //        UserName = JobOptions.UserName,
        //        Password = JobOptions.Password,
        //        PublicLogData = new PublicLogData
        //        {
        //            PublicAppId = Guid.NewGuid().ToString(),
        //            PublicReqId = Guid.NewGuid().ToString(),
        //            ServiceId = Guid.NewGuid().ToString(),
        //            UserId = Guid.NewGuid().ToString()
        //        }
        //    };
        //    RecurringJob.AddOrUpdate<ICarElectronicTollService>(x => x.LoginAsync(login), JobOptions.CronExpression);
        //}
    }
}
