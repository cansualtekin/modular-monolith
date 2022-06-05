using Microsoft.AspNetCore.Http;
using Serilog;

namespace Example.Platform.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger = Log.ForContext<ExceptionHandlerMiddleware>();

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Items.Add("exception", ex);
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                _logger.Error(ex, ex.Message);
            }
        }
    }

}
