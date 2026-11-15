using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GovenSiteAPI.Models;

namespace GovenSiteAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    [HttpGet]
    public IActionResult GetWeather()
    {
        return Ok("Test done");
    }
}