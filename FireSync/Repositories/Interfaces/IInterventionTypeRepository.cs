using FireSync.Entities;

namespace FireSync.Repositories.Interfaces
{
    public interface IInterventionTypeRepository
    {
        Task<(List<InterventionType> InterventionTypes, int TotalItemCount)> GetPagedInterventionTypesAsync(int pageNumber, int pageSize);
        Task<List<InterventionType>> GetAllInterventionTypesAsync();
        Task<InterventionType?> GetByIdAsync(Guid id);
        Task AddAsync(InterventionType interventionType);
        Task UpdateAsync(InterventionType interventionType);
        Task DeleteAsync(Guid interventionTypeId);
    }
}
