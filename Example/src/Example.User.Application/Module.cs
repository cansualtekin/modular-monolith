using Example.Platform;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.User.Application
{
    public class Module : IModule
    {
        public IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
