﻿using AutoMapper;
using FireSync.Common;
using FireSync.DTOs.Vehicles;
using FireSync.Entities;
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

        /// <inheritdoc />
        public async Task<IEnumerable<VehicleOutputDto>> GetAllVehiclesAsync()
        {
            var vehicles = await _vehicleRepository.GetAllVehiclesAsync();
            return _mapper.Map<IEnumerable<VehicleOutputDto>>(vehicles);
        }

        /// <inheritdoc />
        public async Task<(IEnumerable<VehicleOutputDto>, PaginationMetadata)> GetPagedVehiclesAsync(int pageNumber, int pageSize = 10)
        {
            var vehicles = await _vehicleRepository.GetAllVehiclesAsync();
            var totalItemCount = vehicles.Count();

            var pagedVehicles = vehicles
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);
            return (_mapper.Map<IEnumerable<VehicleOutputDto>>(pagedVehicles), paginationMetadata);
        }

        /// <inheritdoc />
        public async Task<bool> AddVehicleAsync(VehicleInputDto vehicleInputDto)
        {
            var vehicle = _mapper.Map<Vehicle>(vehicleInputDto);

            await _vehicleRepository.AddVehicleAsync(vehicle);

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> DeleteVehicleAsync(Guid vehicleId)
        {
            return await _vehicleRepository.DeleteVehicleAsync(vehicleId);
        }
    }
}
