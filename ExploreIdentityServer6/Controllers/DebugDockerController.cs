using ExploreIdentityServer6.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ExploreIdentityServer6.Controllers;

public class DebugDockerController : Controller
{
    private readonly IHostingEnvironment _hostingEnvironment;

    public DebugDockerController(IHostingEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public bool IsDockerMode()
    {
        return _hostingEnvironment.IsDocker();
    }
}