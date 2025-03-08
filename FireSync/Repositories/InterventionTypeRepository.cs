using FireSync.Data;
using FireSync.Entities;
using FireSync.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FireSync.Repositories
{
    public class InterventionTypeRepository : IInterventionTypeRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public InterventionTypeRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<(List<InterventionType> InterventionTypes, int TotalItemCount)> GetPagedInterventionTypesAsync(int pageNumber, int pageSize)
        {
            using var context = _contextFactory.CreateDbContext();
            var totalItemCount = await context.InterventionTypes.CountAsync();
            var interventionTypes = await context.InterventionTypes
                .OrderBy(i => i.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (interventionTypes, totalItemCount);
        }

        public async Task<List<InterventionType>> GetAllInterventionTypesAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.InterventionTypes.OrderBy(t => t.Name).ToListAsync();
        }

        public async Task<InterventionType?> GetByIdAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.InterventionTypes.FindAsync(id);
        }

        public async Task AddAsync(InterventionType interventionType)
        {
            using var context = _contextFactory.CreateDbContext();
            await context.InterventionTypes.AddAsync(interventionType);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(InterventionType interventionType)
        {
            using var context = _contextFactory.CreateDbContext();
            context.InterventionTypes.Update(interventionType);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int interventionTypeId)
        {
            using var context = _contextFactory.CreateDbContext();
            var interventionType = await context.InterventionTypes.FindAsync(interventionTypeId);
            if (interventionType != null)
            {
                context.InterventionTypes.Remove(interventionType);
                await context.SaveChangesAsync();
            }
        }
    }
}
