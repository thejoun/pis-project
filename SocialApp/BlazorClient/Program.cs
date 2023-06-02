using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorClient;
using BlazorClient.Config;
using BlazorClient.Constants;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var rootComponents = builder.RootComponents;
var services = builder.Services;
var config = builder.Configuration;

var baseAddress = builder.HostEnvironment.BaseAddress;

// can't read the ASPNET_ENVIRONMENT in a standard way here
// THIS IS A WORKAROUND
Console.WriteLine($"Is development according to aspnet? '{builder.HostEnvironment.IsDevelopment()}'");
var isMyDevelopment = baseAddress.Contains("localhost") || baseAddress.Contains("127.0.0.1");
Console.WriteLine($"Is development according to ME? '{isMyDevelopment}'");
// --------------------

rootComponents.Add<App>("#app");
rootComponents.Add<HeadOutlet>("head::after");

services.AddScoped(_ => new HttpClient
{
    BaseAddress = new Uri(baseAddress)
});

var authSection = isMyDevelopment ? "AuthDevelopment" : "AuthProduction"; 

services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind(authSection, options.ProviderOptions);
});

var servicesSection = isMyDevelopment ? "ServicesDevelopment" : "ServicesProduction";
var servicesConfig = config.GetSection(servicesSection).Get<Services>();

services.AddHttpClient(Service.UserTimeline, client =>
{
    client.BaseAddress = new Uri(servicesConfig?.UserTimeline ?? string.Empty);
});

services.AddHttpClient(Service.UserProfile, client =>
{
    client.BaseAddress = new Uri(servicesConfig?.UserProfile ?? string.Empty);
});

Console.WriteLine($"UserTimelineService is '{servicesConfig?.UserTimeline}'");
Console.WriteLine($"UserProfileService is '{servicesConfig?.UserProfile}'");

await builder.Build().RunAsync();