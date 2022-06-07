using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Platform
{
    public interface IModule
    {
        IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration);  
    }
}
