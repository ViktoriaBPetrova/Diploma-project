using HealthyRecipes.Web.ViewModels.Category;

namespace HealthyRecipes.Web.ViewModels.Category
{
    public class CategoryIndexViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
