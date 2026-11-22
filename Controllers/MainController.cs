using Microsoft.AspNetCore.Mvc;
using GovenSiteAPI.Models;
using GovenSiteAPI.Persistence;

namespace GovenSiteAPI.Controllers;

[ApiController]
[Route("api")]
public class MainController(DataCache dataCache) : Controller
{
    private readonly DataCache _cache = dataCache;

    [HttpGet(nameof(GetWeather))]
    public IActionResult GetWeather()
    {
        var response = _cache.Get<object>("weather");
        
        if (response is ErrorDto error)
            return StatusCode(error.StatusCode, new { error.ErrorMessage });
        
        return Ok(response);
    }

    [HttpGet(nameof(GetDiscography))]
    public IActionResult GetDiscography([FromQuery] string artist)
    {
        var response = _cache.Get<object>($"discography{artist}");

        if (response is ErrorDto error)
            return StatusCode(error.StatusCode, new { error.ErrorMessage });

        return Ok(response);
    }
}