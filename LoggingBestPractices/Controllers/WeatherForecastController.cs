using Benchmark;
using Microsoft.AspNetCore.Mvc;

namespace LoggingBestPractices.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private const string LoggerContext = "WeatherForecastController";
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly string[] _summaries = { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("health")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult HealthCheck()
    {
        _logger.LogInformation("{Context} HealthCheck route.", LoggerContext);
        return Ok("The API is healthy");
    }
    
    /// <summary>
    /// Get weather forecast.
    /// </summary>
    /// <returns>Weather forecast</returns>
    /// <response code="200">Weather forecast returned successfully</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult GetWeather()
    {
        _logger.LogInformation("{Context} GetWeather route.", LoggerContext);
        WeatherForecast[] forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateTime.Now.AddDays(index),
                    Random.Shared.Next(-20, 55),
                    _summaries[Random.Shared.Next(_summaries.Length)]
                ))
            .ToArray();
        return Ok(forecast);
    }
    private record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}