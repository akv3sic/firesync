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
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public UserService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc/>
        public async Task<List<UserOutputDto>> GetUsersAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var users = await userManager.Users.ToListAsync();
            return await MapUsersToDtoAsync(users, userManager);
        }

        /// <inheritdoc/>
        public async Task<(IEnumerable<UserOutputDto>, PaginationMetadata)> GetPagedUsersAsync(int pageNumber, int pageSize = 10)
        {
            using var scope = _serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var users = await userManager.Users.ToListAsync();
            var totalItemCount = users.Count;

            var pagedUsers = users
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);
            return (await MapUsersToDtoAsync(pagedUsers, userManager), paginationMetadata);
        }

        /// <inheritdoc/>
        public async Task<List<UserOutputDto>> GetAdminUsersAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var users = await userManager.Users.ToListAsync();
            var adminUsers = new List<ApplicationUser>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                if (roles.Contains(Roles.Admin.ToString()))
                {
                    adminUsers.Add(user);
                }
            }

            return await MapUsersToDtoAsync(adminUsers, userManager);
        }

        /// <inheritdoc/>
        public async Task<bool> IsOnlyOneAdminUserAsync()
        {
            var adminUsers = await GetAdminUsersAsync();
            return adminUsers.Count == 1;
        }

        /// <inheritdoc/>
        public async Task<string> GetUserInitialsAsync(string userId)
        {
            using var scope = _serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var initials = user.FirstName?[0].ToString() + user.LastName?[0].ToString();
                return initials?.ToUpper() ?? string.Empty;
            }

            return string.Empty;
        }

        /// <summary>
        /// Maps a list of users to their DTO representation.
        /// </summary>
        /// <param name="users">The list of users to map.</param>
        /// <param name="userManager">The UserManager instance for fetching roles.</param>
        /// <returns>A task representing the asynchronous operation, containing a list of <see cref="UserOutputDto"/>.</returns>
        private async Task<List<UserOutputDto>> MapUsersToDtoAsync(List<ApplicationUser> users, UserManager<ApplicationUser> userManager)
        {
            var userOutputDtos = new List<UserOutputDto>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                userOutputDtos.Add(new UserOutputDto
                {
                    Id = Guid.Parse(user.Id),
                    Email = user.Email ?? string.Empty,
                    Roles = roles.ToList(),
                    FirstName = user.FirstName ?? string.Empty,
                    LastName = user.LastName ?? string.Empty,
                });
            }

            return userOutputDtos;
        }
    }
}
