using FireSync.Common;
using FireSync.DTOs.Interventions;

namespace FireSync.Services.Interfaces
{
    public interface IInterventionService
    {
        /// <summary>
        /// Retrieves all interventions.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A tuple containing the interventions and pagination metadata.</returns>
        Task<(IEnumerable<InterventionOutputDto> Interventions, PaginationMetadata Pagination)> GetAllInterventionsAsync(int pageNumber, int pageSize = 10);

        /// <summary>
        /// Adds a new intervention with optional firefighter assignments.
        /// </summary>
        /// <param name="intervention">The intervention to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddInterventionAsync(InterventionInputDto intervention);

        /// <summary>
        /// Deletes an intervention.
        /// </summary>
        /// <param name="interventionId">The ID of the intervention to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteInterventionAsync(Guid interventionId);
    }
}
