using HealthyRecipes.Data.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.Admin.Models
{
    public class FlaggedContentDto
    {
        public Guid Id { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public Guid ContentId { get; set; }
        public string ContentPreview { get; set; } = string.Empty;
        public string ContentAuthorName { get; set; } = string.Empty;
        public string ContentAuthorEmail { get; set; } = string.Empty;
        public FlagReason Reason { get; set; }
        public string? Details { get; set; }
        public string? MatchedBannedWords { get; set; }
        public string? ReportedByUserName { get; set; }
        public FlagStatus Status { get; set; }
        public FlagResolution? Resolution { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsAutoFlagged { get; set; }
    }
}
