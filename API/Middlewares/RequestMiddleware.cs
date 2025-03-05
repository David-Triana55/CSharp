using JsonSerializer = System.Text.Json.JsonSerializer;
using Encoding = System.Text.Encoding;
namespace API.Middlewares;

public class RequestMiddleware
{

  readonly RequestDelegate next;

  public RequestMiddleware(RequestDelegate nextRequest)
  {
    next = nextRequest;
  }

  public async Task Invoke(HttpContext context)
  {
    context.Request.EnableBuffering(); // Permite leer el cuerpo más de una vez

    using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true)) // permite leer datos de un flujo de entrada
    {
      var body = await reader.ReadToEndAsync();
      context.Request.Body.Position = 0; // Restablecer la posición para que pueda ser leída nuevamente

      Console.WriteLine($"Método: {context.Request.Method}");
      Console.WriteLine($"URL: {context.Request.Path}");
      Console.WriteLine($"Cabeceras: {JsonSerializer.Serialize(context.Request.Headers)}");
      Console.WriteLine($"Cuerpo: {body}");
      Console.WriteLine($"Query: " + JsonSerializer.Serialize(context.Request.Query));
    }
    await next(context);
  }
}

public static class RequestMiddlewareExtensions
{
  public static IApplicationBuilder UseRequestMiddleware(this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<RequestMiddleware>();
  }
}