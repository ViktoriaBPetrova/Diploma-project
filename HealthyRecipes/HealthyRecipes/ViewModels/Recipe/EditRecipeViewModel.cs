using HealthyRecipes.Web.ViewModels.Recipe;

namespace HealthyRecipes.Web.ViewModels.Recipe
{
    public class EditRecipeViewModel : CreateRecipeViewModel
    {
        public Guid Id { get; set; }
    }
}
