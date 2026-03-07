namespace HealthyRecipes.Web.Models.Recipe
{
    public class CategoryFilterViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int RecipeCount { get; set; }
    }
}
