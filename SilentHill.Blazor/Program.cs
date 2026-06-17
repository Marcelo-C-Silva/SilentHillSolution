using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SilentHill.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiUrl = builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5235";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });
await builder.Build().RunAsync();