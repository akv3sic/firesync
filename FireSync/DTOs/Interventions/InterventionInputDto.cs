using System.ComponentModel.DataAnnotations;

namespace FireSync.DTOs.Interventions
{
    public class InterventionInputDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public Guid? InterventionTypeId { get; set; }

        public List<Guid> FirefighterIds { get; set; } = new List<Guid>();
    }
}
