﻿using Example.Platform.WebApi;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Serilog;
using System.Net;

namespace Example.Platform.Middlewares
{
    public class ApiResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger = Log.ForContext<ExceptionHandlerMiddleware>();

        public ApiResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var responseBody = context.Response.Body;

            using (var memoryStream = new MemoryStream())
            {
                context.Response.Body = memoryStream;

                await _next(context);

                context.Response.Body = responseBody;
                memoryStream.Seek(0, SeekOrigin.Begin);

                var jsonBody = new StreamReader(memoryStream).ReadToEnd();

                object? objResult = null;

                if (!string.IsNullOrWhiteSpace(jsonBody) && IsValid(jsonBody))
                {
                    objResult = JsonConvert.DeserializeObject(jsonBody);
                }
                else
                {
                    objResult = jsonBody;

                    _logger.Warning($"Invalid JSON response from {context.Request.Path}");
                }

                string? errorMessage = null;

                if (context.Items.ContainsKey("exception"))
                {
                    errorMessage = (context.Items["exception"] as Exception)?.Message;
                }

                var apiResponse = ApiResponse.Create((HttpStatusCode)context.Response.StatusCode, objResult, errorMessage);

                var response = JsonConvert.SerializeObject(apiResponse, new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                await context.Response.WriteAsync(response);
            }
        }

        private bool IsValid(string body)
        {
            try
            {
                JToken.Parse(body);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
