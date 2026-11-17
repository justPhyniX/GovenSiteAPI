using GovenSiteAPI.Models;
using Microsoft.Extensions.Options;

namespace GovenSiteAPI.Services;

public class SpotifyService(HttpClient httpClient, IOptions<SpotifyConfiguration> spotifyConfig)
{
    private readonly SpotifyConfiguration _spotifyConfig = spotifyConfig.Value;
    private readonly HttpClient _httpClient = httpClient;

    public async Task<object> GetArtistDiscography(string artistName)
    {
        try
        {
            var artistId = _spotifyConfig.ArtistUrl.TryGetValue(artistName, out var id) ? id : null;
            if(artistId == null)
            {
                return new ErrorDto
                {
                    StatusCode = 404,
                    ErrorMessage = $"Artist '{artistName}' not found in configuration. Available artists: {string.Join(", ", _spotifyConfig.ArtistUrl.Keys)}"
                };
            }

            var url = $"{_spotifyConfig.BaseUrl}/artists/{artistId}/albums?limit=10"; // !!! not final - should get albums regardless of limit
            var token = await GetSpotifyTokenAsync();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Authorization", $"Bearer {token}");

            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadFromJsonAsync<ArtistDiscographyDto>();

            if(content == null)
            {
                return new ErrorDto
                {
                    StatusCode = 500,
                    ErrorMessage = "Failed to deserialize Spotify response."
                };
            }

            if(content.Error != null)
            {
                return new ErrorDto
                {
                    StatusCode = (int)response.StatusCode,
                    ErrorMessage = content.Error.ErrorMessage
                };
            }

            return content;
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
