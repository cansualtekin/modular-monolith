using Microsoft.AspNetCore.Builder;

namespace Example.Platform.Extensions
{
    public static class ModuleServiceCollectionExtension
    {
        public static void AddModule<TModule>(this WebApplicationBuilder builder)
            where TModule : class, IModule
        {
            var module = Activator.CreateInstance<TModule>();

            module.ConfigureServices(builder.Services, builder.Configuration);
        }
    }
}
