using System.Threading.Tasks;
using ClassLibraryJwt.ModuleLib;
using Microsoft.AspNetCore.Identity;

namespace ExploreIdentityServer6.Services
{
    public class AuthenticateService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUserService _userService;

        public AuthenticateService(SignInManager<IdentityUser> signInManager,IUserService userService)
        {
            _signInManager = signInManager;
            _userService = userService;
        }
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            Microsoft.AspNetCore.Identity.SignInResult signInResult =
                await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            ;
            // return null if user not found
            if (signInResult != Microsoft.AspNetCore.Identity.SignInResult.Success) return null;

            // authentication successful so generate jwt token
            var token = _userService.generateJwtToken(model.Username);

            return new AuthenticateResponse(model.Username, token);
        }
    }
}