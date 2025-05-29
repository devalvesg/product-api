using System.Text.Json;
using Application.Exceptions;

namespace Api.Middlewares
{
    public class ExceptionHandlingMiddleware(RequestDelegate _next,
        ILogger<ExceptionHandlingMiddleware> _logger)
    {
        public async Task InvokeAsync(HttpContext ctx)
        {
            try
            {
                await _next(ctx);
            }
            catch (CustomException customException)
            {
                _logger.LogError(customException, "Custom exception");  
                ctx.Response.StatusCode = StatusCodes.Status400BadRequest;
                ctx.Response.ContentType = "application/json";
                var payload = new
                {
                    result = (object)null,
                    code = ctx.Response.StatusCode,
                    error = customException.Errors
                };
                await ctx.Response.WriteAsync(JsonSerializer.Serialize(payload));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                ctx.Response.StatusCode = StatusCodes.Status500InternalServerError;
                ctx.Response.ContentType = "application/json";
                var payload = new
                {
                    result = (object)null,
                    code = ctx.Response.StatusCode,
                    error = new[] { "An unexpected error occurred." }
                };
                await ctx.Response.WriteAsync(JsonSerializer.Serialize(payload));
            }
        }
    }
}
