﻿// See https://aka.ms/new-console-template for more information


using ConsoleApp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

//To set value via EnvVar
//Environment.SetEnvironmentVariable("EXAMPLE__ConfigName", "MyExecOverwrittenValue");

using var host = CreateHostBuilder(args).Build();
await host.StartAsync();

var sampleService = host.Services.GetRequiredService<ISampleService>();
await sampleService.DisplayAsync("Hello world!");

Console.WriteLine("Press any key to continue");
Console.ReadKey();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((context, configBuilder) =>
        {
            configBuilder
                .AddJsonFile("appSettings.json", optional: false)
                .AddJsonFile($"appSettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables("EXAMPLE:"); //https://learn.microsoft.com/en-us/dotnet/core/compatibility/extensions/7.0/environment-variable-prefixn
        })
        .UseConsoleLifetime()
        .ConfigureLogging((_, builder) => builder
            .AddConsole()
            .AddFilter("Microsoft.Hosting", LogLevel.Warning)
            .AddFilter("System.Net.Http", LogLevel.Warning)
            .SetMinimumLevel(LogLevel.Information))
        .ConfigureServices((context, services) =>
        {
            services.AddSingleton<ISampleService, SampleService>();
            services.Configure<Configuration>(context.Configuration);
        });
