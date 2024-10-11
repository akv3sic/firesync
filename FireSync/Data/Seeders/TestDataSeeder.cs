using FireSync.Entities;
using FireSync.Enums;
using FireSync.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FireSync.Data.Seeders
{
    public static class TestDataSeeder
    {
        /// <summary>
        /// Seeds test data into the database.
        /// </summary>
        /// <param name="dbContext">The application database context.</param>
        /// <param name="userManager">The user manager.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <summary>
        /// Seeds test data into the database if certain conditions are met.
        /// </summary>
        /// <param name="dbContext">The application database context.</param>
        /// <param name="userManager">The user manager.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task SeedData(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            var nonAdminUsersExist = await userManager.Users.AnyAsync(u => u.LastName != "Admin");

            if (!nonAdminUsersExist)
            {
                await SeedTestUsers(userManager);
            }

            var interventionsExist = await dbContext.Interventions.AnyAsync();

            if (!interventionsExist)
            {
                await SeedTestInterventions(dbContext, userManager);
            }
        }

        private static async Task SeedTestUsers(UserManager<ApplicationUser> userManager)
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

        private static async Task SeedTestInterventions(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            // Ensure there are firefighters available to assign to interventions
            var firefighters = await userManager.GetUsersInRoleAsync(Roles.Firefighter.ToString());

            if (firefighters == null || firefighters.Count == 0)
            {
                throw new Exception("No firefighters available for seeding interventions.");
            }

            var random = new Random();

            var interventions = new List<Intervention>
            {
                new Intervention { Title = "Požar šume kod Omiša", StartTime = DateTime.UtcNow.AddDays(-2), Description = "Gašenje velikog požara šume." },
                new Intervention { Title = "Prometna nesreća na autocesti", StartTime = DateTime.UtcNow.AddDays(-1), Description = "Intervencija u prometnoj nesreći." },
                new Intervention { Title = "Poplava u lokalnom naselju", StartTime = DateTime.UtcNow.AddDays(-5), Description = "Evakuacija stanovništva zbog poplave." }
            };

            foreach (var intervention in interventions)
            {
                dbContext.Interventions.Add(intervention);

                // Randomly assign 2 to 3 firefighters
                var assignedFirefighters = firefighters.OrderBy(x => random.Next()).Take(random.Next(2, 4)).ToList();

                foreach (var firefighter in assignedFirefighters)
                {
                    dbContext.ApplicationUserInterventions.Add(new ApplicationUserIntervention
                    {
                        InterventionId = intervention.Id,
                        ApplicationUserId = firefighter.Id
                    });
                }
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
