
using Restaurants.Clean.Application;

namespace Restaurants.Clean.API;

public class ExceptionMiddleware(ILogger<ExceptionMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
       try
       {
            await next.Invoke(context);
       }
       catch (NotFoundException notFoundException)
       {
            logger.LogError(notFoundException,notFoundException.Message);
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsync(notFoundException.Message);
            
        
       }
       catch(ForbidException forbidException)
       {
           logger.LogError(forbidException,forbidException.Message);
           context.Response.StatusCode = StatusCodes.Status403Forbidden;
           await context.Response.WriteAsync(forbidException.Message);
       }
       catch (Exception ex)
       {
            logger.LogError(ex,ex.Message);
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync("Something Went Wrong : " + ex.Message);
       }
    }
}
 