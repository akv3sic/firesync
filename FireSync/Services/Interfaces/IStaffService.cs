using FireSync.DTOs;

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
    }
}
