using GovenSiteAPI.Models;
using Microsoft.Extensions.Options;

namespace GovenSiteAPI.Services;

public class SpotifyService(HttpClient httpClient, IOptions<SpotifyConfiguration> weatherConfig)
{
    private readonly SpotifyConfiguration _spotifyConfig = weatherConfig.Value;
    private readonly HttpClient _httpClient = httpClient;

    public async Task<object> GetArtistDiscography(string artistName)
    {
        try
        {
            // var token = await GetSpotifyTokenAsync();
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            return new ErrorDto
            {
                StatusCode = 500,
                ErrorMessage = $"An unexpected error occurred: {ex.Message}"
            };
        }
    }

    private async Task<string> GetSpotifyTokenAsync()
    {
        try
        {
            var url = $"{_spotifyConfig.AuthUrl}/token";
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var creds = new List<KeyValuePair<string, string>>()
            {
                new("grant_type", "client_credentials"),
                new("client_id", _spotifyConfig.ClientId),
                new("client_secret", _spotifyConfig.ClientSecret)
            };
            var content = new FormUrlEncodedContent(creds);
            request.Content = content;

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get Spotify token. Status code: {response.StatusCode}");
            }

            var token = await response.Content.ReadFromJsonAsync<SpotifyTokenDto>();
            return token?.AccessToken ?? throw new Exception("Failed to retrieve access token from Spotify response.");
        }
        catch (Exception ex)
        {
            throw new Exception($"Unexpected error during Spotify authorization {ex.Message}");
        }
    }
}
