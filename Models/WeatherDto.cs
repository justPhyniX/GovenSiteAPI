using System.Text.Json.Serialization;

namespace GovenSiteAPI.Models;

public class WeatherDto
{
    public LocationInfo Location { get; set; } = new LocationInfo();
    [JsonPropertyName("current")]
    public CurrentWeatherInfo CurrentWeather { get; set; } = new CurrentWeatherInfo();
    public WeatherErrorMessage Error { get; set; } = new WeatherErrorMessage() { Message = "No error" };
}

public class LocationInfo
{
    public string Name { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}

public class CurrentWeatherInfo
{
    [JsonPropertyName("temp_c")]
    public decimal Temperature { get; set; }
    [JsonPropertyName("is_day")]
    public int IsDay { get; set; }
    public ConditionInfo Condition { get; set; } = new ConditionInfo();
}

public class ConditionInfo
{
    public string Text { get; set; } = string.Empty;
    public int Code { get; set; }
}

public class WeatherErrorMessage
{
    public string Message { get; set; } = string.Empty;
}
