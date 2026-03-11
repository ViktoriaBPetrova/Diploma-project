using HealthyRecipes.Web.ViewModels.Recipe;

namespace HealthyRecipes.Web.ViewModels.Recipe
{
    public class RecipeIndexViewModel
    {
        public IEnumerable<RecipeCardViewModel> Recipes { get; set; } = new List<RecipeCardViewModel>();
        public string? SearchQuery { get; set; }
        public Guid? SelectedCategoryId { get; set; }
        public IEnumerable<CategoryFilterViewModel> Categories { get; set; } = new List<CategoryFilterViewModel>();
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public RecipeFilterViewModel Filter { get; set; } = new();
        public int TotalCount { get; set; }
    }
}
