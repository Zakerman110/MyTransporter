using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {

        }

        public ApplicationUser(string userName) :base(userName)
        {

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
