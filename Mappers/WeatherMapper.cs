namespace GovenSiteAPI.Mappers;

public class WeatherMapper
{
    public static readonly Dictionary<int, string> WeatherConditions = new Dictionary<int, string>
    {
        // Sunny / Clear
        { 1000, "sunny/clear" },

        // Partly cloudy
        { 1003, "partly cloudy" },

        // Cloudy
        { 1006, "cloudy" },       // Cloudy
        { 1009, "cloudy" },       // Overcast

        // Mist / Fog (Includes haze, dust, smoke, and smog)
        { 1012, "mist/fog" },     // Haze
        { 1015, "mist/fog" },     // Dust haze
        { 1018, "mist/fog" },     // Blowing dust
        { 1021, "mist/fog" },     // Dust storm
        { 1024, "mist/fog" },     // Sandstorm
        { 1027, "mist/fog" },     // Severe sandstorm
        { 1030, "mist/fog" },     // Mist
        { 1033, "mist/fog" },     // Smoke
        { 1036, "mist/fog" },     // Smoky haze
        { 1039, "mist/fog" },     // Smog
        { 1042, "mist/fog" },     // Severe smog
        { 1045, "mist/fog" },     // Saharan dust
        { 1048, "mist/fog" },     // Dust
        { 1135, "mist/fog" },     // Fog
        { 1147, "mist/fog" },     // Freezing fog

        // Rain (Includes drizzle, freezing rain, and showers)
        { 1063, "rain" },         // Patchy rain possible
        { 1072, "rain" },         // Patchy freezing drizzle possible
        { 1150, "rain" },         // Patchy light drizzle
        { 1153, "rain" },         // Light drizzle
        { 1168, "rain" },         // Freezing drizzle
        { 1171, "rain" },         // Heavy freezing drizzle
        { 1180, "rain" },         // Patchy light rain
        { 1183, "rain" },         // Light rain
        { 1186, "rain" },         // Moderate rain at times
        { 1189, "rain" },         // Moderate rain
        { 1192, "rain" },         // Heavy rain at times
        { 1195, "rain" },         // Heavy rain
        { 1198, "rain" },         // Light freezing rain
        { 1201, "rain" },         // Moderate or heavy freezing rain
        { 1240, "rain" },         // Light rain shower
        { 1243, "rain" },         // Moderate or heavy rain shower
        { 1246, "rain" },         // Torrential rain shower

        // Snow (Includes sleet, blizzard, and ice pellets)
        { 1066, "snow" },         // Patchy snow possible
        { 1069, "snow" },         // Patchy sleet possible
        { 1114, "snow" },         // Blowing snow
        { 1117, "snow" },         // Blizzard
        { 1204, "snow" },         // Light sleet
        { 1207, "snow" },         // Moderate or heavy sleet
        { 1210, "snow" },         // Patchy light snow
        { 1213, "snow" },         // Light snow
        { 1216, "snow" },         // Patchy moderate snow
        { 1219, "snow" },         // Moderate snow
        { 1222, "snow" },         // Patchy heavy snow
        { 1225, "snow" },         // Heavy snow
        { 1237, "snow" },         // Ice pellets
        { 1249, "snow" },         // Light sleet showers
        { 1252, "snow" },         // Moderate or heavy sleet showers
        { 1255, "snow" },         // Light snow showers
        { 1258, "snow" },         // Moderate or heavy snow showers
        { 1261, "snow" },         // Light showers of ice pellets
        { 1264, "snow" },         // Moderate or heavy showers of ice pellets

        // Thunderstorm
        { 1087, "thunderstorm" }, // Thundery outbreaks possible
        { 1273, "thunderstorm" }, // Patchy light rain with thunder
        { 1276, "thunderstorm" }, // Moderate or heavy rain with thunder
        { 1279, "thunderstorm" }, // Patchy light snow with thunder
        { 1282, "thunderstorm" }  // Moderate or heavy snow with thunder
    };

    public static string MapWeatherCondition(int code)
    {
        return WeatherConditions.TryGetValue(code, out var condition) ? condition : "unknown";
    }
}