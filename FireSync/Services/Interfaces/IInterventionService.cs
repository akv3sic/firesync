using FireSync.DTOs.Interventions;

namespace FireSync.Services.Interfaces
{
    public interface IInterventionService
    {
        /// <summary>
        /// Retrieves all interventions.
        /// </summary>
        /// <returns>A list of interventions.</returns>
        Task<List<InterventionOutputDto>> GetAllInterventionsAsync();
    }
}
