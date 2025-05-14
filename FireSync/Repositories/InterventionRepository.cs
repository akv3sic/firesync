using FireSync.Data;
using FireSync.Entities;
using FireSync.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FireSync.Repositories
{
    public class InterventionRepository : IInterventionRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="InterventionRepository"/> class.
        /// </summary>
        /// <param name="contextFactory">The context factory.</param>
        public InterventionRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        /// <inheritdoc />
        public async Task<(List<Intervention> Interventions, int TotalItemCount)> GetPagedInterventionsAsync(int pageNumber, int pageSize)
        {
            using var context = _contextFactory.CreateDbContext();

            var totalItemCount = await context.Interventions.CountAsync();

            var interventions = await context.Interventions
                .Include(i => i.InterventionType)
                .OrderByDescending(i => i.StartTime)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (interventions, totalItemCount);
        }

        /// <inheritdoc />
        public async Task AddAsync(Intervention intervention)
        {
            using var context = _contextFactory.CreateDbContext();
            await context.Interventions.AddAsync(intervention);
            await context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(Guid interventionId)
        {
            using var context = _contextFactory.CreateDbContext();
            var intervention = await context.Interventions.FindAsync(interventionId);

            if (intervention != null)
            {
                context.Interventions.Remove(intervention);
                await context.SaveChangesAsync();
            }
        }

        /// <inheritdoc />
        public async Task<Intervention?> GetByIdWithFirefightersAsync(Guid interventionId)
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Interventions
                .Include(i => i.InterventionType)
                .Include(i => i.ApplicationUserInterventions)
                    .ThenInclude(aui => aui.ApplicationUser)
                .FirstOrDefaultAsync(i => i.Id == interventionId);
        }
    }
}
