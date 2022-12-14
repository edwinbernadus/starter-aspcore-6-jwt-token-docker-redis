using System.Threading.Tasks;
using ClassLibraryJwt.ModuleLib;
using ExploreIdentityServer6.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Mvc.SignInResult;


namespace ExploreIdentityServer6.Controllers
{
    public class UsersController : Controller
    {
        private readonly AuthenticateService _authenticateService;

        public UsersController(AuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }


       

        public async Task<IActionResult> Login(string userName, string password)
        {
            AuthenticateRequest model = new AuthenticateRequest()
            {
                Username = userName,
                Password = password
            };
            var response = await _authenticateService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [ClassLibraryJwt.ModuleLib.Authorize]
        public IActionResult GetUser()
        {
            var users = User?.Identity?.Name ?? "no_data";
            // var users = _userService.GetAll();
            return Ok(users);
        }
    }
}