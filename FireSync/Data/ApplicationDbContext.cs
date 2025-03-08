using FireSync.Entities;
using FireSync.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FireSync.Data.Extensions;
using FireSync.Entities.Common.Interfaces;

namespace FireSync.Data
{
    /// <summary>
    /// Represents the application database context.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Intervention> Interventions { get; set; }

        public DbSet<InterventionType> InterventionTypes { get; set; }

        public DbSet<ApplicationUserIntervention> ApplicationUserInterventions { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<VehicleRegistration> VehicleRegistrations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyGlobalFilters();
        }

        /// <summary>
        /// Saves the changes to the database.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of state entries written to the database.</returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in this.ChangeTracker.Entries<IDeletableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.DeletedAt = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
        }
    }
}
