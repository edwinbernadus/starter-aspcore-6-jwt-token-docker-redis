using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;

namespace ExploreIdentityServer6.Controllers
{
    
    public class DebugController : Controller
    {
        public string Version()
        {
            return $"main-{GlobalParamVersion.Version}";
        }

       
    }
}