using System.Text.Json.Serialization;

namespace GovenSiteAPI.Models;

public class SpotifyTokenDto
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = string.Empty;
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
}
