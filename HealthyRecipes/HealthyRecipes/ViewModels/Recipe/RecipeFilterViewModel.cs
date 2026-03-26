using System.ComponentModel.DataAnnotations;

namespace HealthyRecipes.Web.ViewModels.Recipe
{
    public class RecipeFilterViewModel
    {
        public string? SearchTerm { get; set; }

        [Range(0, 10000)]
        public int? MinCalories { get; set; }

        [Range(0, 10000)]
        public int? MaxCalories { get; set; }

        [Range(0, 500)]
        public int? MinProtein { get; set; }

        [Range(0, 500)]
        public int? MaxProtein { get; set; }

        [Range(0, 500)]
        public int? MinCarbs { get; set; }

        [Range(0, 500)]
        public int? MaxCarbs { get; set; }

        [Range(0, 500)]
        public int? MinFat { get; set; }

        [Range(0, 500)]
        public int? MaxFat { get; set; }

        [Range(0, 1440)]
        public int? MaxPreparationTime { get; set; }

        public string? DifficultyLevel { get; set; }

        public List<string> IncludeIngredients { get; set; } = new();
        public List<string> ExcludeIngredients { get; set; } = new();
        public bool ExcludeUserAllergies { get; set; } = false;
        public List<Guid> CategoryIds { get; set; } = new();

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string SortBy { get; set; } = "CreatedAt";
        public string SortOrder { get; set; } = "desc";
    }
}
