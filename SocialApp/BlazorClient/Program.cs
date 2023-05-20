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

// custom
services.AddHttpClient("UserTimelineService", client =>
{
    client.BaseAddress = new Uri("http://127.0.0.1:5000/");
});

await builder.Build().RunAsync();