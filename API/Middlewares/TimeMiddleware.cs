public class TimeMiddleware
{
  readonly RequestDelegate next; // funcion que se ejecutara despues de ejecutar el middleware

  public TimeMiddleware(RequestDelegate nextRequest) // constructor del middleware que recibe la funcion que se ejecutara despues de ejecutar el middleware
  {
    next = nextRequest;
  }

  public async Task Invoke(HttpContext context) // contexto contiene informacion del request y response
  {
    await next(context);
    if (context.Request.Query.Any(x => x.Key == "time"))
    {
      await context.Response.WriteAsync(DateTime.Now.ToShortDateString());
    }
  }
}

public static class TimeMiddlewareExtensions
{
  public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<TimeMiddleware>();
  }
}