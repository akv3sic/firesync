using FireSync.DTOs.Users;

namespace FireSync.DTOs.Interventions
{
    /// <summary>
    /// Represents the details of an intervention.
    /// </summary>
    public class InterventionDetailsOutputDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string? InterventionTypeName { get; set; }

        public List<UserBriefOutputDto> Firefighters { get; set; } = [];
    }
}
