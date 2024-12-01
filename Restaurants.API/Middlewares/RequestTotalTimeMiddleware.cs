
namespace Restaurants.API.Middlewares;

public class RequestTimeLoggingMiddleware : IMiddleware
{
    private readonly ILogger<RequestTimeLoggingMiddleware> _logger;
    public RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger)
    {
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context , RequestDelegate next)
    {
        DateTime start = DateTime.Now;

        await next.Invoke(context);

        DateTime end = DateTime.Now;

        double requestTimeInSeconds = (end - start).TotalSeconds;

        if(requestTimeInSeconds > 4)
        {
            string message = $"Request {context.Request.Method} at {context.Request.Path} took {requestTimeInSeconds} second";
            _logger.LogInformation(message);
        }
    }
}
