using FireSync.Common;
using FireSync.DTOs;
using FireSync.Enums;
using FireSync.Models;
using FireSync.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FireSync.Services
{
    /// <summary>
    /// Represents the user service.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        public UserService(
            UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        /// <inheritdoc/>
        public async Task<List<UserOutputDto>> GetUsersAsync()
        {
            var users = await this.userManager.Users.ToListAsync();
            var userOutputDtos = new List<UserOutputDto>();

            foreach (var user in users)
            {
                var roles = await this.userManager.GetRolesAsync(user);
                var userOutputDto = new UserOutputDto
                {
                    Id = Guid.Parse(user.Id),
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
        public async Task<(IEnumerable<UserOutputDto>, PaginationMetadata)> GetPagedUsersAsync(int pageNumber, int pageSize = 10)
        {
            var users = await userManager.Users.ToListAsync();
            var userDtos = new List<UserOutputDto>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                var userDto = new UserOutputDto
                {
                    Id = Guid.Parse(user.Id),
                    Email = user.Email ?? string.Empty,
                    Roles = roles.ToList(),
                    FirstName = user.FirstName ?? string.Empty,
                    LastName = user.LastName ?? string.Empty,
                };

                userDtos.Add(userDto);
            }

            var totalItemCount = userDtos.Count;

            var pagedUsers = userDtos
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            return (pagedUsers, paginationMetadata);
        }

        /// <inheritdoc/>
        public async Task<List<UserOutputDto>> GetAdminUsersAsync()
        {
            var users = await this.userManager.Users.ToListAsync();
            var userOutputDtos = new List<UserOutputDto>();

            foreach (var user in users)
            {
                var roles = await this.userManager.GetRolesAsync(user);

                if (!roles.Contains(Roles.Admin.ToString()))
                {
                    continue;
                }

                var userOutputDto = new UserOutputDto
                {
                    Id = Guid.Parse(user.Id),
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
        public async Task<bool> IsOnlyOneAdminUserAsync()
        {
            var adminUsers = await this.GetAdminUsersAsync();
            return adminUsers.Count == 1;
        }

        /// <inheritdoc/>
        public async Task<string> GetUserInitialsAsync(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var initials = user.FirstName[0].ToString() + user.LastName[0].ToString();
                return initials.ToUpper();
            }

            return string.Empty;
        }
    }
}
