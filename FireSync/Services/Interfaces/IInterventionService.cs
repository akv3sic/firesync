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
    }
}
