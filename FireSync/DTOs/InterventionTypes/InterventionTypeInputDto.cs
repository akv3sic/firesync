using System.ComponentModel.DataAnnotations;

namespace FireSync.DTOs.InterventionTypes
{
    public class InterventionTypeInputDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(20)]
        public string ColorCode { get; set; } = string.Empty;
    }
}
