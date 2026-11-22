using Microsoft.Extensions.Caching.Memory;

namespace GovenSiteAPI.Services;

public class RefreshService(
    WeatherService weatherService,
    SpotifyService spotifyService,
    IMemoryCache cache) : BackgroundService
{
    private readonly WeatherService _weatherService = weatherService;
    private readonly SpotifyService _spotifyService = spotifyService;
    private readonly IMemoryCache _cache = cache;

    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        await Task.WhenAll(
            RunLoop("weather", TimeSpan.FromHours(1), RefreshWeather, ct),
            RunLoop("news", TimeSpan.FromDays(1), RefreshDiscography, ct));
    }

    private static async Task RunLoop(string name, TimeSpan interval,
        Func<CancellationToken, Task> refresh,
        CancellationToken ct)
    {
        using var timer = new PeriodicTimer(interval);
        do
        {
            try
            {
                await refresh(ct);
            }
            catch (Exception ex)
            {
                // log exception
            }
        }
        while(await timer.WaitForNextTickAsync(ct));
    }

    private async Task RefreshWeather(CancellationToken ct)
    {
        var weather = await _weatherService.GetWeatherAsync("Athens");
        
        if(weather != null)
            _cache.Set("weather", weather);
    }

    private async Task RefreshDiscography(CancellationToken ct)
    {
        var discographyBlemis = await _spotifyService.GetArtistDiscography("Blemis");
        var discographyPhyniX = await _spotifyService.GetArtistDiscography("PhyniX");

        if(discographyBlemis != null && discographyPhyniX != null)
        {
            _cache.Set("discographyBlemis", discographyBlemis);
            _cache.Set("discographyPhyniX", discographyPhyniX);
        }
    }
}
