using FireSync.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace FireSync.Entities
{
    /// <summary>
    /// Represents a vehicle in the fleet.
    /// </summary>
    public class Vehicle : BaseEntity
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
    }
}
