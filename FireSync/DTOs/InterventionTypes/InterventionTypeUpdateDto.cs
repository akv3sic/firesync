using System.ComponentModel.DataAnnotations;

namespace FireSync.DTOs.InterventionTypes
{
    public class InterventionTypeUpdateDto : InterventionTypeInputDto
    {
        [Required]
        public int Id { get; set; }
    }
}
