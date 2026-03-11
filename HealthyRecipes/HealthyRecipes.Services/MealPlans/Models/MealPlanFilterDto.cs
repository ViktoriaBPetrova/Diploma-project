using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.MealPlans.Models
{
    public class MealPlanFilterDto
    {
        public string? SearchTerm { get; set; }

        public int? MinCaloriesPerDay { get; set; }
        public int? MaxCaloriesPerDay { get; set; }
        public int? MinProteinPerDay { get; set; }
        public int? MaxProteinPerDay { get; set; }
        public int? MinCarbsPerDay { get; set; }
        public int? MaxCarbsPerDay { get; set; }
        public int? MinFatPerDay { get; set; }
        public int? MaxFatPerDay { get; set; }

        public int? MinDays { get; set; }
        public int? MaxDays { get; set; }
        public int? MaxPreparationTimePerDay { get; set; }

        public List<Guid> CategoryIds { get; set; } = new();

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string SortBy { get; set; } = "CreatedAt";
        public string SortOrder { get; set; } = "desc";
    }
}
