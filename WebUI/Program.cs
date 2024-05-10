using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NetcodeHub.Packages.Components.Toast;
using WebUI;
using Application.DependencyInjection;
using Application.Extensions;
using Application.Services;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddApplicationService();
builder.Services.AddScoped<NetcodeHubToast>();
//builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
//builder.Services.AddCascadingAuthenticationState();
//builder.Services.AddOptions();
//builder.Services.AddAuthorizationCore();
await builder.Build().RunAsync();
