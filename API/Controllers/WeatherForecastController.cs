using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];
    private readonly ILogger<WeatherForecastController> _logger;
    private static List<WeatherForecast> ListWeatherForecast = new();
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        Console.WriteLine(ListWeatherForecast.Count);
        if (ListWeatherForecast.Count == 0)
        {

            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    // [Route("weatherList")] // url name
    // [Route("[action]")] // method name
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("Retornando lista de datos");
        return ListWeatherForecast;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);
        return Ok();
    }

    [HttpDelete("{idx}")] // /api/weatherforecast/1 -> idx = 1
    public IActionResult Delete(int idx)
    {
        ListWeatherForecast.RemoveAt(idx);
        return Ok();
    }
}