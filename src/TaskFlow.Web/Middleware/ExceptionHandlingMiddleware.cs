using System.Text.Json;
using TaskFlow.Application.Common;

namespace TaskFlow.Web.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var statusCode = ex is AppException appException ? appException.StatusCode : StatusCodes.Status500InternalServerError;
            _logger.LogError(ex, "Unhandled API exception. StatusCode={StatusCode}", statusCode);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            var payload = new
            {
                error = ex.Message,
                status = statusCode,
                path = context.Request.Path.Value,
                traceId = context.TraceIdentifier
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(payload));
        }
    }
}
