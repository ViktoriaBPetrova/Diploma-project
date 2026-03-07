namespace HealthyRecipes.Web.ViewModels.Category
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int RecipeCount { get; set; }
    }
}
