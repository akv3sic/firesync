using FireSync.DTOs;

namespace FireSync.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>A list of <see cref="UserDto"/> instances.</returns>
        Task<List<UserOutputDto>> GetUsersAsync();

        /// <summary>
        /// Gets all admin users.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<List<UserOutputDto>> GetAdminUsersAsync();

        /// <summary>
        /// Checks if there is only one admin user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, containing a boolean value indicating if there is only one admin user.</returns>
        Task<bool> IsOnlyOneAdminUserAsync();
    }
}
