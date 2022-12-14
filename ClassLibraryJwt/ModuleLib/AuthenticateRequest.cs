using System.ComponentModel.DataAnnotations;

namespace ClassLibraryJwt.ModuleLib
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}