using Microsoft.AspNetCore.Mvc;

namespace Example.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Versioning
            builder.Services.AddApiVersioning(options => {
                options.DefaultApiVersion = new ApiVersion(1,0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
            });

            builder.Services.AddVersionedApiExplorer(options => {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}