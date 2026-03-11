using System.ComponentModel.DataAnnotations;

namespace HealthyRecipes.Web.ViewModels.MealPlan
{
    public class MealPlanFilterViewModel
    {
        
            public string? SearchTerm { get; set; }

            [Range(0, 10000)]
            public int? MinCaloriesPerDay { get; set; }

            [Range(0, 10000)]
            public int? MaxCaloriesPerDay { get; set; }

            [Range(0, 500)]
            public int? MinProteinPerDay { get; set; }

            [Range(0, 500)]
            public int? MaxProteinPerDay { get; set; }

            [Range(0, 500)]
            public int? MinCarbsPerDay { get; set; }

            [Range(0, 500)]
            public int? MaxCarbsPerDay { get; set; }

            [Range(0, 500)]
            public int? MinFatPerDay { get; set; }

            [Range(0, 500)]
            public int? MaxFatPerDay { get; set; }

            [Range(1, 365)]
            public int? MinDays { get; set; }

            [Range(1, 365)]
            public int? MaxDays { get; set; }

            [Range(0, 1440)]
            public int? MaxPreparationTimePerDay { get; set; }

            public List<Guid> CategoryIds { get; set; } = new();

            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 20;
            public string SortBy { get; set; } = "CreatedAt";
            public string SortOrder { get; set; } = "desc";
        
    }
}
