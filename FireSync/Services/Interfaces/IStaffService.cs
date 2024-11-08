using FireSync.DTOs;
using FireSync.DTOs.Users;
using Microsoft.AspNetCore.Identity;

namespace FireSync.Services.Interfaces
{
    public interface IStaffService
    {
        /// <summary>
        /// Gets all staff members.
        /// </summary>
        Task<List<UserOutputDto>> GetStaffAsync();

        /// <summary>
        /// Gets all firefighters.
        /// </summary>
        Task<List<UserOutputDto>> GetFirefightersAsync();

        /// <summary>
        /// Gets all staff members except firefighters.
        /// </summary>
        Task<List<UserOutputDto>> GetNonFirefighterStaffAsync();

        /// <summary>
        /// Adds a new staff member.
        /// </summary>
        /// <param name="userInputDto">DTO containing user details.</param>
        /// <returns>IdentityResult indicating success or failure.</returns>
        Task<IdentityResult> AddStaffAsync(UserInputDto userInputDto);
    }
}
