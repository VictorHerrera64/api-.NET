using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static List<WeatherForecast> ListWeather = new List<WeatherForecast>();


    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        if (ListWeather == null || !ListWeather.Any())
        {
            ListWeather = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
        .ToList();
        }
    }

    [HttpGet]
    //[Route("GetWeatherForecast")]
    //[Route("[action]")]
    public IEnumerable<WeatherForecast> Get()
    {
        return ListWeather;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeather.Add(weatherForecast);
        return Ok();
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        ListWeather.RemoveAt(index);
        return Ok();
    }
}
