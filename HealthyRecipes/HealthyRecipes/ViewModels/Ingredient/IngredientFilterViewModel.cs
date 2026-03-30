using System.ComponentModel.DataAnnotations;

namespace HealthyRecipes.Web.ViewModels.Ingredient
{
    public class IngredientFilterViewModel
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

        public bool ExcludeUserAllergies { get; set; } = false;

        public string SortBy { get; set; } = "CreatedAt";
        public string SortOrder { get; set; } = "desc";
    }
}
