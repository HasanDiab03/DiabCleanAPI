using DiabCleanAPI.DiabCleanAPI.Shared;
using DiabCleanAPI.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiabCleanAPI.Infrastructure
{
    public class ExceptionMiddleWare : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleWare> _logger;
        public ExceptionMiddleWare(ILogger<ExceptionMiddleWare> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            } catch (NotFoundException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                var json = JsonSerializer.Serialize(LogAndSerialize(context.Request, ex));

            }
        }
        private string LogAndSerialize(HttpRequest request, NotFoundException ex)
        {
            _logger.LogError(
                ex.GetType().Name + ": " + ex.Message +
                "\nHost: " + request.Host +
                " | Path: " + request.Path +
                " | Method: " + request.Method);

            return JsonSerializer.Serialize(Response.Error<string>(ex.Message));
        }
    }
}
