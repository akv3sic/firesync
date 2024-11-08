using FireSync.Entities.Common;
using FireSync.Entities.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FireSync.Entities
{
    public class Intervention : BaseEntity, IAuditableEntity, IDeletableEntity
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public ICollection<ApplicationUserIntervention> ApplicationUserInterventions { get; set; } = new List<ApplicationUserIntervention>();

        /// <inheritdoc/>
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        /// <inheritdoc/>
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        /// <inheritdoc/>
        public string? CreatedBy { get; set; }

        /// <inheritdoc/>
        public string? UpdatedBy { get; set; }

        /// <inheritdoc/>
        public DateTime? DeletedAt { get; set; }

        /// <inheritdoc/>
        public string DeletedBy { get; set; } = string.Empty;
    }
}
