using FireSync.Entities.Common;
using FireSync.Entities.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FireSync.Entities
{
    public class InterventionType : BaseEntity, IAuditableEntity, IDeletableEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(20)]
        public string ColorCode { get; set; } = string.Empty;

        public ICollection<Intervention> Interventions { get; set; } = new List<Intervention>();

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