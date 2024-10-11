using FireSync.Entities;

namespace FireSync.Repositories.Interfaces
{
    public interface IInterventionRepository
    {
        /// <summary>
        /// Retrieves paged interventions from the database.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A tuple containing the interventions and the total item count.</returns>
        Task<(List<Intervention> Interventions, int TotalItemCount)> GetPagedInterventionsAsync(int pageNumber, int pageSize);
    }
}
