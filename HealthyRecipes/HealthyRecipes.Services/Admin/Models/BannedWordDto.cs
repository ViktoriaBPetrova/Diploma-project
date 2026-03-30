using HealthyRecipes.Data.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.Admin.Models
{
    public class BannedWordDto
    {
        public Guid Id { get; set; }
        public string Word { get; set; } = string.Empty;
        public WordSeverity Severity { get; set; }
        public bool IsActive { get; set; }
        public bool IsRegexPattern { get; set; }
        public string? Description { get; set; }
        public string CreatedByUserName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
