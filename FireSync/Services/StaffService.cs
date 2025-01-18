using AutoMapper;
using FireSync.Common;
using FireSync.DTOs;
using FireSync.DTOs.Users;
using FireSync.Enums;
using FireSync.Helpers;
using FireSync.Models;
using FireSync.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FireSync.Services
{
    public class StaffService : IStaffService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;

        public StaffService(IServiceProvider serviceProvider, IMapper mapper)
        {
            _serviceProvider = serviceProvider;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<List<UserOutputDto>> GetStaffAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var users = await userManager.Users.ToListAsync();
            return await MapUsersToDtoAsync(users, userManager);
        }

        /// <inheritdoc/>
        public async Task<List<UserOutputDto>> GetFirefightersAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var users = await userManager.Users.ToListAsync();
            var firefighters = new List<ApplicationUser>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                if (roles.Contains(Roles.Firefighter.ToString()))
                {
                    firefighters.Add(user);
                }
            }

            return await MapUsersToDtoAsync(firefighters, userManager);
        }

        /// <inheritdoc/>
        public async Task<(IEnumerable<UserOutputDto>, PaginationMetadata)> GetPagedFirefightersAsync(int pageNumber, int pageSize = 10)
        {
            using var scope = _serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var users = await userManager.Users.ToListAsync();
            var firefighters = new List<ApplicationUser>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                if (roles.Contains(Roles.Firefighter.ToString()))
                {
                    firefighters.Add(user);
                }
            }

            var totalItemCount = firefighters.Count;
            var pagedFirefighters = firefighters
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);
            return (await MapUsersToDtoAsync(pagedFirefighters, userManager), paginationMetadata);
        }

        /// <inheritdoc/>
        public async Task<List<UserOutputDto>> GetNonFirefighterStaffAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var users = await userManager.Users.ToListAsync();
            var nonFirefighters = new List<ApplicationUser>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                if (!roles.Contains(Roles.Firefighter.ToString()))
                {
                    nonFirefighters.Add(user);
                }
            }

            return await MapUsersToDtoAsync(nonFirefighters, userManager);
        }

        public async Task<(IEnumerable<UserOutputDto>, PaginationMetadata)> GetPagedNonFirefighterStaffAsync(int pageNumber, int pageSize = 10)
        {
            using var scope = _serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var users = await userManager.Users.ToListAsync();
            var nonFirefighters = new List<ApplicationUser>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                if (!roles.Contains(Roles.Firefighter.ToString()))
                {
                    nonFirefighters.Add(user);
                }
            }

            var totalItemCount = nonFirefighters.Count;

            var pagedUsers = nonFirefighters
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);
            return (await MapUsersToDtoAsync(pagedUsers, userManager), paginationMetadata);
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> AddStaffAsync(UserInputDto userInputDto)
        {
            using var scope = _serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var newUser = _mapper.Map<ApplicationUser>(userInputDto);
            newUser.UserName = newUser.Email;

            var generatedPassword = PasswordGenerator.GeneratePassword();
            var result = await userManager.CreateAsync(newUser, generatedPassword);

            if (!result.Succeeded)
            {
                return result;
            }

            foreach (var role in userInputDto.Roles)
            {
                var roleResult = await userManager.AddToRoleAsync(newUser, role.ToString());
                if (!roleResult.Succeeded)
                {
                    return roleResult;
                }
            }

            return IdentityResult.Success;
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
