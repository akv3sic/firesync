using FireSync.Entities.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FireSync.Data.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="ModelBuilder"/> to apply global filters.
    /// </summary>
    public static class ModelBuilderExtensions
    {
        private static readonly MethodInfo SetGlobalQueryMethod = typeof(ModelBuilderExtensions).GetMethod(nameof(SetGlobalQuery), BindingFlags.NonPublic | BindingFlags.Static)
                                                                                     ?? throw new MissingMethodException(nameof(ModelBuilderExtensions), nameof(SetGlobalQuery));

        /// <summary>
        /// Applies global filters to entities.
        /// </summary>
        /// <param name="builder">The <see cref="ModelBuilder"/>.</param>
        public static void ApplyGlobalFilters(this ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (typeof(IDeletableEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var method = SetGlobalQueryMethod.MakeGenericMethod(entityType.ClrType);
                    method.Invoke(null, new object[] { builder });
                }
            }
        }

        /// <summary>
        /// Sets a global query filter for soft deleting entities of type <typeparamref name="T"/>.
        /// Entities are considered soft deleted if their <c>DeletedAt</c> property is not null.
        /// </summary>
        /// <typeparam name="T">The type of the entity to which the filter will be applied.</typeparam>
        /// <param name="builder">The <see cref="ModelBuilder"/>.</param>
        private static void SetGlobalQuery<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => EF.Property<DateTime?>(e, "DeletedAt") == null);
        }
    }
}
