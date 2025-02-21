// Presentation/Middleware/LoggingMiddleware.cs
public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Log request details
        Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

        await _next(context);

        // Log response details
        Console.WriteLine($"Response: {context.Response.StatusCode}");
    }
}

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LoggingMiddleware>();
    }
}