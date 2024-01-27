// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Extensions.Logging;

namespace ConsoleApp;

internal class SampleService(ILogger<SampleService> logger) : ISampleService
{
    public Task DisplayAsync(string message)
    {
        logger.LogInformation("Message to display: {message}",message);
        return Task.CompletedTask;
    }
}
