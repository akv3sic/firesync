using FireSync.Common;
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
        /// Gets paginated list of firefighters.
        /// </summary>
        /// <param name="pageNumber">Current page number.</param>
        /// <param name="pageSize">Number of items per page.</param>
        /// <returns>Tuple containing a list of UserOutputDto and PaginationMetadata.</returns>
        Task<(IEnumerable<UserOutputDto>, PaginationMetadata)> GetPagedFirefightersAsync(int pageNumber, int pageSize = 10);

        /// <summary>
        /// Gets all staff members except firefighters.
        /// </summary>
        Task<List<UserOutputDto>> GetNonFirefighterStaffAsync();

        /// <summary>
        /// Gets paginated list of non-firefighter staff members.
        /// </summary>
        /// <param name="pageNumber">Current page number.</param>
        /// <param name="pageSize">Number of items per page.</param>
        /// <returns>Tuple containing a list of UserOutputDto and PaginationMetadata.</returns>
        Task<(IEnumerable<UserOutputDto>, PaginationMetadata)> GetPagedNonFirefighterStaffAsync(int pageNumber, int pageSize = 10);

        /// <summary>
        /// Adds a new staff member.
        /// </summary>
        /// <param name="userInputDto">DTO containing user details.</param>
        /// <returns>IdentityResult indicating success or failure.</returns>
        Task<IdentityResult> AddStaffAsync(UserInputDto userInputDto);
    }
}
