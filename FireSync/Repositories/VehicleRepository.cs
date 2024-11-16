using FireSync.Data;
using FireSync.Entities;
using FireSync.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FireSync.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleRepository"/> class.
        /// </summary>
        /// <param name="contextFactory">The context factory.</param>
        public VehicleRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Vehicles.AsNoTracking()
                                         .ToListAsync();
        }

        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Vehicles.Add(vehicle);

            await context.SaveChangesAsync();
        }
    }
}
