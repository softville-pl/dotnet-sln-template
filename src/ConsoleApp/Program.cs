// See https://aka.ms/new-console-template for more information


using ConsoleApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using var host = CreateHostBuilder(args).Build();
await host.StartAsync();

var sampleService = host.Services.GetRequiredService<ISampleService>();

await sampleService.DisplayAsync("Hello world!");

Console.WriteLine("Press any key to continue");
Console.ReadKey();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .UseConsoleLifetime()
        .ConfigureLogging((_, builder) => builder
            .AddConsole()
            .AddFilter("Microsoft.Hosting", LogLevel.Warning)
            .AddFilter("System.Net.Http", LogLevel.Warning)
            .SetMinimumLevel(LogLevel.Information))
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<ISampleService, SampleService>();
        });
