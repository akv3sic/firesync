using FireSync.Entities;

namespace FireSync.Repositories.Interfaces
{
    public interface IApplicationUserInterventionRepository
    {
        Task AddAsync(ApplicationUserIntervention userIntervention);

        Task AddRangeAsync(IEnumerable<ApplicationUserIntervention> userInterventions);

        Task<List<ApplicationUserIntervention>> GetByInterventionIdAsync(Guid interventionId);

        Task<List<ApplicationUserIntervention>> GetByUserIdAsync(string userId);

        Task<bool> ExistsAsync(Guid interventionId, string userId);

        Task RemoveAsync(Guid interventionId, string userId);

        Task RemoveAllByInterventionIdAsync(Guid interventionId);

        Task RemoveAllByUserIdAsync(string userId);
    }
}
