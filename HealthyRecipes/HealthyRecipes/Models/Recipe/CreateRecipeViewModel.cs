using HealthyRecipes.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace HealthyRecipes.Web.Models.Recipe
{
    public class CreateRecipeViewModel
    {
        [Required, MaxLength(2000)]
        public string Info { get; set; } = null!;

        [Range(0, 10000)]
        public int? PrepTime { get; set; }

        public Difficulty? Difficulty { get; set; }

        [Range(1, 100)]
        public int? Servings { get; set; }

        public string? ImageUrl { get; set; }
        public string? VideoUrl { get; set; }

        public List<Guid> SelectedCategoryIds { get; set; } = new();
        public IEnumerable<CategoryFilterViewModel> AvailableCategories { get; set; } = new List<CategoryFilterViewModel>();

        public List<RecipeIngredientInputViewModel> Ingredients { get; set; } = new();
    }
}
