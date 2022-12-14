using System.Threading.Tasks;

namespace ClassLibraryJwt.ModuleLib
{
    public interface IUserService
    {
        // Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<User> GetById(string id);
        string generateJwtToken(string userId);
    }
}