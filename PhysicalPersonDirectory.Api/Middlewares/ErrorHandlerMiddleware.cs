
using System.Net;

namespace PhysicalPersonDirectory.Api.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly ILogger<ErrorHandlerMiddleware> _logger;
    private readonly RequestDelegate _next;
    public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger, RequestDelegate next)
    {
        _next=next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var httpCode = (short)HttpStatusCode.BadRequest;
        var code = "error";
        var message = "Something bad is happening";
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception,exception.Message);//or just send request another module where is db logger works with fire and forget or something other
            context.Response.StatusCode = httpCode;
            await context.Response.WriteAsJsonAsync(new {code, message});
        }
    }
}