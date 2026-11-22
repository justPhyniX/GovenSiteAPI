using GovenSiteAPI.Models;
using GovenSiteAPI.Persistence;
using GovenSiteAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMemoryCache();

builder.Services.AddHttpClient<WeatherService>();
builder.Services.AddHttpClient<SpotifyService>();

builder.Services.AddSingleton<DataCache>();
builder.Services.AddHostedService<RefreshService>();

builder.Services.Configure<WeatherConfiguration>(
    builder.Configuration.GetSection("WeatherConfiguration"));
builder.Services.Configure<SpotifyConfiguration>(
    builder.Configuration.GetSection("SpotifyConfiguration"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();