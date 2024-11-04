using AutoMapper;
using FireSync.DTOs.Vehicles;
using FireSync.Repositories.Interfaces;
using FireSync.Services.Interfaces;

namespace FireSync.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VehicleOutputDto>> GetAllVehiclesAsync()
        {
            var vehicles = await _vehicleRepository.GetAllVehiclesAsync();
            return _mapper.Map<IEnumerable<VehicleOutputDto>>(vehicles);
        }
    }
}
