
using System.Diagnostics;

namespace Restaurants.Clean.API;

public class TimeLoggerMiddleware(ILogger<TimeLoggerMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var stopWatch = Stopwatch.StartNew();
        await next(context);
        stopWatch.Stop();

        if (stopWatch.Elapsed.TotalSeconds > 4)
        {
            logger.LogInformation("Resquest [{Verb}] at {Path}  took {Time} seconds",
            context.Request.Method ,
            context.Request.Path ,
            stopWatch.Elapsed.TotalSeconds);
        }
    }
}
