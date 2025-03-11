namespace FireSync.DTOs.Interventions
{
    public class InterventionOutputDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string Description { get; set; } = string.Empty;

        public Guid? InterventionTypeId { get; set; }

        public string InterventionTypeName { get; set; } = string.Empty;
    }
}
