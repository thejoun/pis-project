namespace BlazorClient.Config;

/// <summary>
/// Afaik, Blazor WebAssembly can't handle environment variables.
/// </summary>
public class Services
{
    public string UserTimeline { get; set; } = string.Empty;
    public string UserProfile { get; set; } = string.Empty;
}