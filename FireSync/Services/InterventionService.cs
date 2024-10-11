using AutoMapper;
using FireSync.Common;
using FireSync.DTOs.Interventions;
using FireSync.Repositories.Interfaces;
using FireSync.Services.Interfaces;

namespace FireSync.Services
{
    public class InterventionService : IInterventionService
    {
        private readonly IInterventionRepository _interventionRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="InterventionService"/> class.
        /// </summary>
        /// <param name="interventionRepository">The intervention repository.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public InterventionService(IInterventionRepository interventionRepository, IMapper mapper)
        {
            _interventionRepository = interventionRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<(IEnumerable<InterventionOutputDto> Interventions, PaginationMetadata Pagination)> GetAllInterventionsAsync(int pageNumber, int pageSize)
        {
            var (interventions, totalItemCount) = await _interventionRepository.GetPagedInterventionsAsync(pageNumber, pageSize);

            // Map interventions to DTOs
            var interventionDtos = _mapper.Map<IEnumerable<InterventionOutputDto>>(interventions);

            // Create pagination metadata
            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            return (interventionDtos, paginationMetadata);
        }
    }
}
