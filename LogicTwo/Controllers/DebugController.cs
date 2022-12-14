using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;

namespace LogicTwo.Controllers
{
    public class DebugController : Controller
    {
        public string Version()
        {
            return $"two-{GlobalParamVersion.Version}";
        }
    }
}