using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace Logic0ne.Controllers
{
    public class DebugController : Controller
    {
        
        public string Version()
        {
            return $"one-{GlobalParamVersion.Version}";
        }

      
    }
}