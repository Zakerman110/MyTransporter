using IdentityModel;
using IdentityServer.Data;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentityServer.Services
{
    public class CustomProfileService : IProfileService
    {
        protected UserManager<ApplicationUser> _userManager;

        public CustomProfileService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await _userManager.GetUserAsync(context.Subject);

            var claims = context.Subject.FindAll(JwtClaimTypes.Role);
            var listClaims = claims.ToList();
            listClaims.Add(new Claim("username", user.UserName));
            context.IssuedClaims.AddRange(listClaims);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.CompletedTask;
        }
    }
}
