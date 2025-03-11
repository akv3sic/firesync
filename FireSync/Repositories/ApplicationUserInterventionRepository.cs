using FireSync.Data;
using FireSync.Entities;
using FireSync.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FireSync.Repositories
{
    public class ApplicationUserInterventionRepository : IApplicationUserInterventionRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public ApplicationUserInterventionRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task AddAsync(ApplicationUserIntervention userIntervention)
        {
            using var context = _contextFactory.CreateDbContext();

            var exists = await ExistsAsync(userIntervention.InterventionId, userIntervention.ApplicationUserId);
            if (!exists)
            {
                await context.ApplicationUserInterventions.AddAsync(userIntervention);
                await context.SaveChangesAsync();
            }
        }

        public async Task AddRangeAsync(IEnumerable<ApplicationUserIntervention> userInterventions)
        {
            if (!userInterventions.Any())
                return;

            using var context = _contextFactory.CreateDbContext();

            var interventionIds = userInterventions.Select(ui => ui.InterventionId).Distinct().ToList();
            var userIds = userInterventions.Select(ui => ui.ApplicationUserId).Distinct().ToList();

            var existingLinks = await context.ApplicationUserInterventions
                .Where(ui => interventionIds.Contains(ui.InterventionId) && userIds.Contains(ui.ApplicationUserId))
                .ToListAsync();

            var newLinks = new List<ApplicationUserIntervention>();

            foreach (var newUI in userInterventions)
            {
                bool exists = existingLinks.Any(existingUI =>
                    existingUI.InterventionId == newUI.InterventionId &&
                    existingUI.ApplicationUserId == newUI.ApplicationUserId);

                if (!exists)
                {
                    newLinks.Add(newUI);
                }
            }

            if (newLinks.Any())
            {
                await context.ApplicationUserInterventions.AddRangeAsync(newLinks);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(Guid interventionId, string userId)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.ApplicationUserInterventions
                .AnyAsync(ui => ui.InterventionId == interventionId && ui.ApplicationUserId == userId);
        }

        public async Task<List<ApplicationUserIntervention>> GetByInterventionIdAsync(Guid interventionId)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.ApplicationUserInterventions
                .Where(ui => ui.InterventionId == interventionId)
                .Include(ui => ui.ApplicationUser)
                .ToListAsync();
        }

        public async Task<List<ApplicationUserIntervention>> GetByUserIdAsync(string userId)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.ApplicationUserInterventions
                .Where(ui => ui.ApplicationUserId == userId)
                .Include(ui => ui.Intervention)
                .ToListAsync();
        }

        public async Task RemoveAsync(Guid interventionId, string userId)
        {
            using var context = _contextFactory.CreateDbContext();
            var userIntervention = await context.ApplicationUserInterventions
                .FindAsync(interventionId, userId);

            if (userIntervention != null)
            {
                context.ApplicationUserInterventions.Remove(userIntervention);
                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveAllByInterventionIdAsync(Guid interventionId)
        {
            using var context = _contextFactory.CreateDbContext();
            var interventionsToRemove = await context.ApplicationUserInterventions
                .Where(ui => ui.InterventionId == interventionId)
                .ToListAsync();

            if (interventionsToRemove.Any())
            {
                context.ApplicationUserInterventions.RemoveRange(interventionsToRemove);
                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveAllByUserIdAsync(string userId)
        {
            using var context = _contextFactory.CreateDbContext();
            var interventionsToRemove = await context.ApplicationUserInterventions
                .Where(ui => ui.ApplicationUserId == userId)
                .ToListAsync();

            if (interventionsToRemove.Any())
            {
                context.ApplicationUserInterventions.RemoveRange(interventionsToRemove);
                await context.SaveChangesAsync();
            }
        }
    }
}
