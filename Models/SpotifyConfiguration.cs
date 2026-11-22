namespace GovenSiteAPI.Models;

public class SpotifyConfiguration
{
    public string BaseUrl { get; set; } = string.Empty;
    public string AuthUrl { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public Dictionary<string, string> ArtistUrl { get; set; } = [];
}
