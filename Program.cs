using GovenSiteAPI.Models;
using GovenSiteAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddHttpClient<WeatherService>();

builder.Services.Configure<WeatherConfiguration>(
    builder.Configuration.GetSection("WeatherConfiguration"));

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