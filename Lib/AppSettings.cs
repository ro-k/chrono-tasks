namespace Lib;

public class AppSettings
{
    public string? ConnectionString { get; set; }
    public string? JwtKey { get; set; }
    public string? JwtIssuer { get; set; }
    public string? JwtAudience { get; set; }
}