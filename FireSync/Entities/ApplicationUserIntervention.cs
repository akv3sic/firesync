using FireSync.Entities.Common;
using FireSync.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FireSync.Entities
{
    [PrimaryKey(nameof(InterventionId), nameof(ApplicationUserId))]
    public class ApplicationUserIntervention
    {
        public Guid InterventionId { get; set; }
        public Intervention Intervention { get; set; } = default!;

        public string ApplicationUserId { get; set; } = string.Empty;
        public ApplicationUser ApplicationUser { get; set; } = default!;
    }
}
