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
        /// Adds a new vehicle.
        /// </summary>
        /// <param name="vehicleInputDto">The vehicle to add.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation containing a value indicating whether the vehicle was added.</returns>
        Task<bool> AddVehicleAsync(VehicleInputDto vehicleInputDto);
    }
}
