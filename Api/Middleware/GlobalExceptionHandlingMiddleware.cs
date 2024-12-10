namespace Api.Middleware;

public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
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
        catch (BadHttpRequestException ex)
        {
            _logger.LogWarning(ex, "Bad Request");
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(new
            {
                Message = ex.Message,
                Code = "BAD_REQUEST"
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new
            {
                Message = "An unexpected error occurred",
                Code = "INTERNAL_SERVER_ERROR"
            });
        }
    }
}
