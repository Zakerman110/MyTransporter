using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Data
{
    public static class RolesConfig
    {
        public static async Task CreateRoles(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var RoleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var UserManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                bool adminRoleExists = await RoleManager.RoleExistsAsync("Admin");

                if (!adminRoleExists)
                {
                    await RoleManager.CreateAsync(new IdentityRole("Admin"));
                }

                bool customerRoleExists = await RoleManager.RoleExistsAsync("Customer");

                if (!customerRoleExists)
                {
                    await RoleManager.CreateAsync(new IdentityRole("Customer"));
                }

                if (await UserManager.FindByNameAsync("Admin") == null)
                {
                    var user = new ApplicationUser() { UserName = "Admin" };
                    await UserManager.CreateAsync(user, "Admin123");
                    await UserManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
