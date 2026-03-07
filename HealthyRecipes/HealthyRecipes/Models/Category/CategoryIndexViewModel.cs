namespace HealthyRecipes.Web.Models.Category
{
    public class CategoryIndexViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
