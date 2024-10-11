using FireSync.Enums;
using FireSync.Models;
using Microsoft.AspNetCore.Identity;

namespace FireSync.Data.Seeders
{
    public static class TestDataSeeder
    {
        /// <summary>
        /// Seeds test users for demo or development instances.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task SeedTestUsers(UserManager<ApplicationUser> userManager)
        {
            // Firefighter 1 (also Admin)
            var firefighterAdmin = new ApplicationUser
            {
                UserName = "mate.matic@firesync.xyz",
                Email = "mate.matic@firesync.xyz",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                FirstName = "Mate",
                LastName = "Matić",
                PhoneNumber = "+385911234567"
            };

            if (userManager.Users.All(u => u.Email != firefighterAdmin.Email))
            {
                var user = await userManager.FindByEmailAsync(firefighterAdmin.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(firefighterAdmin, "FireAdmin123!");
                    await userManager.AddToRoleAsync(firefighterAdmin, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(firefighterAdmin, Roles.Firefighter.ToString());
                }
            }

            // Firefighter 2
            var firefighter = new ApplicationUser
            {
                UserName = "ivan.ivanic@firesync.xyz",
                Email = "ivan.ivanic@firesync.xyz",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                FirstName = "Ivan",
                LastName = "Ivanić",
                PhoneNumber = "+385921234567"
            };

            if (userManager.Users.All(u => u.Email != firefighter.Email))
            {
                var user = await userManager.FindByEmailAsync(firefighter.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(firefighter, "Firefighter123!");
                    await userManager.AddToRoleAsync(firefighter, Roles.Firefighter.ToString());
                }
            }

            // Legal Officer (also Firefighter)
            var legalOfficer = new ApplicationUser
            {
                UserName = "ana.anic@firesync.xyz",
                Email = "ana.anic@firesync.xyz",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                FirstName = "Ana",
                LastName = "Anić",
                PhoneNumber = "+385931234567"
            };

            if (userManager.Users.All(u => u.Email != legalOfficer.Email))
            {
                var user = await userManager.FindByEmailAsync(legalOfficer.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(legalOfficer, "LegalOfficer123!");
                    await userManager.AddToRoleAsync(legalOfficer, Roles.LegalOfficer.ToString());
                    await userManager.AddToRoleAsync(legalOfficer, Roles.Firefighter.ToString());
                }
            }

            // Accountant (not a Firefighter)
            var accountant = new ApplicationUser
            {
                UserName = "petar.peric@firesync.xyz",
                Email = "petar.peric@firesync.xyz",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                FirstName = "Petar",
                LastName = "Perić",
                PhoneNumber = "+385941234567"
            };

            if (userManager.Users.All(u => u.Email != accountant.Email))
            {
                var user = await userManager.FindByEmailAsync(accountant.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(accountant, "Accountant123!");
                    await userManager.AddToRoleAsync(accountant, Roles.Accountant.ToString());
                }
            }
        }
    }
}
