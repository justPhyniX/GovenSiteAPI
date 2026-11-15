using System.Text.Json.Serialization;

namespace GovenSiteAPI.Models;
public class ArtistDiscographyDto
{
    [JsonPropertyName("total")]
    public int TotalAlbums { get; set; }
    public List<Album> Albums { get; set; } = [];

}

public class Album
{
    [JsonPropertyName("album_type")]
    public string Type { get; set; } = string.Empty;
    [JsonPropertyName("total_tracks")]
    public int TotalTracks { get; set; }
    [JsonPropertyName("external_urls")]
    public ExternalUrls AlbumUrl { get; set; } = new();
    public List<Image> Images { get; set; } = [];
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; } = string.Empty;
    [JsonPropertyName("release_date_precision")]
    public string ReleaseDatePrecision { get; set; } = string.Empty;
    public List<Artist> Artists { get; set; } = [];
}

public class ExternalUrls
{
    public string Spotify { get; set; } = string.Empty;
}

public class Image
{
    public string Url { get; set; } = string.Empty;
    public int Height { get; set; }
    public int Width { get; set; }
}

public class Artist
{
    [JsonPropertyName("external_urls")]
    public ExternalUrls ExternalUrls { get; set; } = new();
    public string Name { get; set; } = string.Empty;
}