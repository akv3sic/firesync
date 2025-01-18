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
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public StaffService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
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
        public async Task<(IEnumerable<UserOutputDto>, PaginationMetadata)> GetPagedFirefightersAsync(int pageNumber, int pageSize = 10)
        {
            var Users = await userManager.Users.ToListAsync();
            var firefighters = new List<UserOutputDto>();
            foreach (var user in Users)
            {
                var roles = await userManager.GetRolesAsync(user);

                if (!roles.Contains(Roles.Firefighter.ToString()))
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

                firefighters.Add(userOutputDto);
            }

            var totalItemCount = firefighters.Count;

            var pagedFirefighters = firefighters
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            return (pagedFirefighters, paginationMetadata);
        }

        /// <inheritdoc/>
        public async Task<List<UserOutputDto>> GetNonFirefighterStaffAsync()
        {
            var users = await this.userManager.Users.ToListAsync();
            var userOutputDtos = new List<UserOutputDto>();

            foreach (var user in users)
            {
                var roles = await this.userManager.GetRolesAsync(user);

                if (roles.Contains(Roles.Firefighter.ToString()))
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
        public async Task<IdentityResult> AddStaffAsync(UserInputDto userInputDto)
        {
            var newUser = mapper.Map<ApplicationUser>(userInputDto);
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
    }
}
