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
        public async Task<List<Intervention>> GetAllInterventionsAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Interventions.ToListAsync();
        }
    }
}
