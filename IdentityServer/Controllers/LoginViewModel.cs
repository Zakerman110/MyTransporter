using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Controllers
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("(?=.*[0-9])(?=.*[a-z]).{6,}", ErrorMessage = "Password must be at least 6 characters and contain lowercase letters and digits.")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

        public IEnumerable<AuthenticationScheme>? ExternalProviders { get; set; }
    }
}
