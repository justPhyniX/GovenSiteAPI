using System.Text.Json.Serialization;

namespace GovenSiteAPI.Models;

public class ErrorDto
{
    [JsonPropertyName("status")]
    public int StatusCode { get; set; }
    [JsonPropertyName("message")]
    public string ErrorMessage { get; set; } = string.Empty;
}
