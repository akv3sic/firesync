namespace FireSync.Entities.Common
{
    /// <summary>
    /// Represents the base entity.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
