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
                .OrderByDescending(i => i.StartTime)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (interventions, totalItemCount);
        }
    }
}
