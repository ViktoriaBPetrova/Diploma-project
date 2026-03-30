using HealthyRecipes.Data.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.Admin.Models
{
    public class ActivityLogDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public ActivityType ActivityType { get; set; }
        public string EntityType { get; set; } = string.Empty;
        public Guid? EntityId { get; set; }
        public string EntityName { get; set; } = string.Empty;
        public string? ChangesSummary { get; set; }
        public LogSeverity Severity { get; set; }
        public string? IpAddress { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool HasDetails { get; set; }
    }
}
