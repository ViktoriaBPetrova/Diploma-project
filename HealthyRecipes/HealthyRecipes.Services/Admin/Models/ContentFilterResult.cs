using HealthyRecipes.Data.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.Admin.Models
{
    public class ContentFilterResult
    {
        public bool ContainsBannedWords { get; set; }
        public List<string> MatchedWords { get; set; } = new();
        public WordSeverity HighestSeverity { get; set; }
        public bool ShouldAutoBlock { get; set; }
        public bool ShouldFlagForReview { get; set; }
    }
}
