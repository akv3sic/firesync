using FireSync.Entities;

namespace FireSync.Repositories.Interfaces
{
    public interface IInterventionRepository
    {
        /// <summary>
        /// Retrieves all interventions from the database.
        /// </summary>
        /// <returns>A list of interventions.</returns>
        Task<List<Intervention>> GetAllInterventionsAsync();
    }
}
