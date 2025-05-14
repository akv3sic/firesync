using AutoMapper;
using FireSync.Common;
using FireSync.DTOs.Interventions;
using FireSync.Entities;
using FireSync.Repositories.Interfaces;
using FireSync.Services.Interfaces;

namespace FireSync.Services
{
    public class InterventionService : IInterventionService
    {
        private readonly IInterventionRepository _interventionRepository;
        private readonly IApplicationUserInterventionRepository _applicationUserInterventionRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="InterventionService"/> class.
        /// </summary>
        /// <param name="interventionRepository">The intervention repository.</param>
        /// <param name="applicationUserInterventionRepository">The user intervention repository.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public InterventionService(
            IInterventionRepository interventionRepository,
            IApplicationUserInterventionRepository applicationUserInterventionRepository,
            IMapper mapper)
        {
            _interventionRepository = interventionRepository;
            _applicationUserInterventionRepository = applicationUserInterventionRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<(IEnumerable<InterventionOutputDto> Interventions, PaginationMetadata Pagination)> GetAllInterventionsAsync(int pageNumber, int pageSize = 10)
        {
            var (interventions, totalItemCount) = await _interventionRepository.GetPagedInterventionsAsync(pageNumber, pageSize);
            var interventionDtos = _mapper.Map<IEnumerable<InterventionOutputDto>>(interventions);
            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);
            return (interventionDtos, paginationMetadata);
        }

        /// <inheritdoc />
        public async Task AddInterventionAsync(InterventionInputDto intervention)
        {
            var entity = _mapper.Map<Intervention>(intervention);

            // Add the intervention to get its ID
            await _interventionRepository.AddAsync(entity);

            // Add firefighter assignments if any
            if (intervention.FirefighterIds != null && intervention.FirefighterIds.Count > 0)
            {
                var userInterventions = new List<ApplicationUserIntervention>();

                foreach (var firefighterId in intervention.FirefighterIds)
                {
                    var assignment = new ApplicationUserIntervention
                    {
                        InterventionId = entity.Id,
                        ApplicationUserId = firefighterId.ToString()
                    };

                    userInterventions.Add(assignment);
                }

                await _applicationUserInterventionRepository.AddRangeAsync(userInterventions);
            }
        }

        /// <inheritdoc />
        public async Task DeleteInterventionAsync(Guid interventionId)
        {
            await _interventionRepository.DeleteAsync(interventionId);
        }

        /// <inheritdoc />
        public async Task<InterventionDetailsOutputDto?> GetInterventionDetailsAsync(Guid interventionId)
        {
            var entity = await _interventionRepository.GetByIdWithFirefightersAsync(interventionId);
            return entity is null ? null : _mapper.Map<InterventionDetailsOutputDto>(entity);
        }
    }
}
