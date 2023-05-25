using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorClient;
using BlazorClient.Config;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var rootComponents = builder.RootComponents;
var services = builder.Services;

rootComponents.Add<App>("#app");
rootComponents.Add<HeadOutlet>("head::after");

services.AddScoped(_ => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Local", options.ProviderOptions);
});

// custom
services.AddHttpClient("UserTimelineService", client =>
{
    client.BaseAddress = new Uri(Services.UserTimeline);
});
services.AddHttpClient("UserProfileService", client =>
{
    client.BaseAddress = new Uri(Services.UserProfile);
});

await builder.Build().RunAsync();