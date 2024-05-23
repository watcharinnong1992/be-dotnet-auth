using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace dotnet_auth.Controllers;

[ApiController]
[Route("api/weather-forecast")]
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


    [HttpGet]
    [Route("any")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet]
    [Route("admin-view")]
    [Authorize(Roles = "ADMIN.VIEW")]
    public IActionResult View()
    {
        return Ok("admin-view");
    }

    [HttpGet]
    [Route("admin-add")]
    [Authorize(Roles = "ADMIN.ADD")]
    public IActionResult Add()
    {
        return Ok("admin-add");
    }

    [HttpGet]
    [Route("admin-add-view")]
    [Authorize(Roles = "ADMIN.ADD")]
    public IActionResult AddView()
    {
        return Ok("admin-add-veiw");
    }
}

