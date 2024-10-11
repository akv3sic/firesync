using AutoMapper;
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
        public InterventionService(IInterventionRepository interventionRepository, IMapper mapper)
        {
            _interventionRepository = interventionRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<List<InterventionOutputDto>> GetAllInterventionsAsync()
        {
            var interventions = await _interventionRepository.GetAllInterventionsAsync();
            return _mapper.Map<List<InterventionOutputDto>>(interventions);
        }
    }
}
