using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace SurveyApp.API.Middlewares
{
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var statusCode = exception switch
                {
                    ValidationException 
                    or ArgumentException
                    => (int)HttpStatusCode.BadRequest,                    
                    _ => (int)HttpStatusCode.InternalServerError,
                };
                context.Response.StatusCode = statusCode;
                context.Response.ContentType = "application/json";

                if(statusCode == (int)HttpStatusCode.InternalServerError)
                {
                  await  context.Response.WriteAsync(JsonSerializer.Serialize(new { error = "Server Error" }));
                }
                else
                {
                   await context.Response.WriteAsync(JsonSerializer.Serialize(new { error = exception.Message }));
                }
            }
        }
    }
}
