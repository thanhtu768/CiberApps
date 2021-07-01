using Ciber.Services.System.Logger;
using Ciber.ViewModels.System.Errors;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ciber.Services.System.CustomExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;
        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Middleware: Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "InternalServer: Error from the custom middleware"
            }.ToString());
        }
    }
}
