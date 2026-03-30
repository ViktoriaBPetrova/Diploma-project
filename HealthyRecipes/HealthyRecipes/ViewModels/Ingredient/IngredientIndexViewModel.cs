using HealthyRecipes.Web.ViewModels.Ingredient;

namespace HealthyRecipes.Web.ViewModels.Ingredient
{
    public class IngredientIndexViewModel
    {
        public IEnumerable<IngredientViewModel> Ingredients { get; set; } = new List<IngredientViewModel>();
        public string? SearchQuery { get; set; }
        public IngredientFilterViewModel Filter { get; set; } = new();
        public int TotalCount { get; set; }
    }
}
