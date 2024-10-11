using FireSync.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace FireSync.Entities
{
    public class Intervention : BaseEntity
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
    }
}
