using FireSync.Entities;

namespace FireSync.Repositories.Interfaces
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task AddVehicleAsync(Vehicle vehicle);
    }
}
