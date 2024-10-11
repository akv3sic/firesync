using FireSync.Enums;
using FireSync.Models;
using Microsoft.AspNetCore.Identity;

namespace FireSync.Data.Seeders
{
    public static class IdentityDataSeeder
    {
        /// <summary>
        /// Seeds the roles from the Roles enum.
        /// </summary>
        /// <param name="roleManager">The role manager.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (var role in Enum.GetValues(typeof(Roles)).Cast<Roles>())
            {
                var roleName = role.ToString();
                if (!string.IsNullOrEmpty(roleName) && !await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        /// <summary>
        /// Seeds the default admin user with the Admin role only.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task SeedDefaultAdmin(UserManager<ApplicationUser> userManager)
        {
            var defaultAdmin = new ApplicationUser
            {
                UserName = "admin@firesync.xyz",
                Email = "admin@firesync.xyz",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                FirstName = "FireSync",
                LastName = "Admin",
            };

            if (userManager.Users.All(u => u.Email != defaultAdmin.Email))
            {
                var user = await userManager.FindByEmailAsync(defaultAdmin.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultAdmin, "FireSyncAdmin123!");
                    await userManager.AddToRoleAsync(defaultAdmin, Roles.Admin.ToString());
                }
            }
        }
    }
}
