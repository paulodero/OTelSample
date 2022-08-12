namespace WebApiSample.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var weather = new List<WeatherForecast>();
        foreach (var days in Enumerable.Range(1, 5))
        {
            weather.Add(GetWeather(days));
        }

       return weather;
    }
    private WeatherForecast GetWeather(int days)
    {
        var forecast = new WeatherForecast
        {
            Date = DateTime.Now.AddDays(days),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };

        return forecast;
    }
}
