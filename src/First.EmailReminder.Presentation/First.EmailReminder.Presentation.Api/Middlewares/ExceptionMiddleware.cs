using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Exceptions;

namespace First.EmailReminder.Presentation.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
            catch (FirstValidationException ex)
            {
                _logger.LogWarning("Validation failed : {Errors}", string.Join(", ", ex.Errors));
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                var response = new
                {
                    Message = ex.Message,
                    Errors = ex.Errors,
                };

                await httpContext.Response.WriteAsJsonAsync(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occured");
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var response = new { Message = "An unexpected error occured", Error = ex.Message };
                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }
    }
}