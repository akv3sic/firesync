using FireSync.Entities.Common;
using FireSync.Entities.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FireSync.Entities
{
    /// <summary>
    /// Represents the registration details of a vehicle over time.
    /// </summary>
    public class VehicleRegistration : BaseEntity, IAuditableEntity, IDeletableEntity
    {
        [Required]
        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = default!;

        [Required]
        [MaxLength(50)]
        public string RegistrationNumber { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ExpiryDate { get; set; }

        [MaxLength(200)]
        public string Notes { get; set; } = string.Empty;

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
