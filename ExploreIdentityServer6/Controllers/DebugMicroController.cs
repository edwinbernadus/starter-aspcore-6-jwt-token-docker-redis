using System.Threading.Tasks;
using ClassLibrary1;
using ExploreIdentityServer6.Models;
using ExploreIdentityServer6.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;


namespace ExploreIdentityServer6.Controllers
{
    public class DebugMicroController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        bool IsDockerMode { get; set; }
        public DebugMicroController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            this.IsDockerMode = hostingEnvironment.IsDocker();
        }

        

        // /debugMicro/GetStudent
        [ClassLibraryJwt.ModuleLib.Authorize]
        public async Task<ContentData<Student>> GetStudent()
        {
            var result = await ProxyCallHelper<Student>.Get("/Home/InquiryStudent/25", 
                ServerList.server_one, this.HttpContext,this.IsDockerMode);
            return result;
        }
        
        // /debugMicro/GetStudentError
        [ClassLibraryJwt.ModuleLib.Authorize]
        public async Task<ContentData<Student>> GetStudentError()
        {
            var result = await ProxyCallHelper<Student>
                .Get("/Home/InquiryStudentError/25", ServerList.server_one, this.HttpContext,this.IsDockerMode);
            return result;
        }

        // /debugMicro/GetErrorDataOne
        [ClassLibraryJwt.ModuleLib.Authorize]
        public async Task<string> GetErrorDataOne()
        {
            string result = await ProxyCallHelper.Get("/Home/TestError",
                ServerList.server_one, this.HttpContext,this.IsDockerMode);
            return result;
        }

        // /debugMicro/getDataOne
        [ClassLibraryJwt.ModuleLib.Authorize]
        public async Task<string> GetDataOne()
        {
            string result = await ProxyCallHelper.Get("/Home/Info",
                ServerList.server_one, this.HttpContext,this.IsDockerMode);
            return result;
        }

        // /debugMicro/getDataTwo
        [ClassLibraryJwt.ModuleLib.Authorize]
        public async Task<string> GetDataTwo()
        {
            var result = await this.HttpContext.GetRequest("/Home/Info", 
                ServerList.server_two,this.IsDockerMode);
            // string result = await ProxyCallHelper.Get("/Home/Info", "server_two",this.HttpContext);
            return result;
        }
    }
}