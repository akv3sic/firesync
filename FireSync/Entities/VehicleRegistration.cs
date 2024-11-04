using FireSync.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace FireSync.Entities
{
    /// <summary>
    /// Represents the registration details of a vehicle over time.
    /// </summary>
    public class VehicleRegistration : BaseEntity
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
    }
}
