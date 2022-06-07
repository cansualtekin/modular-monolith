using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using Serilog;
using Example.Platform.Middlewares;
using Example.Platform.Extensions;

namespace Example.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Modules 
            builder.Services.AddModule<User.Application.Module>();

            // Versioning
            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
            });

            builder.Services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            // Swagger
            builder.Services.AddSwaggerGen(options =>
            {
                options.ExampleFilters();
            });

            builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());

            // SeriLog
            builder.Host.UseSerilog((context, config) => {
                config.ReadFrom.Configuration(context.Configuration)
                .Enrich.FromLogContext();
            });

            var app = builder.Build();

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

            // Middlewares
            app.UseMiddleware<ApiResponseMiddleware>();
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}