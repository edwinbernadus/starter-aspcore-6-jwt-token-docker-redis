using System;
using Microsoft.AspNetCore.Hosting;

namespace Logic0ne.Controllers;

public static class DockerHelper
{
    public static bool IsDocker(this IHostingEnvironment hostingEnvironment)
    {
        return !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER"));
    }
}