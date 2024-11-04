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
    }
}
