using FireSync.Common;
using FireSync.DTOs.Vehicles;

namespace FireSync.Services.Interfaces
{
    public interface IVehicleService
    {
        /// <summary>
        /// Gets all vehicles with basic information.
        /// </summary>
        /// <returns>A collection of vehicles with basic information.</returns>
        Task<IEnumerable<VehicleOutputDto>> GetAllVehiclesAsync();

        /// <summary>
        /// Gets paginated list of vehicles.
        /// </summary>
        /// <param name="pageNumber">Current page number.</param>
        /// <param name="pageSize">Number of items per page.</param>
        /// <returns>Tuple containing a list of VehicleOutputDto and PaginationMetadata.</returns>
        Task<(IEnumerable<VehicleOutputDto>, PaginationMetadata)> GetPagedVehiclesAsync(int pageNumber, int pageSize = 10);

        /// <summary>
        /// Adds a new vehicle.
        /// </summary>
        /// <param name="vehicleInputDto">The vehicle to add.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation containing a value indicating whether the vehicle was added.</returns>
        Task<bool> AddVehicleAsync(VehicleInputDto vehicleInputDto);

        /// <summary>
        /// Deletes a vehicle.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation containing a value indicating whether the vehicle was deleted.</returns>
        Task<bool> DeleteVehicleAsync(Guid vehicleId);
    }
}
