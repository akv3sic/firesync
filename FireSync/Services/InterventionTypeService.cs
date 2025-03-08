using AutoMapper;
using FireSync.Common;
using FireSync.DTOs.InterventionTypes;
using FireSync.Entities;
using FireSync.Repositories.Interfaces;
using FireSync.Services.Interfaces;

namespace FireSync.Services
{
    public class InterventionTypeService : IInterventionTypeService
    {
        private readonly IInterventionTypeRepository _interventionTypeRepository;
        private readonly IMapper _mapper;

        public InterventionTypeService(IInterventionTypeRepository interventionTypeRepository, IMapper mapper)
        {
            _interventionTypeRepository = interventionTypeRepository;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<InterventionTypeOutputDto> InterventionTypes, PaginationMetadata Pagination)> GetPagedInterventionTypesAsync(int pageNumber, int pageSize)
        {
            var (interventionTypes, totalItemCount) = await _interventionTypeRepository.GetPagedInterventionTypesAsync(pageNumber, pageSize);
            var interventionTypeDtos = _mapper.Map<IEnumerable<InterventionTypeOutputDto>>(interventionTypes);
            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            return (interventionTypeDtos, paginationMetadata);
        }

        public async Task<IEnumerable<InterventionTypeOutputDto>> GetAllInterventionTypesAsync()
        {
            var interventionTypes = await _interventionTypeRepository.GetAllInterventionTypesAsync();
            return _mapper.Map<IEnumerable<InterventionTypeOutputDto>>(interventionTypes);
        }

        public async Task<InterventionTypeOutputDto?> GetInterventionTypeByIdAsync(int id)
        {
            var interventionType = await _interventionTypeRepository.GetByIdAsync(id);
            return interventionType != null ? _mapper.Map<InterventionTypeOutputDto>(interventionType) : null;
        }

        public async Task AddInterventionTypeAsync(InterventionTypeInputDto interventionType)
        {
            var entity = _mapper.Map<InterventionType>(interventionType);
            await _interventionTypeRepository.AddAsync(entity);
        }

        public async Task UpdateInterventionTypeAsync(InterventionTypeUpdateDto interventionType)
        {
            var entity = _mapper.Map<InterventionType>(interventionType);
            await _interventionTypeRepository.UpdateAsync(entity);
        }

        public async Task DeleteInterventionTypeAsync(int interventionTypeId)
        {
            await _interventionTypeRepository.DeleteAsync(interventionTypeId);
        }
    }
}
