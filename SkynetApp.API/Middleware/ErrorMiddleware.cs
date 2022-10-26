using System.Net;
using System.Text.Json;

namespace SkynetApp.API.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorMiddleware> _logger;

        public ErrorMiddleware(RequestDelegate next, ILogger<ErrorMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            } 
            catch(Exception ex)
            {
                await HaddleException(context, ex, _logger);
            }
        }

        private async Task HaddleException(HttpContext context, Exception ex, ILogger<ErrorMiddleware> logger)
        {
            object errors = null;

            switch(ex)
            {
                case Exception e:
                    logger.LogError(ex, "SERVER ERROR");
                    errors = string.IsNullOrWhiteSpace(e.Message) ? "Error" : ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";
            if(errors != null)
            {
                var result = JsonSerializer.Serialize(new { errors });

                await context.Response.WriteAsync(result);
            }
        }
    }
}
