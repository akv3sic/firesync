using FireSync.Common;
using FireSync.DTOs;

namespace FireSync.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>A list of <see cref="UserOutputDto"/> instances.</returns>
        Task<List<UserOutputDto>> GetUsersAsync();

        /// <summary>
        /// Gets the paged users.
        /// </summary>
        /// <param name="pageNumber">The current page number.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A tuple containing the list of users and pagination metadata.</returns>
        Task<(IEnumerable<UserOutputDto>, PaginationMetadata)> GetPagedUsersAsync(int pageNumber, int pageSize = 10);

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

        /// <summary>
        /// Gets the initials of the user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A string representing the initials of the user.</returns>
        Task<string> GetUserInitialsAsync(string userId);
    }
}
