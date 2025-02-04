public class TimeMiddleware
{
    readonly RequestDelegate next;

    public TimeMiddleware(RequestDelegate nextRequest)
    {
        next = nextRequest;
    }

    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
    {
        if (context.Request.Query.Any(c => c.Key == "time"))
        {
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }
        
        await next(context);
    }
}

public static class TimeMiddlewareExtension
{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TimeMiddleware>();
    }
}