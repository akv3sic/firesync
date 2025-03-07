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

        /// <summary>
        /// Adds a new intervention to the database.
        /// </summary>
        /// <param name="intervention">The intervention entity.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddAsync(Intervention intervention);

        /// <summary>
        /// Deletes an intervention from the database.
        /// </summary>
        /// <param name="interventionId">The ID of the intervention to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(Guid interventionId);
    }
}
