using Microsoft.AspNetCore.Mvc;
using GovenSiteAPI.Models;
using GovenSiteAPI.Services;

namespace GovenSiteAPI.Controllers;

[ApiController]
[Route("api")]
public class MainController : Controller
{
    private readonly WeatherService _weatherService;

    public MainController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet(nameof(GetWeather))]
    public async Task<IActionResult> GetWeather([FromQuery] string city)
    {
        var response = await _weatherService.GetWeatherAsync(city);
        
        if (response is ErrorDto error)
            return StatusCode(error.StatusCode, new { error.ErrorMessage });
        
        return Ok(response);
    }
}