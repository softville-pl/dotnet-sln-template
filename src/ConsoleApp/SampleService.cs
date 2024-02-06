// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ConsoleApp;

internal class SampleService(ILogger<SampleService> logger, IOptions<Configuration> config) : ISampleService
{
    public Task DisplayAsync(string message)
    {
        logger.LogInformation("Message to display: {message}",message);
        logger.LogInformation("Configuration {configKey}: {configValue}", nameof(Configuration.ConfigName), config.Value.ConfigName);
        return Task.CompletedTask;
    }
}
