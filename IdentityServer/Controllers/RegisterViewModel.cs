using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Controllers
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("(?=.*[0-9])(?=.*[a-z]).{6,}", ErrorMessage = "Password must be at least 6 characters and contain lowercase letters and digits.")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [RegularExpression("(?=.*[0-9])(?=.*[a-z]).{6,}", ErrorMessage = "Password must be at least 6 characters and contain lowercase letters and digits.")]
        public string ConfirmPassword { get; set; }
        public string ReturnUrl { get; set; }
    }
}
