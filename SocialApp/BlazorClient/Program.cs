using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var rootComponents = builder.RootComponents;
var services = builder.Services;

rootComponents.Add<App>("#app");
rootComponents.Add<HeadOutlet>("head::after");

services.AddScoped(provider => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Local", options.ProviderOptions);
});

// these seemed not to work when set from docker-compose
// var userTimeline = Environment.GetEnvironmentVariable("USER_TIMELINE_SERVICE");
// var userProfile = Environment.GetEnvironmentVariable("USER_PROFILE_SERVICE");

var userTimeline = "http://pisproject.eastus.azurecontainer.io:5001";
var userProfile = "http://pisproject.eastus.azurecontainer.io:5002";

// custom
services.AddHttpClient("UserTimelineService", client =>
{
    client.BaseAddress = new Uri(userTimeline);
});
services.AddHttpClient("UserProfileService", client =>
{
    client.BaseAddress = new Uri(userProfile);
});

await builder.Build().RunAsync();