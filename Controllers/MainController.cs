using Microsoft.AspNetCore.Mvc;
using GovenSiteAPI.Models;
using GovenSiteAPI.Services;

namespace GovenSiteAPI.Controllers;

[ApiController]
[Route("api")]
public class MainController(WeatherService weatherService, SpotifyService spotifyService) : Controller
{
    private readonly WeatherService _weatherService = weatherService;
    private readonly SpotifyService _spotifyService = spotifyService;

    [HttpGet(nameof(GetWeather))]
    public async Task<IActionResult> GetWeather([FromQuery] string city)
    {
        var response = await _weatherService.GetWeatherAsync(city);
        
        if (response is ErrorDto error)
            return StatusCode(error.StatusCode, new { error.ErrorMessage });
        
        return Ok(response);
    }

    [HttpGet(nameof(GetDiscography))]
    public async Task<IActionResult> GetDiscography([FromQuery] string artist)
    {
        // Placeholder for discography logic
        var response = await _spotifyService.GetArtistDiscography(artist);
        if (response is ErrorDto error)
            return StatusCode(error.StatusCode, new { error.ErrorMessage });

        return Ok(response);
    }
}