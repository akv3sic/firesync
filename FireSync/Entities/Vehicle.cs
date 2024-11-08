using FireSync.Entities.Common;
using FireSync.Entities.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FireSync.Entities
{
    /// <summary>
    /// Represents a vehicle in the fleet.
    /// </summary>
    public class Vehicle : BaseEntity, IAuditableEntity, IDeletableEntity
    {
        [Required]
        [MaxLength(50)]
        public string LicensePlate { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Make { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Model { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime? YearOfManufacture { get; set; }

        public ICollection<VehicleRegistration> Registrations { get; set; } = new List<VehicleRegistration>();

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
