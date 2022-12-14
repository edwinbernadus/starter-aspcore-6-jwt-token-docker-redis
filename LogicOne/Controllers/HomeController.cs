using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Logic0ne.Models;

namespace Logic0ne.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [ClassLibraryJwt.ModuleLib.Authorize]
        public Student InquiryStudent(int id)
        {
            var student = new Student()
            {
                StudentName = $"StudentName-{id}-ver-{GlobalParamVersion.Version}-ServerOne"
            };
            return student;

            // var output = ContentData<Student>.GenerateValid(student);
            // return output;
        }
        
        [ClassLibraryJwt.ModuleLib.Authorize]
        public Student InquiryStudentError(int id)
        {
            var student = new Student()
            {
                StudentName = $"StudentName-{id}-{GlobalParamVersion.Version}-ServerOne"
            };

            throw new ArgumentException($"error student - {id}");
            return student;

            // var output = ContentData<Student>.GenerateValid(student);
            // return output;
        }

        [ClassLibraryJwt.ModuleLib.Authorize]
        public IActionResult Info()
        {
            var users = User?.Identity?.Name ?? "no_data";
            var output = $"server-one-{users}";
            return Ok(output);
        }

        [ClassLibraryJwt.ModuleLib.Authorize]
        public IActionResult TestError()
        {
            throw new ArgumentException("test errror 123");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}