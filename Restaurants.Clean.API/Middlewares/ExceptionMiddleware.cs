
namespace Restaurants.Clean.API;

public class ExceptionMiddleware(ILogger<ExceptionMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
       try
       {
            await next.Invoke(context);
       }
       catch (Exception ex)
       {
            logger.LogError(ex,ex.Message);
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync("Something Went Wrong");
       }
    }
}
 