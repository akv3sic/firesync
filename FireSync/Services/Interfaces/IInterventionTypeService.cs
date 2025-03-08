using FireSync.Common;
using FireSync.DTOs.InterventionTypes;

namespace FireSync.Services.Interfaces
{
    public interface IInterventionTypeService
    {
        Task<(IEnumerable<InterventionTypeOutputDto> InterventionTypes, PaginationMetadata Pagination)> GetPagedInterventionTypesAsync(int pageNumber, int pageSize = 10);
        Task<IEnumerable<InterventionTypeOutputDto>> GetAllInterventionTypesAsync();
        Task<InterventionTypeOutputDto?> GetInterventionTypeByIdAsync(int id);
        Task AddInterventionTypeAsync(InterventionTypeInputDto interventionType);
        Task UpdateInterventionTypeAsync(InterventionTypeUpdateDto interventionType);
        Task DeleteInterventionTypeAsync(int interventionTypeId);
    }
}
