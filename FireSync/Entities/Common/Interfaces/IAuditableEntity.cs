namespace FireSync.Entities.Common.Interfaces
{
    /// <summary>
    /// Represents the auditable entity.
    /// </summary>
    public interface IAuditableEntity
    {
        /// <summary>
        /// Gets or sets the entity creation date.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the entity update date.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the entity creation user.
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the entity update user.
        /// </summary>
        public string? UpdatedBy { get; set; }
    }
}
