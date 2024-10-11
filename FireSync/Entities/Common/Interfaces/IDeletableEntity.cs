namespace FireSync.Entities.Common.Interfaces
{
    /// <summary>
    /// Represents the deletable entity.
    /// </summary>
    public interface IDeletableEntity
    {
        /// <summary>
        /// Gets or sets the date and time when the entity was deleted.
        /// </summary>
        DateTime? DeletedAt { get; set; }

        /// <summary>
        /// Gets or sets the user who performed the deletion.
        /// </summary>
        string? DeletedBy { get; set; }
    }
}
