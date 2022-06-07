using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Platform.Extensions
{
    public static class ModuleServiceCollectionExtension
    {
        public static IServiceCollection AddModule<TModule>(this IServiceCollection services)
            where TModule : class, IModule
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.SetupInformation.ApplicationBase)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var module = Activator.CreateInstance<TModule>();

            module.ConfigureServices(services, configuration);

            return services;
        }
    }
}
