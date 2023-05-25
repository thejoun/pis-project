namespace BlazorClient.Config;

/// <summary>
/// Afaik, Blazor WebAssembly can't handle environment variables.
/// This is only a temporary solution.
/// </summary>
public static class Services
{
    public static string UserTimeline => "http://pisproject.eastus.azurecontainer.io:5001";
    public static string UserProfile => "http://pisproject.eastus.azurecontainer.io:5002";
}