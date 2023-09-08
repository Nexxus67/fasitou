using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using fasito;
using fasito.Services;
using Blazor.Extensions.Logging;
using fasito.Interfaces; 





var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");




builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<ErrorHandlingService>();
builder.Services.AddScoped<IMyService, MyService>();
builder.Services.AddScoped<DonationService>();


builder.Services.AddLogging(builder => builder
    .AddBrowserConsole()
    .SetMinimumLevel(LogLevel.Information)
);


await builder.Build().RunAsync();
