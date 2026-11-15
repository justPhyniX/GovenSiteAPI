namespace GovenSiteAPI.Models;

public class ErrorDto
{
    public int StatusCode { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
}
