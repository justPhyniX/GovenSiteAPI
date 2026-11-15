using GovenSiteAPI.Mappers;
using GovenSiteAPI.Models;
using Microsoft.Extensions.Options;

namespace GovenSiteAPI.Services;

public class WeatherService(
    HttpClient httpClient,
    IOptions<WeatherConfiguration> weatherConfig)
{
    private readonly WeatherConfiguration _weatherConfig = weatherConfig.Value;
    private readonly HttpClient _httpClient = httpClient;

    public async Task<object?> GetWeatherAsync(string city)
    {
        try
        {
            var url = $"{_weatherConfig.BaseUrl}/current.json?q={city}&key={_weatherConfig.ApiKey}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadFromJsonAsync<WeatherDto>()
                ?? new WeatherDto() { Error = new WeatherErrorMessage { Message = "No data received from the weather service." } };

            if(!response.IsSuccessStatusCode)
            {
                return new ErrorDto
                {
                    StatusCode = (int)response.StatusCode,
                    ErrorMessage = content.Error.Message
                };
            }

            content.CurrentWeather.Condition.Text = WeatherMapper.MapWeatherCondition(content.CurrentWeather.Condition.Code);
    
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
}
