using FireSync.DTOs;
using FireSync.Enums;
using FireSync.Models;
using FireSync.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FireSync.Services
{
    public class StaffService : IStaffService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public StaffService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }


        /// <inheritdoc/>
        public async Task<List<UserOutputDto>> GetStaffAsync()
        {
            var users = await this.userManager.Users.ToListAsync();
            var userOutputDtos = new List<UserOutputDto>();

            foreach (var user in users)
            {
                var roles = await this.userManager.GetRolesAsync(user);
                var userOutputDto = new UserOutputDto
                {
                    Id = Guid.Parse(user.Id),
                    Username = user.UserName ?? string.Empty,
                    Email = user.Email ?? string.Empty,
                    Roles = roles.ToList(),
                    FirstName = user.FirstName ?? string.Empty,
                    LastName = user.LastName ?? string.Empty,
                };

                userOutputDtos.Add(userOutputDto);
            }

            return userOutputDtos;
        }

        /// <inheritdoc/>
        public async Task<List<UserOutputDto>> GetFirefightersAsync()
        {
            var users = await this.userManager.Users.ToListAsync();
            var userOutputDtos = new List<UserOutputDto>();

            foreach (var user in users)
            {
                var roles = await this.userManager.GetRolesAsync(user);

                if (!roles.Contains(Roles.Firefighter.ToString()))
                {
                    continue;
                }

                var userOutputDto = new UserOutputDto
                {
                    Id = Guid.Parse(user.Id),
                    Username = user.UserName ?? string.Empty,
                    Email = user.Email ?? string.Empty,
                    Roles = roles.ToList(),
                    FirstName = user.FirstName ?? string.Empty,
                    LastName = user.LastName ?? string.Empty,
                };

                userOutputDtos.Add(userOutputDto);
            }

            return userOutputDtos;
        }
    }
}
